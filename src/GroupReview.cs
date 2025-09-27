using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace TeacherForm
{
    public partial class GroupReview : Form
    {
        private readonly int pendingId;
        private readonly List<int> newPerms;
        private readonly List<int> oldPerms;
        private readonly string actionType;
        private readonly string reviewMode;

        private readonly string connectionString =
            "Data Source=DESKTOP-D9AI616\\SQLEXPRESS;" +
            "Initial Catalog=School;" +
            "Integrated Security=True;" +
            "Encrypt=False;" +
            "TrustServerCertificate=True;";

        public GroupReview(int pid, string newName, string newDesc, string oldName, string oldDesc, string action, string filter, string checkerRemarks, List<int> oldPermissions, List<int> newPermissions)
        {
            InitializeComponent();

            pendingId = pid;
            newPerms = newPermissions ?? new List<int>();
            oldPerms = oldPermissions ?? new List<int>();
            actionType = action;
            reviewMode = filter;

            txtGroupName.Text = newName;
            txtDescription.Text = newDesc;

            txtGroupName.ReadOnly = true;
            txtDescription.ReadOnly = true;

            if (!string.IsNullOrEmpty(action))
            {
                lblAction.Visible = true;
                lblActionTitle.Visible = true;
                lblAction.Text = action;
            }
            else
            {
                lblAction.Visible = false;
                lblActionTitle.Visible = false;
            }
            if (reviewMode == "Rejected")
            {
                lblRemarks.Visible = true;
                txtRemarks.Visible = true;
                txtRemarks.Text = checkerRemarks;
                txtRemarks.ReadOnly = true;

                btnApprove.Visible = false;
                btnReject.Visible = false;
                btnCancel.Visible = true;
            }
            else if (reviewMode == "Pending")
            {
                lblRemarks.Visible = false;
                txtRemarks.Visible = false;
                btnCancel.Visible = true;
                btnApprove.Visible = CurrentUser.IsChecker;
                btnReject.Visible = CurrentUser.IsChecker;
            }
            else
            {
                lblRemarks.Visible = false;
                txtRemarks.Visible = false;
                btnApprove.Visible = false;
                btnReject.Visible = false;
                btnCancel.Visible = true;
            }

            if (action == "UPDATE")
            {
                if (!string.Equals(newName, oldName, StringComparison.OrdinalIgnoreCase))
                {
                    txtGroupName.BackColor = Color.LightYellow;
                    lblOldName.Text = $"Old: {oldName}";
                    lblOldName.Visible = true;
                }
                if (!string.Equals(newDesc, oldDesc, StringComparison.OrdinalIgnoreCase))
                {
                    txtDescription.BackColor = Color.LightYellow;
                    lblOldDesc.Text = $"Old: {oldDesc}";
                    lblOldDesc.Visible = true;
                }
            }
            lblAction.Text = $"{action}";

            LoadPermissionsForReview(oldPerms, newPerms);
        }


        private void LoadPermissionsForReview(List<int> oldPermissionIds, List<int> newPermissionIds)
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

                            if (!screenNodes.ContainsKey(screen))
                            {
                                TreeNode parent = new TreeNode(screen);
                                screenNodes[screen] = parent;
                                treePermissions.Nodes.Add(parent);
                            }

                            bool oldHas = oldPermissionIds.Contains(permId);
                            bool newHas = newPermissionIds.Contains(permId);

                            TreeNode child = new TreeNode(action)
                            {
                                Tag = permId,
                                Checked = newHas
                            };

                            if (oldHas != newHas)
                            {
                                child.BackColor = Color.LightYellow;
                                child.Text += $" (Old: {(oldHas ? "Yes" : "No")} → New: {(newHas ? "Yes" : "No")})";
                            }

                            screenNodes[screen].Nodes.Add(child);
                        }
                    }
                }
            }

            treePermissions.ExpandAll();
            treePermissions.Scrollable = true;
        }
        private void GroupReview_Load(object sender, EventArgs e)
        {
            treePermissions.BeforeCheck += TreePermissions_BeforeCheck;
        }

        private void TreePermissions_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            e.Cancel = true;
        }
        private void btnApprove_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            using (RejectRemarks remarksForm = new RejectRemarks())
            {
                if (remarksForm.ShowDialog() == DialogResult.OK)
                {
                    if (string.IsNullOrWhiteSpace(remarksForm.Remarks))
                    {
                        MessageBox.Show("Remarks are required when rejecting.");
                        return;
                    }

                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            string query = @"UPDATE PendingGroups
                                             SET status = 'REJECTED',
                                                 checkerId = @checkerId,
                                                 checkerRemarks = @remarks,
                                                 updatedOn = GETDATE()
                                             WHERE id = @id";

                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id", pendingId);
                                cmd.Parameters.AddWithValue("@remarks", remarksForm.Remarks);
                                cmd.Parameters.AddWithValue("@checkerId", CurrentUser.UserId);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Record rejected successfully.");
                        this.DialogResult = DialogResult.No;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error rejecting record: {ex.Message}");
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
