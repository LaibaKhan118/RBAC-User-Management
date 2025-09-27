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
    public partial class RejectRemarks : Form
    {
        public string Remarks { get; private set; } = string.Empty;
        public RejectRemarks()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRemarks.Text))
            {
                MessageBox.Show("Remarks are required before rejecting.");
                return;
            }

            Remarks = txtRemarks.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
