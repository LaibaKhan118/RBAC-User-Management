using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace TeacherForm
{
    public partial class GroupList : Form
    {
        private readonly string connectionString =
            "Data Source=DESKTOP-D9AI616\\SQLEXPRESS;" +
            "Initial Catalog=School;" +
            "Integrated Security=True;" +
            "Encrypt=False;" +
            "TrustServerCertificate=True;";

        public GroupList()
        {
            InitializeComponent();
        }

        private void DisplayData()
        {
            SearchBox.Text = string.Empty;
            LoadGroups();
        }

        private void GroupList_Load(object sender, EventArgs e)
        {
            cmbFilter.Items.Clear();

            if (CurrentUser.HasPermission("GroupList", "View Approved"))
                cmbFilter.Items.Add("Approved");

            if (CurrentUser.HasPermission("GroupList", "View Pending"))
                cmbFilter.Items.Add("Pending");

            if (CurrentUser.HasPermission("GroupList", "View Rejected"))
                cmbFilter.Items.Add("Rejected");

            // Default selection
            if (cmbFilter.Items.Count > 0)
                cmbFilter.SelectedIndex = 0;
            else
                MessageBox.Show("You do not have permission to view any records in GroupList.");

            LoadGroups();

            btnDelete.Visible = CurrentUser.HasPermission("GroupList", "Delete");
            btnAdd.Visible = CurrentUser.HasPermission("GroupList", "Add");
            btnEdit.Visible = CurrentUser.HasPermission("GroupList", "Edit");
        }


        private void LoadGroups(string searchText = "")
        {
            string selectedFilter = cmbFilter.SelectedItem?.ToString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query;

                if (selectedFilter == "Approved")
                {
                    query = @"SELECT g.id, g.groupName, g.description,
                                     STRING_AGG(p.screenName + ':' + p.action, ', ') AS Permissions,
                                     g.createdOn, g.updatedOn, g.createdBy, g.checkerId
                              FROM Groups g
                              LEFT JOIN GroupPermissions gp ON g.id = gp.groupId
                              LEFT JOIN Permissions p ON p.id = gp.permissionId
                              WHERE (@search = '' 
                                     OR g.id = TRY_CAST(@search AS INT) 
                                     OR g.groupName LIKE @searchText)
                              GROUP BY g.id, g.groupName, g.description, g.createdOn, g.updatedOn, g.createdBy, g.checkerId";
                }
                else if (selectedFilter == "Pending")
                {
                    btnAdd.Visible = false;
                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                    query = @"SELECT pg.id, pg.groupId, pg.groupName, pg.description,
                                     STRING_AGG(p.screenName + ':' + p.action, ', ') AS Permissions, 
                                     pg.actionType, pg.status, pg.createdBy, pg.createdOn, pg.updatedBy, pg.updatedOn
                              FROM PendingGroups pg
                              LEFT JOIN PendingGroupPermissions pgp ON pg.id = pgp.pendingGroupId
                              LEFT JOIN Permissions p ON pgp.permissionId = p.id
                              WHERE pg.status = 'PENDING'
                              AND (@search = '' OR pg.id = TRY_CAST(@search AS INT) OR pg.groupName LIKE @searchText)
                              GROUP BY pg.id, pg.groupId, pg.groupName, pg.description, pg.actionType, pg.status,
                                       pg.createdBy, pg.createdOn, pg.updatedBy, pg.updatedOn";
                }
                else if (selectedFilter == "Rejected")
                {
                    btnAdd.Visible = false;
                    query = @"SELECT pg.id, pg.groupId, pg.groupName, pg.description,
                                     STRING_AGG(p.screenName + ':' + p.action, ', ') AS Permissions, 
                                     pg.actionType, pg.status, pg.createdBy, pg.createdOn, 
                                     pg.updatedBy, pg.updatedOn, pg.checkerRemarks
                              FROM PendingGroups pg
                              LEFT JOIN PendingGroupPermissions pgp ON pg.id = pgp.pendingGroupId
                              LEFT JOIN Permissions p ON pgp.permissionId = p.id
                              WHERE pg.status = 'REJECTED'
                              AND (@search = '' OR pg.id = TRY_CAST(@search AS INT) OR pg.groupName LIKE @searchText)
                              GROUP BY pg.id, pg.groupId, pg.groupName, pg.description, pg.actionType, pg.status,
                                       pg.createdBy, pg.createdOn, pg.updatedBy, pg.updatedOn, pg.checkerRemarks";
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
                    if (selectedFilter == "Rejected" && dataGridView1.Columns.Contains("checkerRemarks"))
                    {
                        dataGridView1.Columns["checkerRemarks"].HeaderText = "Checker Remarks";
                        dataGridView1.Columns["checkerRemarks"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
            }
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e) => LoadGroups();

        private void btnFind_Click(object sender, EventArgs e) => LoadGroups(SearchBox.Text.Trim());

        private void btnRefresh_Click(object sender, EventArgs e) => DisplayData();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (GroupsDetails details = new GroupsDetails(id: null, selectedFilter: "Approved", permissionIds: new List<int>(),
                                                             groupname: "", description: ""))
            {
                if (details.ShowDialog() == DialogResult.OK)
                {
                    DisplayData();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dataGridView1.SelectedRows[0];
            int id = Convert.ToInt32(row.Cells["id"].Value);
            string selectedFilter = cmbFilter.SelectedItem?.ToString();

            string groupName = row.Cells["groupName"].Value?.ToString() ?? string.Empty;
            string description = row.Cells["description"].Value?.ToString() ?? string.Empty;

            List<int> permissionIds = new List<int>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = selectedFilter == "Approved"
                    ? "SELECT permissionId FROM GroupPermissions WHERE groupId = @groupId"
                    : "SELECT permissionId FROM PendingGroupPermissions WHERE pendingGroupId = @pendingGroupId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (selectedFilter == "Approved")
                        cmd.Parameters.AddWithValue("@groupId", id);
                    else
                        cmd.Parameters.AddWithValue("@pendingGroupId", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            permissionIds.Add(Convert.ToInt32(reader["permissionId"]));
                        }
                    }
                }
            }

            using (GroupsDetails form = new GroupsDetails(id, selectedFilter, permissionIds, groupName, description))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadGroups();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            DataGridViewRow row = dataGridView1.SelectedRows[0];
            int id = (int)row.Cells["id"].Value;

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to delete this record?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();
                    try
                    {
                        int originalCreatedBy = 0;
                        using (SqlCommand getCmd = new SqlCommand("SELECT createdBy FROM Groups WHERE id=@id", conn, transaction))
                        {
                            getCmd.Parameters.AddWithValue("@id", id);
                            object result = getCmd.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                                originalCreatedBy = Convert.ToInt32(result);
                        }

                        string query = @"INSERT INTO PendingGroups (groupId, groupName, description, actionType, createdBy, status)
                                         OUTPUT INSERTED.id
                                         VALUES (@groupId, @groupName, @description, 'DELETE', @createdBy, 'Pending')";
                        SqlCommand cmd = new SqlCommand(query, conn, transaction);
                        cmd.Parameters.AddWithValue("@groupId", id);
                        cmd.Parameters.AddWithValue("@groupName", row.Cells["groupName"].Value.ToString());
                        cmd.Parameters.AddWithValue("@description", row.Cells["description"].Value.ToString());
                        cmd.Parameters.AddWithValue("@createdBy", originalCreatedBy);
                        int pendingGroupID = (int)cmd.ExecuteScalar();

                        string insertPermissions = @"INSERT INTO PendingGroupPermissions(pendingGroupID, permissionId)
                                                     SELECT @pendingGroupID, permissionId FROM GroupPermissions
                                                     WHERE groupId = @groupID";

                        SqlCommand cmdGroups = new SqlCommand(insertPermissions, conn, transaction);
                        cmdGroups.Parameters.AddWithValue("@pendingGroupID", pendingGroupID);
                        cmdGroups.Parameters.AddWithValue("@groupID", id);
                        cmdGroups.ExecuteNonQuery();

                        transaction.Commit();
                        MessageBox.Show("Delete request submitted for approval.", "Pending Approval", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Transaction Error: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection Error: {ex.Message}");
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
            string selectedFilter = (cmbFilter.SelectedItem ?? "").ToString().Trim();
            if (string.IsNullOrEmpty(selectedFilter))
            {
                MessageBox.Show("Please select a filter first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (selectedFilter.Equals("Approved", StringComparison.OrdinalIgnoreCase))
                {
                    int groupId = Convert.ToInt32(row.Cells["id"].Value);
                    string groupName = row.Cells["groupName"]?.Value?.ToString() ?? "";
                    string description = row.Cells["description"]?.Value?.ToString() ?? "";

                    var currentPerms = new List<int>();
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string permQuery = "SELECT permissionId FROM GroupPermissions WHERE groupId = @gid";
                        using (SqlCommand cmd = new SqlCommand(permQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@gid", groupId);
                            using (SqlDataReader r = cmd.ExecuteReader())
                            {
                                while (r.Read()) currentPerms.Add(r.GetInt32(0));
                            }
                        }
                    }

                    // For Approved view we pass old/new lists identical and actionType 'VIEW'
                    using (GroupReview reviewForm = new GroupReview(groupId, groupName, description, string.Empty, string.Empty, "VIEW", "Approved", string.Empty, currentPerms, currentPerms))
                    {
                        reviewForm.ShowDialog();
                    }

                    return;
                }
                
                int pendingId = Convert.ToInt32(row.Cells["id"].Value);
                string actionType = row.Cells["actionType"]?.Value?.ToString() ?? ""; 
                string newName = row.Cells["groupName"]?.Value?.ToString() ?? "";
                string newDesc = row.Cells["description"]?.Value?.ToString() ?? "";

                string oldName = string.Empty;
                string oldDesc = string.Empty;
                string checkerRemarks = string.Empty;
                var oldPermissions = new List<int>();
                var newPermissions = new List<int>();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    if (actionType.Equals("UPDATE", StringComparison.OrdinalIgnoreCase))
                    {
                        string oldQuery = @"SELECT g.groupName, g.description
                                    FROM Groups g
                                    INNER JOIN PendingGroups pg ON g.id = pg.groupId
                                    WHERE pg.id = @pid";
                        using (SqlCommand cmd = new SqlCommand(oldQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@pid", pendingId);
                            using (SqlDataReader r = cmd.ExecuteReader())
                            {
                                if (r.Read())
                                {
                                    oldName = r["groupName"]?.ToString() ?? "";
                                    oldDesc = r["description"]?.ToString() ?? "";
                                }
                            }
                        }

                        string oldPermQuery = @"SELECT gp.permissionId
                                        FROM GroupPermissions gp
                                        INNER JOIN PendingGroups pg ON gp.groupId = pg.groupId
                                        WHERE pg.id = @pid";
                        using (SqlCommand cmd = new SqlCommand(oldPermQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@pid", pendingId);
                            using (SqlDataReader r = cmd.ExecuteReader())
                            {
                                while (r.Read()) oldPermissions.Add(Convert.ToInt32(r["permissionId"]));
                            }
                        }
                    }

                    string newPermQuery = @"SELECT permissionId FROM PendingGroupPermissions WHERE pendingGroupId = @pid";
                    using (SqlCommand cmd = new SqlCommand(newPermQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@pid", pendingId);
                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            while (r.Read()) newPermissions.Add(Convert.ToInt32(r["permissionId"]));
                        }
                    }

                    if (selectedFilter.Equals("Rejected", StringComparison.OrdinalIgnoreCase))
                    {
                        string remarksQuery = "SELECT checkerRemarks FROM PendingGroups WHERE id = @pid";
                        using (SqlCommand cmd = new SqlCommand(remarksQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@pid", pendingId);
                            var res = cmd.ExecuteScalar();
                            checkerRemarks = res?.ToString() ?? "";
                        }
                    }
                }

                using (GroupReview reviewForm = new GroupReview(pendingId, newName, newDesc, oldName, oldDesc, actionType, selectedFilter, checkerRemarks, oldPermissions, newPermissions))
                {
                    var result = reviewForm.ShowDialog();
                    if (selectedFilter.Equals("Pending", StringComparison.OrdinalIgnoreCase))
                    {
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
                                            // Insert into GroupHistory
                                            string trackQuery = @"INSERT INTO GroupHistory (groupId, groupName, newGroupName, description, newDescription, actionType, approvedOn, createdBy, updatedBy, checkerId) OUTPUT INSERTED.id
                                              VALUES (@groupId, @groupName, @newGroupName, @description, @newDescription, 'UPDATE', GETDATE(), @createdBy, @updatedBy, @checkerId)";

                                            using (SqlCommand cmd = new SqlCommand(trackQuery, conn, tran))
                                            {
                                                cmd.Parameters.AddWithValue("@groupId", row.Cells["groupId"].Value);
                                                cmd.Parameters.AddWithValue("@groupName", oldName);
                                                cmd.Parameters.AddWithValue("@newGroupName", newName);
                                                cmd.Parameters.AddWithValue("@description", oldDesc);
                                                cmd.Parameters.AddWithValue("@newDescription", newDesc);
                                                cmd.Parameters.AddWithValue("@createdBy", row.Cells["createdBy"].Value);
                                                cmd.Parameters.AddWithValue("@updatedBy", row.Cells["updatedBy"].Value ?? DBNull.Value);
                                                cmd.Parameters.AddWithValue("@checkerId", CurrentUser.UserId);

                                                historyId = Convert.ToInt32(cmd.ExecuteScalar());
                                            }

                                            // Build sets for comparison
                                            var oldSet = new HashSet<int>(oldPermissions);
                                            var newSet = new HashSet<int>(newPermissions);

                                            // Common permissions
                                            foreach (var pid in oldSet.Intersect(newSet))
                                            {
                                                InsertPermissionHistory(conn, tran, historyId, pid, pid);
                                            }

                                            // Removed permissions (old only)
                                            foreach (var pid in oldSet.Except(newSet))
                                            {
                                                InsertPermissionHistory(conn, tran, historyId, pid, null);
                                            }

                                            // Added permissions (new only)
                                            foreach (var pid in newSet.Except(oldSet))
                                            {
                                                InsertPermissionHistory(conn, tran, historyId, null, pid);
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
                                            // Insert into GroupHistory
                                            string trackQuery = @"INSERT INTO GroupHistory (groupId, groupName, description, actionType, approvedOn, createdBy, checkerId) 
                                              OUTPUT INSERTED.id
                                              VALUES (@groupId, @groupName, @description, 'DELETE', GETDATE(), @createdBy, @checkerId)";

                                            using (SqlCommand cmd = new SqlCommand(trackQuery, conn, tran))
                                            {
                                                cmd.Parameters.AddWithValue("@groupId", row.Cells["groupId"].Value);
                                                cmd.Parameters.AddWithValue("@groupName", newName);
                                                cmd.Parameters.AddWithValue("@description", newDesc);
                                                cmd.Parameters.AddWithValue("@createdBy", row.Cells["createdBy"].Value);
                                                cmd.Parameters.AddWithValue("@updatedBy", row.Cells["updatedBy"].Value);
                                                cmd.Parameters.AddWithValue("@checkerId", CurrentUser.UserId);

                                                historyId = Convert.ToInt32(cmd.ExecuteScalar());
                                            }

                                            // Log all old permissions as deleted
                                            foreach (var pid in oldPermissions)
                                            {
                                                InsertPermissionHistory(conn, tran, historyId, pid, null);
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

                            ApprovePendingGroup(pendingId, actionType);
                            LoadGroups();
                        }

                        else if (result == DialogResult.No)
                        {
                            LoadGroups();
                        }
                    }
                    else
                    {
                        LoadGroups();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening record: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void InsertPermissionHistory(SqlConnection conn, SqlTransaction tran, int historyId, int? oldPerm, int? newPerm)
        {
            string permInsert = @"INSERT INTO GroupPermissionHistory (groupHistoryId, oldPermissionId, newPermissionId)
                          VALUES (@hid, @oldPid, @newPid)";
            using (SqlCommand cmd = new SqlCommand(permInsert, conn, tran))
            {
                cmd.Parameters.AddWithValue("@hid", historyId);
                cmd.Parameters.AddWithValue("@oldPid", (object?)oldPerm ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@newPid", (object?)newPerm ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }


        // Finalizes approval: applies changes from PendingGroups → Groups
        private void ApprovePendingGroup(int pendingId, string actionType)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    if (actionType == "INSERT")
                    {
                        string insertQuery = @"INSERT INTO Groups (groupName, description, createdBy, createdOn)
                                       SELECT groupName, description, createdBy, GETDATE()
                                       FROM PendingGroups WHERE id = @pid;
                                       SELECT SCOPE_IDENTITY();";
                        int newGroupId;
                        using (SqlCommand cmd = new SqlCommand(insertQuery, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@pid", pendingId);
                            newGroupId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        string insertPerms = @"INSERT INTO GroupPermissions (groupId, permissionId)
                                       SELECT @gid, permissionId
                                       FROM PendingGroupPermissions
                                       WHERE pendingGroupId = @pid";
                        using (SqlCommand cmd = new SqlCommand(insertPerms, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@gid", newGroupId);
                            cmd.Parameters.AddWithValue("@pid", pendingId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else if (actionType == "UPDATE")
                    {
                        string updateQuery = @"UPDATE g
                                       SET g.groupName = pg.groupName,
                                           g.description = pg.description,
                                           g.updatedBy = pg.createdBy,
                                           g.updatedOn = GETDATE()
                                       FROM Groups g
                                       INNER JOIN PendingGroups pg ON g.id = pg.groupId
                                       WHERE pg.id = @pid";
                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@pid", pendingId);
                            cmd.ExecuteNonQuery();
                        }

                        string deletePerms = @"DELETE gp
                                       FROM GroupPermissions gp
                                       INNER JOIN PendingGroups pg ON gp.groupId = pg.groupId
                                       WHERE pg.id = @pid";
                        using (SqlCommand cmd = new SqlCommand(deletePerms, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@pid", pendingId);
                            cmd.ExecuteNonQuery();
                        }

                        string insertPerms = @"INSERT INTO GroupPermissions (groupId, permissionId)
                                       SELECT pg.groupId, permissionId
                                       FROM PendingGroupPermissions
                                       INNER JOIN PendingGroups pg ON pg.id = pendingGroupId
                                       WHERE pendingGroupId = @pid";
                        using (SqlCommand cmd = new SqlCommand(insertPerms, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@pid", pendingId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else if(actionType == "DELETE")
                    {
                        string deletePerms = @"DELETE gp
                                       FROM GroupPermissions gp
                                       INNER JOIN PendingGroups pg ON gp.groupId = pg.groupId
                                       WHERE pg.id = @pid";
                        using (SqlCommand cmd = new SqlCommand(deletePerms, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@pid", pendingId);
                            cmd.ExecuteNonQuery();
                        }
                        string deleteGroup = @"DELETE g
                                       FROM Groups g
                                       INNER JOIN PendingGroups pg ON g.id = pg.groupId
                                       WHERE pg.id = @pid";
                        using (SqlCommand cmd = new SqlCommand(deleteGroup, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@pid", pendingId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    string approveQuery = @"UPDATE PendingGroups SET status = 'APPROVED', checkerId = @checkerId, updatedOn = GETDATE() WHERE id = @pid";
                    using (SqlCommand cmd = new SqlCommand(approveQuery, conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@pid", pendingId);
                        cmd.Parameters.AddWithValue("@checkerId", CurrentUser.UserId);
                        cmd.ExecuteNonQuery();
                    }

                    tran.Commit();
                    MessageBox.Show("Group approved successfully.");
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show($"Error approving record: {ex.Message}");
                }
            }
        }



        private List<int> GetPermissions(SqlConnection conn, int id, bool isPending)
        {
            List<int> perms = new List<int>();
            string query = isPending
                ? "SELECT permissionId FROM PendingGroupPermissions WHERE pendingGroupId=@id"
                : "SELECT permissionId FROM GroupPermissions WHERE groupId=@id";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            using (SqlDataReader r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    perms.Add(Convert.ToInt32(r["permissionId"]));
                }
            }
            return perms;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Dashboard welcome = new Dashboard();
            welcome.Show();
            this.Close();
        }
    }
}
