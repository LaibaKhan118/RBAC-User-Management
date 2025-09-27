using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace TeacherForm
{
    public partial class Login : Form
    {
        private readonly string connectionString =
            "Data Source=DESKTOP-D9AI616\\SQLEXPRESS;" +
            "Initial Catalog=School;" +
            "Integrated Security=True;" +
            "Encrypt=False;" +
            "TrustServerCertificate=True;";

        public Login()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Updated query to include roleName from Roles
                    string query = @"
                        SELECT u.id, u.username, u.password, u.isActive, u.failedAttempts,
                               u.roleId, r.roleName, u.isFirstLogin
                        FROM Users u
                        INNER JOIN Roles r ON u.roleId = r.id
                        WHERE u.username = @username";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        bool isActive = Convert.ToBoolean(reader["isActive"]);
                        int failedAttempts = Convert.ToInt32(reader["failedAttempts"]);
                        string dbPassword = reader["password"].ToString();
                        int userId = Convert.ToInt32(reader["id"]);
                        int roleId = Convert.ToInt32(reader["roleId"]);
                        string roleName = reader["roleName"].ToString();
                        bool isFirstLogin = Convert.ToBoolean(reader["isFirstLogin"]);

                        if (!isActive)
                        {
                            MessageBox.Show("Your account is inactive. Contact Admin.");
                            return;
                        }

                        if (dbPassword == password)
                        {
                            // Reset failed attempts
                            reader.Close();
                            SqlCommand resetCmd = new SqlCommand(
                                "UPDATE Users SET failedAttempts = 0 WHERE id = @id", conn);
                            resetCmd.Parameters.AddWithValue("@id", userId);
                            resetCmd.ExecuteNonQuery();

                            // Load groups
                            List<string> groups = new List<string>();
                            string groupQuery = @"SELECT g.groupname
                                                FROM UserGroups ug
                                                INNER JOIN Groups g ON g.id = ug.groupId
                                                WHERE ug.userId = @userId";

                            using (SqlCommand GroupCmd = new SqlCommand(groupQuery, conn))
                            {
                                GroupCmd.Parameters.AddWithValue("@userId", userId);
                                SqlDataReader GroupReader = GroupCmd.ExecuteReader();
                                while (GroupReader.Read())
                                {
                                    groups.Add(GroupReader["groupname"].ToString());
                                }
                                GroupReader.Close();
                            }

                            // Load permissions
                            List<string> permissions = new List<string>();
                            string permQuery = @"SELECT p.screenName + ':' + p.action AS Permission
                                                FROM UserGroups ug
                                                INNER JOIN GroupPermissions gp ON ug.groupId = gp.groupId
                                                INNER JOIN Permissions p ON gp.permissionId = p.id
                                                WHERE ug.userId = @userId";

                            using (SqlCommand permCmd = new SqlCommand(permQuery, conn))
                            {
                                permCmd.Parameters.AddWithValue("@userId", userId);
                                SqlDataReader permReader = permCmd.ExecuteReader();
                                while (permReader.Read())
                                {
                                    permissions.Add(permReader["Permission"].ToString());
                                }
                                permReader.Close();
                            }

                            // ✅ Set CurrentUser
                            CurrentUser.UserId = userId;
                            CurrentUser.Username = username;
                            CurrentUser.IsActive = isActive;
                            CurrentUser.RoleId = roleId;
                            CurrentUser.RoleName = roleName;   // <-- NEW
                            CurrentUser.Groups = groups;
                            CurrentUser.Permissions = permissions;

                            MessageBox.Show("Login successful!");

                            if (isFirstLogin)
                            {
                                conn.Close();
                                ResetPassword resetForm = new ResetPassword(userId, username, password, conn);
                                this.Hide();
                                resetForm.ShowDialog();
                            }
                            else
                            {
                                Dashboard welcomepage = new Dashboard();
                                welcomepage.Show();
                                this.Hide();
                            }
                        }
                        else
                        {
                            reader.Close();
                            failedAttempts++;

                            if (failedAttempts >= 3)
                            {
                                SqlCommand deactivateCmd = new SqlCommand(
                                    "UPDATE Users SET isActive = 0 WHERE id = @id", conn);
                                deactivateCmd.Parameters.AddWithValue("@id", userId);
                                deactivateCmd.ExecuteNonQuery();
                                MessageBox.Show("Account locked after 3 failed attempts.");
                                CurrentUser.IsActive = false;
                            }
                            else
                            {
                                SqlCommand updateAttemptsCmd = new SqlCommand(
                                    "UPDATE Users SET failedAttempts = @attempts WHERE id = @id", conn);
                                updateAttemptsCmd.Parameters.AddWithValue("@attempts", failedAttempts);
                                updateAttemptsCmd.Parameters.AddWithValue("@id", userId);
                                updateAttemptsCmd.ExecuteNonQuery();

                                MessageBox.Show($"Incorrect password. {3 - failedAttempts} attempts left.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("User not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
