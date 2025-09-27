namespace TeacherForm
{
    partial class ResetPassword
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
            txtNewPassword = new TextBox();
            lable3 = new Label();
            txtConfirmPassword = new TextBox();
            btnSet = new Button();
            btnCancel = new Button();
            txtCurrentPassword = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(85, 65);
            label1.Name = "label1";
            label1.Size = new Size(149, 25);
            label1.TabIndex = 0;
            label1.Text = "Reset Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 191);
            label2.Name = "label2";
            label2.Size = new Size(87, 15);
            label2.TabIndex = 3;
            label2.Text = "New Password:";
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(32, 211);
            txtNewPassword.MaxLength = 50;
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PlaceholderText = "New Password";
            txtNewPassword.Size = new Size(255, 23);
            txtNewPassword.TabIndex = 4;
            // 
            // lable3
            // 
            lable3.AutoSize = true;
            lable3.Location = new Point(31, 265);
            lable3.Name = "lable3";
            lable3.Size = new Size(107, 15);
            lable3.TabIndex = 5;
            lable3.Text = "Confirm Password:";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(32, 285);
            txtConfirmPassword.MaxLength = 50;
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PlaceholderText = "Confirm Password";
            txtConfirmPassword.Size = new Size(255, 23);
            txtConfirmPassword.TabIndex = 6;
            // 
            // btnSet
            // 
            btnSet.BackColor = Color.Green;
            btnSet.ForeColor = SystemColors.Control;
            btnSet.Location = new Point(193, 380);
            btnSet.Name = "btnSet";
            btnSet.Size = new Size(98, 29);
            btnSet.TabIndex = 5;
            btnSet.Text = "Save";
            btnSet.UseVisualStyleBackColor = false;
            btnSet.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(32, 380);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtCurrentPassword
            // 
            txtCurrentPassword.Location = new Point(32, 144);
            txtCurrentPassword.MaxLength = 50;
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.PlaceholderText = "Current Password";
            txtCurrentPassword.Size = new Size(255, 23);
            txtCurrentPassword.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 124);
            label3.Name = "label3";
            label3.Size = new Size(103, 15);
            label3.TabIndex = 1;
            label3.Text = "Current Password:";
            // 
            // ResetPassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(333, 479);
            Controls.Add(txtCurrentPassword);
            Controls.Add(label3);
            Controls.Add(btnCancel);
            Controls.Add(btnSet);
            Controls.Add(txtConfirmPassword);
            Controls.Add(lable3);
            Controls.Add(txtNewPassword);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ResetPassword";
            Text = "Reset Password";
            Load += ResetPassword_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtNewPassword;
        private Label lable3;
        private TextBox txtConfirmPassword;
        private Button btnSet;
        private Button btnCancel;
        private TextBox txtCurrentPassword;
        private Label label3;
    }
}