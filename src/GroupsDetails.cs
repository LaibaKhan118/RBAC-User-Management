using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace TeacherForm
{
    public partial class GroupsDetails : Form
    {
        private int? groupID; 
        private string filter; 
        private readonly string connectionString =
            "Data Source=DESKTOP-D9AI616\\SQLEXPRESS;" +
            "Initial Catalog=School;" +
            "Integrated Security=True;" +
            "Encrypt=False;" +
            "TrustServerCertificate=True;";

        public GroupsDetails(int? id = null, string selectedFilter = "Approved", List<int> permissionIds = null, string groupname = "", string description = "")
        {
            InitializeComponent();

            groupID = id;
            filter = selectedFilter;

            txtGroupName.Text = groupname;
            txtDescription.Text = description;

            LoadPermissions(permissionIds);
        }


        private void LoadPermissions(List<int> selectedPermissionIds = null)
        {
            treePermissions.Nodes.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT id, screenName, action FROM Permissions ORDER BY screenName, action";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Dictionary<string, TreeNode> screenNodes = new Dictionary<string, TreeNode>();

                        while (reader.Read())
                        {
                            int permId = reader.GetInt32(0);
                            string screen = reader.GetString(1);
                            string action = reader.GetString(2);

                            // Create parent node for screen if not exists
                            if (!screenNodes.ContainsKey(screen))
                            {
                                TreeNode parent = new TreeNode(screen);
                                treePermissions.Nodes.Add(parent);
                                screenNodes[screen] = parent;
                            }

                            // Add child action node
                            TreeNode child = new TreeNode(action)
                            {
                                Tag = permId
                            };

                            // Check if this permission should be pre-selected
                            if (selectedPermissionIds != null && selectedPermissionIds.Contains(permId))
                            {
                                child.Checked = true;
                            }

                            screenNodes[screen].Nodes.Add(child);
                        }
                    }
                }
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGroupName.Text) || string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Please fill all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    int pendingGroupId;

                    if (groupID.HasValue && filter == "Approved")
                    {
                        // Editing approved group → create new Pending record (UPDATE request)
                        string query = @"INSERT INTO PendingGroups 
                                         (groupId, groupName, description, actionType, status, createdBy, createdOn)
                                         OUTPUT INSERTED.id
                                         VALUES (@gid, @groupname, @desc, 'UPDATE', 'Pending', @createdBy, GETDATE())";
                        SqlCommand cmd = new SqlCommand(query, conn, tran);
                        cmd.Parameters.AddWithValue("@gid", groupID.Value);
                        cmd.Parameters.AddWithValue("@groupname", txtGroupName.Text.Trim());
                        cmd.Parameters.AddWithValue("@desc", txtDescription.Text.Trim());
                        cmd.Parameters.AddWithValue("@createdBy", CurrentUser.UserId);

                        pendingGroupId = (int)cmd.ExecuteScalar();
                    }
                    else if (!groupID.HasValue)
                    {
                        // New group → create Pending record (INSERT request)
                        string query = @"INSERT INTO PendingGroups 
                                         (groupName, description, actionType, status, createdBy, createdOn)
                                         OUTPUT INSERTED.id
                                         VALUES (@groupname, @desc, 'INSERT', 'Pending', @createdBy, GETDATE())";
                        SqlCommand cmd = new SqlCommand(query, conn, tran);
                        cmd.Parameters.AddWithValue("@groupname", txtGroupName.Text.Trim());
                        cmd.Parameters.AddWithValue("@desc", txtDescription.Text.Trim());
                        cmd.Parameters.AddWithValue("@createdBy", CurrentUser.UserId);

                        pendingGroupId = (int)cmd.ExecuteScalar();
                    }
                    else
                    {
                        // Editing rejected record → just update existing PendingGroups row and set status back to Pending
                        string query = @"UPDATE PendingGroups 
                                         SET groupName=@groupname, description=@desc, status='Pending', updatedOn=GETDATE()
                                         WHERE id=@pid";
                        SqlCommand cmd = new SqlCommand(query, conn, tran);
                        cmd.Parameters.AddWithValue("@pid", groupID.Value);
                        cmd.Parameters.AddWithValue("@groupname", txtGroupName.Text.Trim());
                        cmd.Parameters.AddWithValue("@desc", txtDescription.Text.Trim());
                        cmd.ExecuteNonQuery();

                        pendingGroupId = groupID.Value;
                    }

                    // Reset & insert permissions into PendingGroupPermissions
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM PendingGroupPermissions WHERE pendingGroupId=@pid", conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@pid", pendingGroupId);
                        cmd.ExecuteNonQuery();
                    }

                    foreach (int permId in GetSelectedPermissions())
                    {
                        SqlCommand insertCmd = new SqlCommand(
                            "INSERT INTO PendingGroupPermissions (pendingGroupId, permissionId) VALUES (@pid, @permId)",
                            conn, tran);
                        insertCmd.Parameters.AddWithValue("@pid", pendingGroupId);
                        insertCmd.Parameters.AddWithValue("@permId", permId);
                        insertCmd.ExecuteNonQuery();
                    }

                    tran.Commit();
                    MessageBox.Show("Group request sent for approval!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private class PermissionItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public override string ToString() => Name;
        }

        private List<int> GetSelectedPermissions()
        {
            List<int> selected = new List<int>();

            foreach (TreeNode screenNode in treePermissions.Nodes)
            {
                foreach (TreeNode actionNode in screenNode.Nodes)
                {
                    if (actionNode.Checked && actionNode.Tag is int permId)
                    {
                        selected.Add(permId);
                    }
                }
            }

            return selected;
        }

    }
}
