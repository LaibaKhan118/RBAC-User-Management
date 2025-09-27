namespace TeacherForm
{
    partial class Login
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
            LoginTitle = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // LoginTitle
            // 
            LoginTitle.AutoSize = true;
            LoginTitle.Font = new Font("Tahoma", 20F, FontStyle.Bold);
            LoginTitle.Location = new Point(155, 72);
            LoginTitle.Name = "LoginTitle";
            LoginTitle.Size = new Size(89, 33);
            LoginTitle.TabIndex = 0;
            LoginTitle.Text = "Login";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 10F);
            txtUsername.Location = new Point(90, 153);
            txtUsername.MaxLength = 50;
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Username";
            txtUsername.Size = new Size(228, 25);
            txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(90, 208);
            txtPassword.MaxLength = 20;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(228, 25);
            txtPassword.TabIndex = 2;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.RoyalBlue;
            btnLogin.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = SystemColors.ControlLight;
            btnLogin.Location = new Point(90, 278);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(228, 35);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += LoginBtn_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Firebrick;
            btnExit.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnExit.ForeColor = SystemColors.Control;
            btnExit.Location = new Point(90, 319);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(228, 35);
            btnExit.TabIndex = 4;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(411, 477);
            Controls.Add(btnExit);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(LoginTitle);
            Name = "Login";
            Text = "Login";
            Click += btnExit_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LoginTitle;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnExit;
    }
}