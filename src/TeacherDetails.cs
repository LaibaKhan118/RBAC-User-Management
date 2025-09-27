using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace TeacherForm
{
    public partial class TeacherDetails : Form
    {
        private readonly SqlConnection conn;
        private readonly int? teacherId;

        public TeacherDetails(SqlConnection connection, int? id = null, string name = "", string address = "", int salary = 0)
        {
            InitializeComponent();
            conn = connection;
            teacherId = id;

            if (teacherId.HasValue)
            {
                txtName.Text = name;
                txtAddress.Text = address;
                txtSalary.Text = salary.ToString();
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                if (teacherId.HasValue) 
                {
                    string query = "UPDATE Teacher SET name=@name, address=@address, salary=@salary WHERE id=@id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@salary", int.Parse(txtSalary.Text));
                    cmd.Parameters.AddWithValue("@id", teacherId.Value);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Teacher updated successfully!");
                }
                else
                {
                    string query = "INSERT INTO Teacher (name, address, salary) VALUES (@name, @address, @salary)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@salary", int.Parse(txtSalary.Text));
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Teacher added successfully!");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
