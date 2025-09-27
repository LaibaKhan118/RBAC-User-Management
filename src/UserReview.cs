using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TeacherForm
{
    public partial class UserReview : Form
    {
        private int pendingId;
        private int userId;
        private string actionType;
        private string filter;
        private string remarks;
        private List<int> oldGroups;
        private List<int> newGroups;

        private string oldUsername;
        private string oldPassword;
        private int oldRoleId;
        private bool oldIsActive;

        private readonly string connectionString =
            "Data Source=DESKTOP-D9AI616\\SQLEXPRESS;" +
            "Initial Catalog=School;" +
            "Integrated Security=True;" +
            "Encrypt=False;" +
            "TrustServerCertificate=True;";

        public UserReview(int pid, int uid, string username, string password, int roleId, bool isActive, string action, string currentFilter, string rejRemarks, List<int> oldGrp, List<int> newGrp, string prevUsername = null, string prevPassword = null,int prevRoleId = 0, bool prevIsActive = false)
        {
            InitializeComponent();

            pendingId = pid;
            userId = uid;
            actionType = action;
            filter = currentFilter;
            remarks = rejRemarks;
            oldGroups = oldGrp;
            newGroups = newGrp;

            oldUsername = prevUsername;
            oldPassword = prevPassword;
            oldRoleId = prevRoleId;
            oldIsActive = prevIsActive;

            txtUsername.Text = username;
            txtPassword.Text = password;
            txtRole.Text = GetRole(roleId);
            chkIsActive.Checked = isActive;

            txtUsername.ReadOnly = true;
            txtPassword.ReadOnly = true;
            txtRole.ReadOnly = true;
            chkIsActive.Enabled = false;

            lblAction.Text = actionType;
            if (string.IsNullOrEmpty(actionType))
            {
                lblActionTitle.Visible = false;
                lblAction.Visible = false;
            }

            if ((filter == "Pending" || filter == "Rejected") && actionType == "UPDATE")
            {
                HighlightDifferences(username, password, roleId, isActive);
            }

            if (filter == "Rejected")
            {
                lblRemarks.Visible = true;
                txtRemarks.Visible = true;
                txtRemarks.Text = remarks;
                txtRemarks.ReadOnly = true;
            }
            else
            {
                lblRemarks.Visible = false;
                txtRemarks.Visible = false;
            }

            if (filter == "Approved")
            {
                lblOldActive.Visible = false;
                lblOldName.Visible = false;
                lblOldPass.Visible = false;
                lblOldRole.Visible = false;
                btnApprove.Visible = false;
                btnReject.Visible = false;
            }

            LoadGroupsForReview(filter, actionType);
        }

        private void HighlightDifferences(string newName, string newPass, int newRole, bool newActive)
        {
            if (oldUsername != null && newName != oldUsername)
            {
                txtUsername.BackColor = Color.LightYellow;
                lblOldName.Text = $"Old: {oldUsername}";
                lblOldName.Visible = true;
            }
            if (oldPassword != null && newPass != oldPassword)
            {
                txtPassword.BackColor = Color.LightYellow;
                lblOldPass.Text = $"Old: {oldPassword}";
                lblOldPass.Visible = true;
            }
            if (newRole != oldRoleId)
            {
                txtRole.BackColor = Color.LightYellow;
                lblOldRole.Text = $"Old: {oldRoleId}";
                lblOldRole.Visible = true;
            }
            if (newActive != oldIsActive)
            {
                chkIsActive.BackColor = Color.LightYellow;
                lblOldActive.Text = $"Old: {(oldIsActive ? "Active" : "Inactive")}";
                lblOldActive.Visible = true;
            }
        }

        private string GetRole(int id)
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT roleName FROM Roles WHERE id=@ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    object result = cmd.ExecuteScalar();
                    return ((result != null) ? result.ToString(): $"Unknown Type ({id})");
                }
            }
        }
        private void LoadGroupsForReview(string filter, string actionType)
        {
            chkListGroups.Items.Clear();
            List<GroupItem> groupItems = new List<GroupItem>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT id, groupName FROM Groups ORDER BY groupName";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int gid = reader.GetInt32(0);
                            string gname = reader.GetString(1);

                            bool oldHas = oldGroups.Contains(gid);
                            bool newHas = newGroups.Contains(gid);

                            string text = gname;
                            if ((filter == "Pending" || filter == "Rejected")
                                && actionType == "UPDATE"
                                && oldHas != newHas)
                            {
                                text += $" (Old: {(oldHas ? "Yes" : "No")} → New: {(newHas ? "Yes" : "No")})";
                            }

                            groupItems.Add(new GroupItem
                            {
                                Id = gid,
                                Name = text,
                                OldHas = oldHas,
                                NewHas = newHas
                            });
                        }
                    }
                }
            }

            foreach (var item in groupItems)
            {
                int index = chkListGroups.Items.Add(item);
                chkListGroups.SetItemChecked(index, item.NewHas);
            }

            chkListGroups.Enabled = false;

            if ((filter == "Pending" || filter == "Rejected") && actionType == "UPDATE")
                chkListGroups.BackColor = Color.LightYellow;
            else
                chkListGroups.BackColor = Color.White;
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
                            string query = @"UPDATE PendingUsers 
                                             SET status = 'REJECTED', checkerId = @checkerId, checkerRemarks = @remarks, 
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

        private class GroupItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool OldHas { get; set; }
            public bool NewHas { get; set; }
            public override string ToString() => Name;
        }
    }
}
