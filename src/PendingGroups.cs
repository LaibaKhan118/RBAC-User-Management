using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace TeacherForm
{
    public partial class PendingGroupsList : Form
    {
        private string connectionString = "Data Source=DESKTOP-D9AI616\\SQLEXPRESS;" +
           "Initial Catalog=School;" +
           "Integrated Security=True;" +
           "Encrypt=False;" +
           "TrustServerCertificate=True;";
        public PendingGroupsList()
        {
            InitializeComponent();
        }

        private void DisplayData() 
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                pu.id, pu.userId, pu.username, pu.password, pu.isActive,
                gRole.groupName AS Role, STRING_AGG(g.groupName, ', ') AS Groups,
                pu.actionType, pu.status, pu.makerId, pu.createdOn, pu.updatedOn
            FROM PendingUsers pu
            LEFT JOIN PendingUserGroups pug ON pu.id = pug.pendingUserId
            LEFT JOIN Groups g ON pug.groupId = g.id
            LEFT JOIN Groups gRole ON pu.roleId = gRole.id   -- join for role
            WHERE pu.status = 'PENDING'
            GROUP BY pu.id, pu.userId, pu.username, pu.password, pu.isActive,
                     gRole.groupName, pu.actionType, pu.status, 
                     pu.makerId, pu.checkerId, pu.createdOn, pu.updatedOn";


                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void PendingGroups_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                pu.id, pu.userId, pu.username, pu.password, pu.isActive,
                gRole.groupName AS Role, STRING_AGG(g.groupName, ', ') AS Groups,
                pu.actionType, pu.status, pu.makerId, pu.createdOn, pu.updatedOn
            FROM PendingUsers pu
            LEFT JOIN PendingUserGroups pug ON pu.id = pug.pendingUserId
            LEFT JOIN Groups g ON pug.groupId = g.id
            LEFT JOIN Groups gRole ON pu.roleId = gRole.id   -- join for role
            WHERE (id = TRY_CAST(@search AS INT)) OR 
                  (status LIKE @SearchText) OR 
                  (makerId = TRY_CAST(@search AS INT))
            GROUP BY pu.id, pu.userId, pu.username, pu.password, pu.isActive,
                     gRole.groupName, pu.actionType, pu.status, 
                     pu.makerId, pu.checkerId, pu.createdOn, pu.updatedOn";

                
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@search", SearchBox.Text);
                    cmd.Parameters.AddWithValue("@searchText", "%" + SearchBox.Text + "%");

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        { 
            if(dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to accept.");
                return;
            }

            DataGridViewRow row = dataGridView1.SelectedRows[0];
            int pendingId = Convert.ToInt32(row.Cells["id"].Value);
            string actionType = row.Cells["actionType"].Value.ToString();
            int? existingUserId = row.Cells["userId"].Value == DBNull.Value ? 
                (int?)null : Convert.ToInt32(row.Cells["UserId"].Value);
            
            try 
            { 
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();
                    try 
                    { 
                        if(actionType == "INSERT")
                        {
                            string insertUser = @"INSERT INTO Users(username, password, isActive, roleId, createdOn, createdBy)
                                                OUTPUT INSERTED.ID
                                                VALUES (@username, @password, @isActive, @roleId, GETDATE(), @createdBy)";

                            SqlCommand cmd = new SqlCommand(insertUser, conn, transaction);
                            cmd.Parameters.AddWithValue("@username", row.Cells["username"].Value.ToString());
                            cmd.Parameters.AddWithValue("@username", row.Cells["password"].Value.ToString());
                            cmd.Parameters.AddWithValue("@isActive", Convert.ToBoolean(row.Cells["isActive"].Value));
                            cmd.Parameters.AddWithValue("@roleId", row.Cells["isActive"].Value);
                            cmd.Parameters.AddWithValue("@createdBy", CurrentUser.UserId);

                            int newUserId = (int)cmd.ExecuteScalar();

                            string insertGroups = @"INSERT INTO UserGroups (userId, groupId)
                                                  SELECT @userID, groupId FROM PendingUserGroups
                                                  WHERE pendingUserId = @pendingID";

                            SqlCommand cmdGroups = new SqlCommand(insertGroups, conn, transaction);
                            cmdGroups.Parameters.AddWithValue("@userID", newUserId);
                            cmdGroups.Parameters.AddWithValue("@pendingID", pendingId);
                            cmdGroups.ExecuteNonQuery();
                        }
                        else if (actionType == "UPDATE" && existingUserId.HasValue)
                        {
                            string updateUser = @"UPDATE Users SET username=@username, password=@password, isActive=@isActive, 
                                                roleId=@roleId, updatedOn=GETDATE(), updatedBy=@checkerId
                                                WHERE id=@userID";
                            SqlCommand cmd = new SqlCommand(updateUser, conn, transaction);
                            cmd.Parameters.AddWithValue("@username", row.Cells["username"].Value.ToString());
                            cmd.Parameters.AddWithValue("@password", row.Cells["password"].Value.ToString());
                            cmd.Parameters.AddWithValue("@isActive", Convert.ToBoolean(row.Cells["isActive"].Value));
                            cmd.Parameters.AddWithValue("@roleId", row.Cells["isActive"].Value);
                            cmd.Parameters.AddWithValue("@checkerId", CurrentUser.UserId);
                            cmd.Parameters.AddWithValue("@userID", existingUserId.Value);
                            cmd.ExecuteNonQuery();

                            string deleteGroups = "DELETE FROM UserGroups WHERE userId=@userID";
                            SqlCommand cmdDelGroups = new SqlCommand(deleteGroups, conn, transaction);
                            cmdDelGroups.Parameters.AddWithValue("@userID", existingUserId.Value);
                            cmdDelGroups.ExecuteNonQuery();

                            string insertGroups = @"INSERT INTO UserGroups (userId, groupId)
                                                  SELECT @userID, groupId FROM PendingUserGroups
                                                  WHERE pendingUserId = @pendingID";

                            SqlCommand cmdGroups = new SqlCommand(insertGroups, conn, transaction);
                            cmdGroups.Parameters.AddWithValue("@userID", existingUserId.Value);
                            cmdGroups.Parameters.AddWithValue("@pendingID", pendingId);
                            cmdGroups.ExecuteNonQuery();
                        }
                        else if (actionType == "DELETE" && existingUserId.HasValue)
                        {
                            // Marking Inactive instead of deleting to preserve data integrity
                            string updateUser = @"UPDATE Users SET isActive=0, 
                                                updatedOn=GETDATE(), updatedBy=@checkerId
                                                WHERE id=@userID";
                            SqlCommand cmd = new SqlCommand(updateUser, conn, transaction);
                            cmd.Parameters.AddWithValue("@checkerId", CurrentUser.UserId);
                            cmd.Parameters.AddWithValue("@userID", existingUserId.Value);
                            cmd.ExecuteNonQuery();
                        }

                        string approveQuery = "UPDATE PendingUsers SET status='APPROVED', checkerId=@checkerId, updatedOn=GETDATE() WHERE id=@pendingId";
                        using(SqlCommand cmd = new SqlCommand(approveQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@checkerId", CurrentUser.UserId);
                            cmd.Parameters.AddWithValue("@pendingId", pendingId);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Record approved successfully.");
                        DisplayData();

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error: " + ex.Message);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error: " + ex.Message);
                return;
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(row.Cells["id"].Value);
                try 
                { 
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string query = "UPDATE PendingUsers SET status = 'REJECTED', approvedOn=GETDATE() WHERE id = @id";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);

                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            else
            {
                MessageBox.Show("Please select a record to reject.");
            }
        }
    }
}


