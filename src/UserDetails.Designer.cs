namespace TeacherForm
{
    partial class UserDetails
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
            btnSave = new Button();
            btnCancel = new Button();
            txtConfirmPassword = new TextBox();
            chkListGroups = new CheckedListBox();
            cmbRole = new ComboBox();
            lable5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(134, 47);
            label1.Name = "label1";
            label1.Size = new Size(116, 25);
            label1.TabIndex = 0;
            label1.Text = "User Details";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 114);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 1;
            label2.Text = "Username:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 144);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 2;
            label3.Text = "Password:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(99, 111);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Username";
            txtUsername.Size = new Size(213, 23);
            txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(99, 141);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(213, 23);
            txtPassword.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 276);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 5;
            label4.Text = "Group(s):";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 418);
            label5.Name = "label5";
            label5.Size = new Size(68, 15);
            label5.TabIndex = 7;
            label5.Text = "User Status:";
            // 
            // chkIsActive
            // 
            chkIsActive.AutoSize = true;
            chkIsActive.Location = new Point(99, 418);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(59, 19);
            chkIsActive.TabIndex = 8;
            chkIsActive.Text = "Active";
            chkIsActive.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Green;
            btnSave.ForeColor = SystemColors.Control;
            btnSave.Location = new Point(259, 470);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(96, 31);
            btnSave.TabIndex = 9;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(25, 470);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(96, 31);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(99, 174);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.PlaceholderText = "Confirm Password";
            txtConfirmPassword.Size = new Size(213, 23);
            txtConfirmPassword.TabIndex = 11;
            // 
            // chkListGroups
            // 
            chkListGroups.CheckOnClick = true;
            chkListGroups.FormattingEnabled = true;
            chkListGroups.Location = new Point(99, 276);
            chkListGroups.Name = "chkListGroups";
            chkListGroups.Size = new Size(213, 112);
            chkListGroups.TabIndex = 12;
            // 
            // cmbRole
            // 
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(99, 225);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(121, 23);
            cmbRole.TabIndex = 13;
            // 
            // lable5
            // 
            lable5.AutoSize = true;
            lable5.Location = new Point(25, 228);
            lable5.Name = "lable5";
            lable5.Size = new Size(58, 15);
            lable5.TabIndex = 14;
            lable5.Text = "User Type";
            // 
            // UserDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(385, 515);
            Controls.Add(lable5);
            Controls.Add(cmbRole);
            Controls.Add(chkListGroups);
            Controls.Add(txtConfirmPassword);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(chkIsActive);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UserDetails";
            Text = "User Details";
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
        private Button btnSave;
        private Button btnCancel;
        private TextBox txtConfirmPassword;
        private CheckedListBox chkListGroups;
        private ComboBox cmbRole;
        private Label lable5;
    }
}