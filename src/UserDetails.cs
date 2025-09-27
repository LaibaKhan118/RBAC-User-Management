using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TeacherForm
{
    public partial class UserDetails : Form
    {
        private readonly SqlConnection conn;
        private readonly int? userId;
        private string connectionString =
            "Data Source=DESKTOP-D9AI616\\SQLEXPRESS;" +
            "Initial Catalog=School;" +
            "Integrated Security=True;" +
            "Encrypt=False;" +
            "TrustServerCertificate=True;";

        public UserDetails(SqlConnection connection, int? id = null, string username = "", string password = "", bool isActive = true, int? roleId = null, List<int> groupIds = null)
        {
            InitializeComponent();

            conn = connection ?? new SqlConnection(connectionString);
            userId = id;

            if (userId.HasValue)
            {
                txtUsername.Text = username;
                txtPassword.Text = password;
                chkIsActive.Checked = isActive;
            }

            this.Load += (s, e) =>
            {
                LoadGroups();
                LoadRoles(roleId);
            };
        }

        private void LoadGroups()
        {
            chkListGroups.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT id, groupname FROM Groups";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    chkListGroups.Items.Add(new ListItem(reader.GetInt32(0), reader.GetString(1)));
                }
            }

            if (userId.HasValue)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT groupId FROM UserGroups WHERE userId = @userId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@userId", userId.Value);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    var selectedGroupIds = new List<int>();
                    while (reader.Read())
                    {
                        selectedGroupIds.Add(reader.GetInt32(0));
                    }

                    for (int i = 0; i < chkListGroups.Items.Count; i++)
                    {
                        var item = (ListItem)chkListGroups.Items[i];
                        if (selectedGroupIds.Contains(item.Id))
                        {
                            chkListGroups.SetItemChecked(i, true);
                        }
                    }
                }
            }
        }

        private void LoadRoles(int? roleId = null)
        {
            cmbRole.Items.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT id, roleName FROM Roles";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbRole.Items.Add(new ListItem(reader.GetInt32(0), reader.GetString(1)));
                }

                if (roleId.HasValue)
                {
                    for (int i = 0; i < cmbRole.Items.Count; i++)
                    {
                        var item = (ListItem)cmbRole.Items[i];
                        if (item.Id == roleId.Value)
                        {
                            cmbRole.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                chkListGroups.CheckedItems.Count == 0 || cmbRole.SelectedItem == null)
            {
                MessageBox.Show("Please fill all fields and select at least one group.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    var selectedRole = (ListItem)cmbRole.SelectedItem;
                    SqlTransaction transaction = conn.BeginTransaction();
                    try
                    {
                        if (userId.HasValue)
                        {
                            int originalCreatedBy = 0;
                            using (SqlCommand getCmd = new SqlCommand("SELECT createdBy FROM Users WHERE id=@id", conn, transaction))
                            {
                                getCmd.Parameters.AddWithValue("@id", userId.Value);
                                object result = getCmd.ExecuteScalar();
                                if (result != null && result != DBNull.Value)
                                    originalCreatedBy = Convert.ToInt32(result);
                            }
                            string query = @"INSERT INTO PendingUsers(userId, username, password, isActive, roleId, actionType, createdBy, updatedOn, updatedBy)
                                OUTPUT INSERTED.id
                                VALUES(@userId, @username, @password, @isActive, @roleId, 'UPDATE', @createdBy, GETDATE(), @updatedBy)";

                            SqlCommand cmd = new SqlCommand(query, conn, transaction);
                            cmd.Parameters.AddWithValue("@userId", userId.Value);
                            cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                            cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                            cmd.Parameters.AddWithValue("@isActive", chkIsActive.Checked);
                            cmd.Parameters.AddWithValue("@createdBy", originalCreatedBy);
                            cmd.Parameters.AddWithValue("@roleId", selectedRole.Id);
                            cmd.Parameters.AddWithValue("@updatedBy", CurrentUser.UserId);

                            int pendingUserId = (int)cmd.ExecuteScalar();

                            foreach (var checkedItem in chkListGroups.CheckedItems)
                            {
                                var group = (ListItem)checkedItem;
                                SqlCommand insertCmd = new SqlCommand(
                                    "INSERT INTO PendingUserGroups (pendingUserId, groupId) VALUES (@pendingUserId, @groupId)", conn, transaction
                                );
                                insertCmd.Parameters.AddWithValue("@pendingUserId", pendingUserId);
                                insertCmd.Parameters.AddWithValue("@groupId", group.Id);
                                insertCmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Update request sent for approval!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            string query = @"INSERT INTO PendingUsers(userId, username, password, isActive, roleId, actionType, createdOn, createdBy)
                                   OUTPUT INSERTED.id
                                   VALUES (NULL, @username, @password, @isActive, @roleId, 'INSERT', GETDATE(), @createdBy)";

                            SqlCommand cmd = new SqlCommand(query, conn, transaction);
                            cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                            cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                            cmd.Parameters.AddWithValue("@isActive", chkIsActive.Checked);
                            cmd.Parameters.AddWithValue("@roleId", selectedRole.Id);
                            cmd.Parameters.AddWithValue("@createdBy", CurrentUser.UserId);

                            int pendingUserId = (int)cmd.ExecuteScalar();

                            foreach (var checkedItem in chkListGroups.CheckedItems)
                            {
                                var group = (ListItem)checkedItem;
                                SqlCommand insertCmd = new SqlCommand(
                                    "INSERT INTO PendingUserGroups (pendingUserId, groupId) VALUES (@pendingUserId, @groupId)", conn, transaction
                                );
                                insertCmd.Parameters.AddWithValue("@pendingUserId", pendingUserId);
                                insertCmd.Parameters.AddWithValue("@groupId", group.Id);
                                insertCmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Record sent for approval!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        transaction.Commit();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error: " + ex.Message);
                        return;
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // unique username violation
                    MessageBox.Show("Username already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show($"SQL Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        /// Helper class to hold Group data in the checklist
        public class ListItem
        {
            public int Id { get; }
            public string Name { get; }

            public ListItem(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public override string ToString()
            {
                return Name;
            }
        }
    }
}
