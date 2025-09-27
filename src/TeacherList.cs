using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace TeacherForm
{
    public partial class TeacherList : Form
    {
        private string connectionString =
            "Data Source=DESKTOP-D9AI616\\SQLEXPRESS;" +
            "Initial Catalog=School;" +
            "Integrated Security=True;" +
            "Encrypt=False;" +
            "TrustServerCertificate=True;";

        public TeacherList()
        {
            InitializeComponent();
        }

        private void TeacherList_Load(object sender, EventArgs e)
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

            
            DisplayData();
            Delete.Visible = CurrentUser.HasPermission("TeacherList", "Delete");
            Add.Visible = CurrentUser.HasPermission("TeacherList", "Add");
            btnEdit.Visible = CurrentUser.HasPermission("TeacherList", "Edit");
        }

        private void ShowAll_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Teacher WHERE id = (TRY_CAST(@search AS INT)) OR (name LIKE @name)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@search", search.Text);
                    cmd.Parameters.AddWithValue("@name", "%" + search.Text + "%");

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                int id = (int)row.Cells["id"].Value;

                DialogResult confirm = MessageBox.Show(
                    "Are you sure you want to delete this teacher?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            string query = "DELETE FROM Teacher WHERE id=@id";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id", id);
                                conn.Open();
                                cmd.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Teacher deleted successfully!");
                        DisplayData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a teacher to delete.");
            }
        }
        
        private void Add_Click(object sender, EventArgs e)
        {
            TeacherDetails details = new TeacherDetails(new SqlConnection(connectionString));

            if (details.ShowDialog() == DialogResult.OK)
            {
                DisplayData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                int id = (int)row.Cells["id"].Value;
                string name = row.Cells["name"].Value.ToString();
                string address = row.Cells["address"].Value.ToString();
                int salary = (int)row.Cells["salary"].Value;

                TeacherDetails details = new TeacherDetails(new SqlConnection(connectionString), id, name, address, salary);

                if (details.ShowDialog() == DialogResult.OK)
                {
                    DisplayData();
                }
            }
            else
            {
                MessageBox.Show("Please select a record to edit.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Dashboard welcome = new Dashboard();
            welcome.Show();
            this.Close();
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            using (UserDetails userForm = new UserDetails(new SqlConnection(connectionString)))
            {
                if (userForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("User list updated!");
                }
            }
        }

        private void LoadTeachers(string searchText = "")
        {
            string filter = cmbFilter.SelectedItem.ToString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query;

                if (filter == "Approved")
                {
                    query = "SELECT * FROM Teacher WHERE status='APPROVED' AND (@search = '' OR pg.id = TRY_CAST(@search AS INT) OR pg.groupName LIKE @searchText)";
                }
                else if (filter == "Pending")
                {
                    Add.Visible = false;
                    btnEdit.Visible = false;
                    Delete.Visible = false;
                    query = "SELECT * FROM Teacher WHERE status='PENDING' AND (@search = '' OR pg.id = TRY_CAST(@search AS INT) OR pg.groupName LIKE @searchText)";
                }
                else if (filter == "Rejected")
                {
                    Add.Visible = false;
                    query = "SELECT * FROM Teacher WHERE status='REJECTED' AND (@search = '' OR pg.id = TRY_CAST(@search AS INT) OR pg.groupName LIKE @searchText)";
                }
                else
                {
                    query = "SELECT * FROM Teacher";
                }
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@search", searchText);
                    cmd.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;

                    if (filter == "Rejected" && dataGridView1.Columns.Contains("checkerRemarks"))
                    {
                        dataGridView1.Columns["checkerRemarks"].HeaderText = "Checker Remarks";
                        dataGridView1.Columns["checkerRemarks"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
            }
        }
        private void DisplayData()
        {
            search.Text = string.Empty;
            LoadTeachers(search.Text);
        }
        
    }
}
