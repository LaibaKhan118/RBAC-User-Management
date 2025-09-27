namespace TeacherForm
{
    partial class UserReview
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
            label2 = new Label();
            label3 = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            label4 = new Label();
            label5 = new Label();
            chkIsActive = new CheckBox();
            chkListGroups = new CheckedListBox();
            lable5 = new Label();
            lblOldName = new Label();
            lblOldRole = new Label();
            lblOldActive = new Label();
            btnApprove = new Button();
            btnReject = new Button();
            btnCancel = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            txtRole = new TextBox();
            flowLayoutPanel3 = new FlowLayoutPanel();
            flowLayoutPanel4 = new FlowLayoutPanel();
            flowLayoutPanel5 = new FlowLayoutPanel();
            flowLayoutPanel6 = new FlowLayoutPanel();
            flowLayoutPanel7 = new FlowLayoutPanel();
            flowLayoutPanel9 = new FlowLayoutPanel();
            lblActionTitle = new Label();
            lblAction = new Label();
            lblOldPass = new Label();
            flowLayoutPanel8 = new FlowLayoutPanel();
            lblRemarks = new Label();
            txtRemarks = new TextBox();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            flowLayoutPanel5.SuspendLayout();
            flowLayoutPanel6.SuspendLayout();
            flowLayoutPanel7.SuspendLayout();
            flowLayoutPanel9.SuspendLayout();
            flowLayoutPanel8.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(134, 47);
            label1.Name = "label1";
            label1.Size = new Size(119, 25);
            label1.TabIndex = 0;
            label1.Text = "User Review";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 1;
            label2.Text = "Username:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 2;
            label3.Text = "Password:";
            // 
            // txtUsername
            // 
            txtUsername.Enabled = false;
            txtUsername.Location = new Point(79, 0);
            txtUsername.Margin = new Padding(10, 0, 0, 0);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Username";
            txtUsername.ReadOnly = true;
            txtUsername.Size = new Size(213, 23);
            txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Enabled = false;
            txtPassword.Location = new Point(78, 0);
            txtPassword.Margin = new Padding(12, 0, 0, 0);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Password";
            txtPassword.ReadOnly = true;
            txtPassword.Size = new Size(213, 23);
            txtPassword.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 5;
            label4.Text = "Group(s):";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(68, 15);
            label5.TabIndex = 7;
            label5.Text = "User Status:";
            // 
            // chkIsActive
            // 
            chkIsActive.AutoSize = true;
            chkIsActive.Enabled = false;
            chkIsActive.Location = new Point(82, 0);
            chkIsActive.Margin = new Padding(8, 0, 0, 0);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(59, 19);
            chkIsActive.TabIndex = 8;
            chkIsActive.Text = "Active";
            chkIsActive.UseVisualStyleBackColor = true;
            // 
            // chkListGroups
            // 
            chkListGroups.Enabled = false;
            chkListGroups.FormattingEnabled = true;
            chkListGroups.Location = new Point(80, 0);
            chkListGroups.Margin = new Padding(18, 0, 0, 0);
            chkListGroups.Name = "chkListGroups";
            chkListGroups.Size = new Size(211, 112);
            chkListGroups.TabIndex = 12;
            // 
            // lable5
            // 
            lable5.AutoSize = true;
            lable5.Location = new Point(3, 0);
            lable5.Name = "lable5";
            lable5.Size = new Size(61, 15);
            lable5.TabIndex = 14;
            lable5.Text = "User Type:";
            // 
            // lblOldName
            // 
            lblOldName.AutoSize = true;
            lblOldName.Font = new Font("Segoe UI", 8F);
            lblOldName.ForeColor = SystemColors.ControlDarkDark;
            lblOldName.Location = new Point(85, 56);
            lblOldName.Margin = new Padding(85, 0, 3, 10);
            lblOldName.Name = "lblOldName";
            lblOldName.Size = new Size(36, 13);
            lblOldName.TabIndex = 15;
            lblOldName.Text = "Old: -";
            // 
            // lblOldRole
            // 
            lblOldRole.AutoSize = true;
            lblOldRole.Font = new Font("Segoe UI", 8F);
            lblOldRole.ForeColor = SystemColors.ControlDarkDark;
            lblOldRole.Location = new Point(85, 164);
            lblOldRole.Margin = new Padding(85, 0, 3, 10);
            lblOldRole.Name = "lblOldRole";
            lblOldRole.Size = new Size(36, 13);
            lblOldRole.TabIndex = 16;
            lblOldRole.Text = "Old: -";
            // 
            // lblOldActive
            // 
            lblOldActive.AutoSize = true;
            lblOldActive.Font = new Font("Segoe UI", 8F);
            lblOldActive.ForeColor = SystemColors.ControlDarkDark;
            lblOldActive.Location = new Point(85, 339);
            lblOldActive.Margin = new Padding(85, 0, 3, 10);
            lblOldActive.Name = "lblOldActive";
            lblOldActive.Size = new Size(36, 13);
            lblOldActive.TabIndex = 17;
            lblOldActive.Text = "Old: -";
            // 
            // btnApprove
            // 
            btnApprove.BackColor = Color.Green;
            btnApprove.ForeColor = SystemColors.Control;
            btnApprove.Location = new Point(3, 3);
            btnApprove.Margin = new Padding(3, 3, 15, 3);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(96, 31);
            btnApprove.TabIndex = 34;
            btnApprove.Text = "Approve";
            btnApprove.UseVisualStyleBackColor = false;
            btnApprove.Click += btnApprove_Click;
            // 
            // btnReject
            // 
            btnReject.BackColor = Color.Red;
            btnReject.ForeColor = SystemColors.Control;
            btnReject.Location = new Point(117, 3);
            btnReject.Margin = new Padding(3, 3, 15, 3);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(96, 31);
            btnReject.TabIndex = 35;
            btnReject.Text = "Reject";
            btnReject.UseVisualStyleBackColor = false;
            btnReject.Click += btnReject_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(231, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(96, 31);
            btnCancel.TabIndex = 33;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(txtUsername);
            flowLayoutPanel1.Location = new Point(0, 28);
            flowLayoutPanel1.Margin = new Padding(0, 0, 0, 5);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(292, 23);
            flowLayoutPanel1.TabIndex = 36;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel2.Controls.Add(label3);
            flowLayoutPanel2.Controls.Add(txtPassword);
            flowLayoutPanel2.Location = new Point(0, 79);
            flowLayoutPanel2.Margin = new Padding(0, 0, 0, 10);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(291, 23);
            flowLayoutPanel2.TabIndex = 37;
            // 
            // txtRole
            // 
            txtRole.Enabled = false;
            txtRole.Location = new Point(81, 0);
            txtRole.Margin = new Padding(14, 0, 0, 0);
            txtRole.Name = "txtRole";
            txtRole.PlaceholderText = "Type";
            txtRole.ReadOnly = true;
            txtRole.Size = new Size(118, 23);
            txtRole.TabIndex = 38;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.AutoSize = true;
            flowLayoutPanel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel3.Controls.Add(lable5);
            flowLayoutPanel3.Controls.Add(txtRole);
            flowLayoutPanel3.Location = new Point(0, 138);
            flowLayoutPanel3.Margin = new Padding(0, 3, 3, 3);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(199, 23);
            flowLayoutPanel3.TabIndex = 39;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.AutoSize = true;
            flowLayoutPanel4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel4.Controls.Add(label4);
            flowLayoutPanel4.Controls.Add(chkListGroups);
            flowLayoutPanel4.Location = new Point(0, 190);
            flowLayoutPanel4.Margin = new Padding(0, 3, 3, 10);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(291, 112);
            flowLayoutPanel4.TabIndex = 40;
            // 
            // flowLayoutPanel5
            // 
            flowLayoutPanel5.AutoSize = true;
            flowLayoutPanel5.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel5.Controls.Add(label5);
            flowLayoutPanel5.Controls.Add(chkIsActive);
            flowLayoutPanel5.Location = new Point(0, 315);
            flowLayoutPanel5.Margin = new Padding(0, 3, 3, 5);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            flowLayoutPanel5.Size = new Size(141, 19);
            flowLayoutPanel5.TabIndex = 41;
            // 
            // flowLayoutPanel6
            // 
            flowLayoutPanel6.AutoSize = true;
            flowLayoutPanel6.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel6.Controls.Add(btnApprove);
            flowLayoutPanel6.Controls.Add(btnReject);
            flowLayoutPanel6.Controls.Add(btnCancel);
            flowLayoutPanel6.Location = new Point(3, 470);
            flowLayoutPanel6.Margin = new Padding(3, 30, 3, 3);
            flowLayoutPanel6.Name = "flowLayoutPanel6";
            flowLayoutPanel6.Size = new Size(330, 37);
            flowLayoutPanel6.TabIndex = 42;
            // 
            // flowLayoutPanel7
            // 
            flowLayoutPanel7.AutoSize = true;
            flowLayoutPanel7.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel7.Controls.Add(flowLayoutPanel9);
            flowLayoutPanel7.Controls.Add(flowLayoutPanel1);
            flowLayoutPanel7.Controls.Add(lblOldName);
            flowLayoutPanel7.Controls.Add(flowLayoutPanel2);
            flowLayoutPanel7.Controls.Add(lblOldPass);
            flowLayoutPanel7.Controls.Add(flowLayoutPanel3);
            flowLayoutPanel7.Controls.Add(lblOldRole);
            flowLayoutPanel7.Controls.Add(flowLayoutPanel4);
            flowLayoutPanel7.Controls.Add(flowLayoutPanel5);
            flowLayoutPanel7.Controls.Add(lblOldActive);
            flowLayoutPanel7.Controls.Add(flowLayoutPanel8);
            flowLayoutPanel7.Controls.Add(flowLayoutPanel6);
            flowLayoutPanel7.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel7.Location = new Point(24, 88);
            flowLayoutPanel7.Margin = new Padding(5, 3, 5, 30);
            flowLayoutPanel7.Name = "flowLayoutPanel7";
            flowLayoutPanel7.Size = new Size(336, 510);
            flowLayoutPanel7.TabIndex = 43;
            flowLayoutPanel7.WrapContents = false;
            // 
            // flowLayoutPanel9
            // 
            flowLayoutPanel9.AutoSize = true;
            flowLayoutPanel9.Controls.Add(lblActionTitle);
            flowLayoutPanel9.Controls.Add(lblAction);
            flowLayoutPanel9.Location = new Point(0, 3);
            flowLayoutPanel9.Margin = new Padding(0, 3, 3, 10);
            flowLayoutPanel9.Name = "flowLayoutPanel9";
            flowLayoutPanel9.Size = new Size(92, 15);
            flowLayoutPanel9.TabIndex = 45;
            // 
            // lblActionTitle
            // 
            lblActionTitle.AutoSize = true;
            lblActionTitle.Location = new Point(0, 0);
            lblActionTitle.Margin = new Padding(0);
            lblActionTitle.Name = "lblActionTitle";
            lblActionTitle.Size = new Size(45, 15);
            lblActionTitle.TabIndex = 35;
            lblActionTitle.Text = "Action:";
            // 
            // lblAction
            // 
            lblAction.AutoSize = true;
            lblAction.Location = new Point(77, 0);
            lblAction.Margin = new Padding(32, 0, 3, 0);
            lblAction.Name = "lblAction";
            lblAction.Size = new Size(12, 15);
            lblAction.TabIndex = 36;
            lblAction.Text = "-";
            // 
            // lblOldPass
            // 
            lblOldPass.AutoSize = true;
            lblOldPass.Font = new Font("Segoe UI", 8F);
            lblOldPass.ForeColor = SystemColors.ControlDarkDark;
            lblOldPass.Location = new Point(85, 112);
            lblOldPass.Margin = new Padding(85, 0, 3, 10);
            lblOldPass.Name = "lblOldPass";
            lblOldPass.Size = new Size(36, 13);
            lblOldPass.TabIndex = 46;
            lblOldPass.Text = "Old: -";
            // 
            // flowLayoutPanel8
            // 
            flowLayoutPanel8.AutoSize = true;
            flowLayoutPanel8.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel8.Controls.Add(lblRemarks);
            flowLayoutPanel8.Controls.Add(txtRemarks);
            flowLayoutPanel8.Location = new Point(0, 365);
            flowLayoutPanel8.Margin = new Padding(0, 3, 3, 3);
            flowLayoutPanel8.Name = "flowLayoutPanel8";
            flowLayoutPanel8.Size = new Size(291, 72);
            flowLayoutPanel8.TabIndex = 44;
            // 
            // lblRemarks
            // 
            lblRemarks.AutoSize = true;
            lblRemarks.Location = new Point(0, 0);
            lblRemarks.Margin = new Padding(0);
            lblRemarks.Name = "lblRemarks";
            lblRemarks.Size = new Size(55, 15);
            lblRemarks.TabIndex = 9;
            lblRemarks.Text = "Remarks:";
            // 
            // txtRemarks
            // 
            txtRemarks.Enabled = false;
            txtRemarks.Location = new Point(73, 0);
            txtRemarks.Margin = new Padding(18, 0, 0, 0);
            txtRemarks.Multiline = true;
            txtRemarks.Name = "txtRemarks";
            txtRemarks.PlaceholderText = "Remarks";
            txtRemarks.ReadOnly = true;
            txtRemarks.Size = new Size(218, 72);
            txtRemarks.TabIndex = 43;
            // 
            // UserReview
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(385, 609);
            Controls.Add(label1);
            Controls.Add(flowLayoutPanel7);
            MinimumSize = new Size(401, 0);
            Name = "UserReview";
            StartPosition = FormStartPosition.CenterParent;
            Text = "User Review";
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            flowLayoutPanel5.ResumeLayout(false);
            flowLayoutPanel5.PerformLayout();
            flowLayoutPanel6.ResumeLayout(false);
            flowLayoutPanel7.ResumeLayout(false);
            flowLayoutPanel7.PerformLayout();
            flowLayoutPanel9.ResumeLayout(false);
            flowLayoutPanel9.PerformLayout();
            flowLayoutPanel8.ResumeLayout(false);
            flowLayoutPanel8.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label label4;
        private Label label5;
        private CheckBox chkIsActive;
        private CheckedListBox chkListGroups;
        private Label lable5;
        private Label lblOldName;
        private Label lblOldRole;
        private Label lblOldActive;
        private Button btnApprove;
        private Button btnReject;
        private Button btnCancel;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private TextBox txtRole;
        private FlowLayoutPanel flowLayoutPanel3;
        private FlowLayoutPanel flowLayoutPanel4;
        private FlowLayoutPanel flowLayoutPanel5;
        private FlowLayoutPanel flowLayoutPanel6;
        private FlowLayoutPanel flowLayoutPanel7;
        private Label lblRemarks;
        private FlowLayoutPanel flowLayoutPanel8;
        private TextBox txtRemarks;
        private FlowLayoutPanel flowLayoutPanel9;
        private Label lblActionTitle;
        private Label lblAction;
        private Label lblOldPass;
    }
}