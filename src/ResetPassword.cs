using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace TeacherForm
{
    public partial class ResetPassword : Form
    {
        private readonly SqlConnection conn;
        private readonly int userId;
        private readonly string username;
        private readonly string pass;

        public ResetPassword(int userId, string username, string pass, SqlConnection connection)
        {
            InitializeComponent();
            this.userId = userId;
            this.username = username;
            this.pass = pass;
            this.conn = connection;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string currPassword = txtCurrentPassword.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            if (string.IsNullOrEmpty(currPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (currPassword != pass)
            {
                MessageBox.Show("Current password is incorrect.");
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            try
            {
                conn.Open();
                string query = "UPDATE Users SET password = @password, isFirstLogin = 0 WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@password", newPassword);
                cmd.Parameters.AddWithValue("@id", userId);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Password reset successfully!");

                CurrentUser.UserId = userId;
                CurrentUser.Username = username;

                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Login loginForm = new Login();
            loginForm.Show();
        }

        private void ResetPassword_Load(object sender, EventArgs e)
        {

        }
    }
}
