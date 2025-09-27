using Microsoft.Data.SqlClient; 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace TeacherForm
{
    public partial class UserList : Form
    {
        private string connectionString = "Data Source=DESKTOP-D9AI616\\SQLEXPRESS;" +
            "Initial Catalog=School;" +
            "Integrated Security=True;" +
            "Encrypt=False;" +
            "TrustServerCertificate=True;";

        public UserList()
        {
            InitializeComponent();
        }

        private void DisplayData()
        {
            SearchBox.Text = string.Empty;
            LoadUsers();
        }

        private void UserList_Load(object sender, EventArgs e)
        {
            cmbFilter.Items.Clear();

            if (CurrentUser.HasPermission("UserList", "View Approved"))
                cmbFilter.Items.Add("Approved");

            if (CurrentUser.HasPermission("UserList", "View Pending"))
                cmbFilter.Items.Add("Pending");

            if (CurrentUser.HasPermission("UserList", "View Rejected"))
                cmbFilter.Items.Add("Rejected");

            // Default selection
            if (cmbFilter.Items.Count > 0)
                cmbFilter.SelectedIndex = 0;
            else
                MessageBox.Show("You do not have permission to view any records in UserList.");

            LoadUsers();

            btnDelete.Visible = CurrentUser.HasPermission("UserList", "Delete");
            btnAdd.Visible = CurrentUser.HasPermission("UserList", "Add");
            btnEdit.Visible = CurrentUser.HasPermission("UserList", "Edit");
            //btnApprove.Visible = CurrentUser.HasPermission("UserList", "Approve");
            //btnView.Visible = CurrentUser.HasPermission("UserList", "Reject");
        }


        private void LoadUsers(string searchText = "")
        {
            string selectedFilter = cmbFilter.SelectedItem?.ToString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "";

                if (selectedFilter == "Approved")
                {
                    query = @"SELECT u.id, u.username, u.password, u.roleId, r.roleName AS Role, u.isActive, 
                             STRING_AGG(g.groupname, ', ') AS Groups, u.createdOn, u.updatedOn, u.checkerId
                      FROM Users u   
                      LEFT JOIN Roles r ON u.roleId = r.id
                      LEFT JOIN UserGroups ug ON u.id = ug.userId
                      LEFT JOIN Groups g ON ug.groupId = g.id
                      WHERE (@search = '' 
                             OR u.id = TRY_CAST(@search AS INT) 
                             OR u.username LIKE @searchText 
                             OR r.roleName LIKE @searchText)
                      GROUP BY u.id, u.username, u.password, u.roleId, r.roleName, u.isActive, u.createdOn, u.updatedOn, u.checkerId";
                }
                else if (selectedFilter == "Pending")
                {
                    btnAdd.Visible = false;
                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                    query = @"SELECT pu.id, pu.userId, pu.username, pu.password, pu.isActive, pu.roleId, r.roleName AS Role, 
                             STRING_AGG(g.groupname, ', ') AS Groups, pu.actionType, pu.status, pu.createdBy, 
                             pu.createdOn, pu.updatedBy, pu.updatedOn
                      FROM PendingUsers pu
                      LEFT JOIN PendingUserGroups pug ON pu.id = pug.pendingUserId
                      JOIN Groups g ON pug.groupId = g.id
                      INNER JOIN Roles r ON pu.roleId = r.id
                      WHERE pu.status = 'Pending'
                        AND (@search = '' 
                             OR pu.id = TRY_CAST(@search AS INT) 
                             OR pu.username LIKE @searchText 
                             OR r.roleName LIKE @searchText)
                      GROUP BY pu.id, pu.userId, pu.username, pu.password, pu.isActive, pu.roleId, r.roleName, 
                               pu.actionType, pu.status, pu.createdBy, pu.createdOn, pu.updatedBy, pu.updatedOn";
                }
                else if (selectedFilter == "Rejected")
                {
                    btnAdd.Visible = false;
                    query = @"SELECT pu.id, pu.userId, pu.username, pu.password, pu.isActive, pu.roleId, r.roleName AS Role, 
                             STRING_AGG(g.groupname, ', ') AS Groups, pu.actionType, pu.status, pu.createdBy, 
                             pu.createdOn, pu.updatedBy, pu.updatedOn,  pu.checkerId, pu.checkerRemarks AS remarks
                      FROM PendingUsers pu
                      LEFT JOIN PendingUserGroups pug ON pu.id = pug.pendingUserId
                      LEFT JOIN Groups g ON pug.groupId = g.id
                      INNER JOIN Roles r ON pu.roleId = r.id
                      WHERE pu.status = 'REJECTED'
                        AND (@search = '' 
                             OR pu.id = TRY_CAST(@search AS INT) 
                             OR pu.username LIKE @searchText 
                             OR r.roleName LIKE @searchText)
                      GROUP BY pu.id, pu.userId, pu.username, pu.password, pu.isActive, pu.roleId, r.roleName, 
                               pu.actionType, pu.status, pu.createdBy, pu.createdOn, pu.updatedBy, pu.updatedOn, pu.checkerId, pu.checkerRemarks";
                }
                else
                {
                    MessageBox.Show("Please select a filter first.");
                    return;
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@search", searchText);
                    cmd.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
            }
        }


        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            LoadUsers(SearchBox.Text.Trim());
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (UserDetails details = new UserDetails(new SqlConnection(connectionString)))
            {
                if (details.ShowDialog() == DialogResult.Yes)
                {
                    DisplayData();
                }
            }
        }


        private void btnView_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to view.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dataGridView1.SelectedRows[0];
            string filter = cmbFilter.SelectedItem?.ToString();

            int pendingId = 0;
            int userId = 0;
            string actionType = "";
            string username = "";
            string password = "";
            int roleId = 0;
            bool isActive = false;
            string remarks = "";

            // new + old values
            string oldUsername = "";
            string oldPassword = "";
            int oldRoleId = 0;
            bool oldIsActive = false;

            List<int> oldGroups = new List<int>();
            List<int> newGroups = new List<int>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                if (filter == "Pending" || filter == "Rejected")
                {
                    pendingId = Convert.ToInt32(row.Cells["id"].Value);
                    actionType = row.Cells["actionType"].Value.ToString();
                    username = row.Cells["username"].Value.ToString();
                    password = row.Cells["password"].Value.ToString();
                    roleId = Convert.ToInt32(row.Cells["roleId"].Value);
                    isActive = Convert.ToBoolean(row.Cells["isActive"].Value);

                    if (filter == "Rejected")
                        remarks = row.Cells["remarks"].Value?.ToString();

                    // fetch userId from PendingUsers
                    string getUserId = @"SELECT userId FROM PendingUsers WHERE id = @pid";
                    using (SqlCommand cmd = new SqlCommand(getUserId, conn))
                    {
                        cmd.Parameters.AddWithValue("@pid", pendingId);
                        var result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                            userId = Convert.ToInt32(result);
                    }

                    // if update or delete → fetch old user values
                    if (userId > 0 && (actionType == "UPDATE" || actionType == "DELETE"))
                    {
                        string getOldUser = @"SELECT username, password, roleId, isActive 
                                      FROM Users WHERE id = @uid";
                        using (SqlCommand cmd = new SqlCommand(getOldUser, conn))
                        {
                            cmd.Parameters.AddWithValue("@uid", userId);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    oldUsername = reader["username"].ToString();
                                    oldPassword = reader["password"].ToString();
                                    oldRoleId = Convert.ToInt32(reader["roleId"]);
                                    oldIsActive = Convert.ToBoolean(reader["isActive"]);
                                }
                            }
                        }

                        string oldGroupsQuery = @"SELECT groupId FROM UserGroups WHERE userId = @uid";
                        using (SqlCommand cmd = new SqlCommand(oldGroupsQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@uid", userId);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                    oldGroups.Add(reader.GetInt32(0));
                            }
                        }
                    }

                    // always get new groups from PendingUserGroups
                    string newGroupsQuery = @"SELECT groupId FROM PendingUserGroups WHERE pendingUserId = @pid";
                    using (SqlCommand cmd = new SqlCommand(newGroupsQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@pid", pendingId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                                newGroups.Add(reader.GetInt32(0));
                        }
                    }
                }
                else if (filter == "Approved")
                {
                    userId = Convert.ToInt32(row.Cells["id"].Value);
                    username = row.Cells["username"].Value.ToString();
                    password = row.Cells["password"].Value.ToString();
                    roleId = Convert.ToInt32(row.Cells["roleId"].Value);
                    isActive = Convert.ToBoolean(row.Cells["isActive"].Value);

                    // approved → no old values (since it’s the final state)
                    oldUsername = username;
                    oldPassword = password;
                    oldRoleId = roleId;
                    oldIsActive = isActive;

                    string groupsQuery = @"SELECT groupId FROM UserGroups WHERE userId = @uid";
                    using (SqlCommand cmd = new SqlCommand(groupsQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", userId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                                newGroups.Add(reader.GetInt32(0));
                        }
                    }
                }
            }

            using (UserReview reviewForm = new UserReview(pendingId, userId, username, password, roleId, isActive, actionType, filter, remarks, oldGroups, newGroups, oldUsername, oldPassword, oldRoleId, oldIsActive))
            {
                var result = reviewForm.ShowDialog();

                if (result == DialogResult.Yes)
                {
                    if (actionType == "UPDATE")
                    {
                        int historyId;
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            using (SqlTransaction tran = conn.BeginTransaction())
                            {
                                try
                                {
                                    // Insert into UserHistory
                                    string trackQuery = @"INSERT INTO UserHistory (userId, oldUsername, newUsername, oldPassword, newPassword, oldIsActive, newIsActive, oldRoleId, newRoleId, actionType, createdBy, updatedBy, checkerId)
                                      OUTPUT INSERTED.id
                                      VALUES (@userId, @oldUsername, @newUsername, @oldPassword, @newPassword, @oldIsActive, @newIsActive, @oldRoleId, @newRoleId, 'UPDATE', @createdBy, @updatedBy, @checkerId)";

                                    using (SqlCommand cmd = new SqlCommand(trackQuery, conn, tran))
                                    {
                                        cmd.Parameters.AddWithValue("@userId", row.Cells["userId"].Value);
                                        cmd.Parameters.AddWithValue("@newUsername", username);
                                        cmd.Parameters.AddWithValue("@oldUsername", oldUsername);
                                        cmd.Parameters.AddWithValue("@newPassword", password);
                                        cmd.Parameters.AddWithValue("@oldPassword", oldPassword);
                                        cmd.Parameters.AddWithValue("@oldIsActive", oldIsActive);
                                        cmd.Parameters.AddWithValue("@newIsActive", isActive);
                                        cmd.Parameters.AddWithValue("@oldRoleId", oldRoleId);
                                        cmd.Parameters.AddWithValue("@newRoleId", roleId);
                                        cmd.Parameters.AddWithValue("@createdBy", row.Cells["createdBy"].Value);
                                        cmd.Parameters.AddWithValue("@updatedBy", row.Cells["updatedBy"].Value ?? DBNull.Value);
                                        cmd.Parameters.AddWithValue("@checkerId", CurrentUser.UserId);

                                        historyId = Convert.ToInt32(cmd.ExecuteScalar());
                                    }

                                    // Build sets for comparison
                                    var oldSet = new HashSet<int>(oldGroups);
                                    var newSet = new HashSet<int>(newGroups);

                                    // Common permissions
                                    foreach (var pid in oldSet.Intersect(newSet))
                                    {
                                        InsertGroupHistory(conn, tran, historyId, pid, pid);
                                    }

                                    // Removed permissions (old only)
                                    foreach (var pid in oldSet.Except(newSet))
                                    {
                                        InsertGroupHistory(conn, tran, historyId, pid, null);
                                    }

                                    // Added permissions (new only)
                                    foreach (var pid in newSet.Except(oldSet))
                                    {
                                        InsertGroupHistory(conn, tran, historyId, null, pid);
                                    }

                                    tran.Commit();
                                }
                                catch
                                {
                                    tran.Rollback();
                                    throw;
                                }
                            }
                        }
                    }
                    else if (actionType == "DELETE")
                    {
                        int historyId;
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            using (SqlTransaction tran = conn.BeginTransaction())
                            {
                                try
                                {
                                    // Insert into UserHistory
                                    string trackQuery = @"INSERT INTO UserHistory (userId, oldUsername, oldPassword, oldIsActive, oldRoleId, actionType, createdBy, updatedBy, checkerId)
                                      OUTPUT INSERTED.id
                                      VALUES (@userId, @oldUsername, @oldPassword, @oldIsActive, @oldRoleId, 'DELETE', @createdBy, @updatedBy, @checkerId)";

                                    using (SqlCommand cmd = new SqlCommand(trackQuery, conn, tran))
                                    {
                                        cmd.Parameters.AddWithValue("@userId", row.Cells["userId"].Value);
                                        cmd.Parameters.AddWithValue("@oldUsername", username);
                                        cmd.Parameters.AddWithValue("@oldPassword", password);
                                        cmd.Parameters.AddWithValue("@oldisActive", isActive);
                                        cmd.Parameters.AddWithValue("@OldRoleId", roleId);
                                        cmd.Parameters.AddWithValue("@createdBy", row.Cells["createdBy"].Value);
                                        cmd.Parameters.AddWithValue("@updatedBy", row.Cells["updatedBy"].Value);
                                        cmd.Parameters.AddWithValue("@checkerId", CurrentUser.UserId);

                                        historyId = Convert.ToInt32(cmd.ExecuteScalar());
                                    }

                                    // Log all old groups as deleted
                                    foreach (var pid in oldGroups)
                                    {
                                        InsertGroupHistory(conn, tran, historyId, pid, null);
                                    }

                                    tran.Commit();
                                }
                                catch
                                {
                                    tran.Rollback();
                                    throw;
                                }
                            }
                        }
                    }
                    ApprovePendingUser(pendingId, actionType);
                    LoadUsers();
                }
                else if (result == DialogResult.No)
                {
                    LoadUsers();
                }
            }
        }

        private void InsertGroupHistory(SqlConnection conn, SqlTransaction tran, int historyId, int? oldGp, int? newGp)
        {
            string permInsert = @"INSERT INTO UserGroupsHistory (userHistoryId, oldGroupId, newGroupId)
                          VALUES (@hid, @oldGid, @newGid)";
            using (SqlCommand cmd = new SqlCommand(permInsert, conn, tran))
            {
                cmd.Parameters.AddWithValue("@hid", historyId);
                cmd.Parameters.AddWithValue("@oldGid", (object?)oldGp ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@newGid", (object?)newGp ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        private void ApprovePendingUser(int pendingId, string actionType)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    // Get all info from PendingUsers first
                    string getUserQuery = "SELECT * FROM PendingUsers WHERE id = @id";
                    SqlCommand getCmd = new SqlCommand(getUserQuery, conn, tran);
                    getCmd.Parameters.AddWithValue("@id", pendingId);

                    SqlDataReader reader = getCmd.ExecuteReader();
                    if (!reader.Read())
                    {
                        MessageBox.Show("Record not found.");
                        reader.Close();
                        tran.Rollback();
                        return;
                    }

                    int? userId = reader["userId"] as int?;
                    int? updatedBy = reader["updatedBy"] as int?;
                    int? createdBy = reader["createdBy"] as int?;
                    string username = reader["username"].ToString();
                    string password = reader["password"].ToString();
                    bool isActive = Convert.ToBoolean(reader["isActive"]);
                    int roleId = Convert.ToInt32(reader["roleId"]);
                    string actType = reader["actionType"].ToString();
                    reader.Close();

                    if (actType == "INSERT")
                    {
                        string insertQuery = @"INSERT INTO Users(username, password, isActive, roleId, createdOn, createdBy, checkerId)
                                       OUTPUT INSERTED.ID
                                       VALUES (@username, @password, @isActive, @roleId, GETDATE(), @createdBy, @checkerId)";
                        SqlCommand insertCmd = new SqlCommand(insertQuery, conn, tran);
                        insertCmd.Parameters.AddWithValue("@username", username);
                        insertCmd.Parameters.AddWithValue("@password", password);
                        insertCmd.Parameters.AddWithValue("@isActive", isActive);
                        insertCmd.Parameters.AddWithValue("@roleId", roleId);
                        insertCmd.Parameters.AddWithValue("@createdBy", createdBy ?? (object)DBNull.Value);
                        insertCmd.Parameters.AddWithValue("@checkerId", CurrentUser.UserId);

                        int newUserId = (int)insertCmd.ExecuteScalar();

                        string insertGroups = @"INSERT INTO UserGroups (userId, groupId)
                                        SELECT @uid, groupId FROM PendingUserGroups
                                        WHERE pendingUserId = @pid";
                        SqlCommand groupsCmd = new SqlCommand(insertGroups, conn, tran);
                        groupsCmd.Parameters.AddWithValue("@uid", newUserId);
                        groupsCmd.Parameters.AddWithValue("@pid", pendingId);
                        groupsCmd.ExecuteNonQuery();
                    }
                    else if (actType == "UPDATE" && userId.HasValue)
                    {
                        string updateQuery = @"UPDATE Users
                                       SET username = @username,
                                           password = @password,
                                           isActive = @isActive,
                                           roleId = @roleId,
                                           updatedOn = GETDATE(),
                                           updatedBy = @updatedBy,
                                           checkerId = @checkerId
                                       WHERE id = @uid";
                        SqlCommand updateCmd = new SqlCommand(updateQuery, conn, tran);
                        updateCmd.Parameters.AddWithValue("@username", username);
                        updateCmd.Parameters.AddWithValue("@password", password);
                        updateCmd.Parameters.AddWithValue("@isActive", isActive);
                        updateCmd.Parameters.AddWithValue("@roleId", roleId);
                        updateCmd.Parameters.AddWithValue("@updatedBy", updatedBy ?? (object)DBNull.Value);
                        updateCmd.Parameters.AddWithValue("@checkerId", CurrentUser.UserId);
                        updateCmd.Parameters.AddWithValue("@uid", userId.Value);
                        updateCmd.ExecuteNonQuery();

                        // Replace groups
                        string deleteGroups = "DELETE FROM UserGroups WHERE userId=@uid";
                        SqlCommand delGroups = new SqlCommand(deleteGroups, conn, tran);
                        delGroups.Parameters.AddWithValue("@uid", userId.Value);
                        delGroups.ExecuteNonQuery();

                        string insertGroups = @"INSERT INTO UserGroups (userId, groupId)
                                        SELECT @uid, groupId FROM PendingUserGroups
                                        WHERE pendingUserId = @pid";
                        SqlCommand insGroups = new SqlCommand(insertGroups, conn, tran);
                        insGroups.Parameters.AddWithValue("@uid", userId.Value);
                        insGroups.Parameters.AddWithValue("@pid", pendingId);
                        insGroups.ExecuteNonQuery();
                    }
                    else if (actType == "DELETE" && userId.HasValue)
                    {
                        // SAFER: mark inactive instead of deleting
                        string deactivateQuery = @"UPDATE Users
                                           SET isActive = 0,
                                               updatedOn = GETDATE(),
                                               updatedBy = @updatedBy,
                                               checkerId = @checkerId
                                           WHERE id = @uid";
                        SqlCommand deactivateCmd = new SqlCommand(deactivateQuery, conn, tran);
                        deactivateCmd.Parameters.AddWithValue("@updatedBy", updatedBy ?? (object)DBNull.Value);
                        deactivateCmd.Parameters.AddWithValue("@checkerId", CurrentUser.UserId);
                        deactivateCmd.Parameters.AddWithValue("@uid", userId.Value);
                        deactivateCmd.ExecuteNonQuery();
                    }

                    // Cleanup pending records
                    SqlCommand delPUG = new SqlCommand("DELETE FROM PendingUserGroups WHERE pendingUserId=@id", conn, tran);
                    delPUG.Parameters.AddWithValue("@id", pendingId);
                    delPUG.ExecuteNonQuery();

                    SqlCommand delPU = new SqlCommand("DELETE FROM PendingUsers WHERE id=@id", conn, tran);
                    delPU.Parameters.AddWithValue("@id", pendingId);
                    delPU.ExecuteNonQuery();

                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                int id = (int)row.Cells["id"].Value;

                DialogResult confirm = MessageBox.Show(
                    "Are you sure you want to delete this record?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes) 
                {
                    try 
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            SqlTransaction transaction = conn.BeginTransaction();
                            try 
                            {
                                int originalCreatedBy = 0;
                                int usersRoleId = 0;
                                using (SqlCommand getCmd = new SqlCommand("SELECT createdBy, roleId FROM Users WHERE id=@id", conn, transaction))
                                {
                                    getCmd.Parameters.AddWithValue("@id", id);
                                    object result = getCmd.ExecuteScalar();
                                    using(SqlDataReader reader = getCmd.ExecuteReader())
    {
                                        if (reader.Read())
                                        {
                                            originalCreatedBy = Convert.ToInt32(reader["createdBy"]);
                                            usersRoleId = Convert.ToInt32(reader["roleId"]);
                                        }
                                    }
                                }
                                string query = @"INSERT INTO PendingUsers (userId, username, password, isActive, roleId, actionType, createdBy)
                                                OUTPUT INSERTED.id
                                                VALUES (@userId, @username, @password, @isActive, @roleId, 'DELETE', @createdBy)";
                                SqlCommand cmd = new SqlCommand(query, conn, transaction);
                                cmd.Parameters.AddWithValue("@userId", id);
                                cmd.Parameters.AddWithValue("@username", row.Cells["username"].Value.ToString());
                                cmd.Parameters.AddWithValue("@password", row.Cells["password"].Value.ToString());
                                cmd.Parameters.AddWithValue("@isActive", Convert.ToBoolean(row.Cells["isActive"].Value));
                                cmd.Parameters.AddWithValue("@roleId", usersRoleId);
                                cmd.Parameters.AddWithValue("@createdBy", originalCreatedBy);
                                int pendingUserID = (int) cmd.ExecuteScalar();

                                string insertGroups = @"INSERT INTO PendingUserGroups(pendingUserId, groupId)
                                                  SELECT @pendingUserID, groupId FROM UserGroups
                                                  WHERE userId = @userID";

                                SqlCommand cmdGroups = new SqlCommand(insertGroups, conn, transaction);
                                cmdGroups.Parameters.AddWithValue("@pendingUserID", pendingUserID);
                                cmdGroups.Parameters.AddWithValue("@userID", id);
                                cmdGroups.ExecuteNonQuery();

                                transaction.Commit();

                                MessageBox.Show("Delete request submitted for approval.", "Pending Approval", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show($"Transaction Error: {ex.Message}");
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Connection Error: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Dashboard welcome = new Dashboard();
            welcome.Show();
            this.Close();
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                int id = (int)row.Cells["id"].Value;
                string username = row.Cells["username"].Value.ToString();
                string password = row.Cells["password"].Value.ToString();
                bool isActive = Convert.ToBoolean(row.Cells["isActive"].Value);
                int roleId = Convert.ToInt32(row.Cells["roleId"].Value);
                int createdBy = (int)row.Cells["createdBy"].Value;

                string selectedFilter = cmbFilter.SelectedItem?.ToString();
                List<int> userGroupIds = new List<int>();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "";
                    if(selectedFilter == "Approved") { 
                        query = @"Select groupId from UserGroups Where userId = @userID";
                    }
                    else if (selectedFilter == "Pending" || selectedFilter == "Rejected")
                    {
                        query = @"Select groupId from PendingUserGroups Where pendingUserId = @userID";
                    }
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@userID", id);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    userGroupIds.Add(Convert.ToInt32(reader["groupId"]));
                                }
                            }
                        }
                }

                using (UserDetails details = new UserDetails(new SqlConnection(connectionString), id, username, password, isActive, roleId, userGroupIds))
                {
                    if (details.ShowDialog() == DialogResult.Yes)
                    {
                        DisplayData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a record to edit.");
            }
        }

    }
}

