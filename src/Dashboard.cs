using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeacherForm
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnTeacherList_Click(object sender, EventArgs e)
        {
            TeacherList teacherList = new TeacherList();
            teacherList.Show();
            this.Hide();
        }
        private void btnUserList_Click(object sender, EventArgs e)
        {
            UserList userList = new UserList();
            userList.Show();
            this.Hide();
        }
        private void btnGroupList_Click(object sender, EventArgs e)
        {
            GroupList groupList = new GroupList();
            groupList.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            CurrentUser.Clear();
            Login loginForm = new Login();
            loginForm.Show();
            this.Close();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            btnTeacherList.Visible = CurrentUser.HasPermission("TeacherList", "View");
            btnUserList.Visible = CurrentUser.HasPermission("UserList", "View");
            btnGroupList.Visible = CurrentUser.HasPermission("GroupList", "View");
        }

    }
}
