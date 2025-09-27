namespace TeacherForm
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnTeacherList = new Button();
            btnUserList = new Button();
            btnGroupList = new Button();
            btnLogout = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(132, 64);
            label1.Name = "label1";
            label1.Size = new Size(109, 25);
            label1.TabIndex = 0;
            label1.Text = "Dashboard";
            // 
            // btnTeacherList
            // 
            btnTeacherList.Location = new Point(13, 3);
            btnTeacherList.Name = "btnTeacherList";
            btnTeacherList.Size = new Size(182, 38);
            btnTeacherList.TabIndex = 1;
            btnTeacherList.Text = "Teacher List";
            btnTeacherList.UseVisualStyleBackColor = true;
            btnTeacherList.Click += btnTeacherList_Click;
            // 
            // btnUserList
            // 
            btnUserList.Location = new Point(13, 47);
            btnUserList.Name = "btnUserList";
            btnUserList.Size = new Size(182, 38);
            btnUserList.TabIndex = 2;
            btnUserList.Text = "User List";
            btnUserList.UseVisualStyleBackColor = true;
            btnUserList.Click += btnUserList_Click;
            // 
            // btnGroupList
            // 
            btnGroupList.Location = new Point(13, 91);
            btnGroupList.Name = "btnGroupList";
            btnGroupList.Size = new Size(182, 38);
            btnGroupList.TabIndex = 3;
            btnGroupList.Text = "Group List";
            btnGroupList.UseVisualStyleBackColor = true;
            btnGroupList.Click += btnGroupList_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Red;
            btnLogout.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = SystemColors.Control;
            btnLogout.Location = new Point(253, 377);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(110, 38);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(btnTeacherList);
            flowLayoutPanel1.Controls.Add(btnUserList);
            flowLayoutPanel1.Controls.Add(btnGroupList);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(81, 116);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(10, 0, 10, 10);
            flowLayoutPanel1.Size = new Size(215, 234);
            flowLayoutPanel1.TabIndex = 6;
            flowLayoutPanel1.WrapContents = false;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(385, 439);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(btnLogout);
            Controls.Add(label1);
            Name = "Dashboard";
            Text = "Dashboard";
            Load += Dashboard_Load;
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnTeacherList;
        private Button btnUserList;
        private Button btnGroupList;
        private Button btnLogout;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}