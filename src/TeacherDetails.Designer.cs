namespace TeacherForm
{
    partial class TeacherDetails
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
            label_name = new Label();
            label_address = new Label();
            label_salary = new Label();
            txtName = new TextBox();
            txtAddress = new TextBox();
            txtSalary = new TextBox();
            btnCancel = new Button();
            BtnSave = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // label_name
            // 
            label_name.AutoSize = true;
            label_name.Location = new Point(90, 90);
            label_name.Name = "label_name";
            label_name.Size = new Size(39, 15);
            label_name.TabIndex = 0;
            label_name.Text = "Name";
            // 
            // label_address
            // 
            label_address.AutoSize = true;
            label_address.Location = new Point(90, 162);
            label_address.Name = "label_address";
            label_address.Size = new Size(49, 15);
            label_address.TabIndex = 0;
            label_address.Text = "Address";
            // 
            // label_salary
            // 
            label_salary.AutoSize = true;
            label_salary.Location = new Point(90, 235);
            label_salary.Name = "label_salary";
            label_salary.Size = new Size(38, 15);
            label_salary.TabIndex = 0;
            label_salary.Text = "Salary";
            // 
            // txtName
            // 
            txtName.Location = new Point(90, 108);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Name";
            txtName.Size = new Size(320, 23);
            txtName.TabIndex = 2;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(90, 180);
            txtAddress.Name = "txtAddress";
            txtAddress.PlaceholderText = "Address";
            txtAddress.Size = new Size(320, 23);
            txtAddress.TabIndex = 3;
            // 
            // txtSalary
            // 
            txtSalary.Location = new Point(90, 253);
            txtSalary.Name = "txtSalary";
            txtSalary.PlaceholderText = "Salary";
            txtSalary.Size = new Size(320, 23);
            txtSalary.TabIndex = 4;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.Control;
            btnCancel.Location = new Point(90, 337);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(83, 37);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += Cancel_Click;
            // 
            // BtnSave
            // 
            BtnSave.BackColor = Color.Green;
            BtnSave.ForeColor = SystemColors.Control;
            BtnSave.Location = new Point(310, 337);
            BtnSave.Name = "BtnSave";
            BtnSave.RightToLeft = RightToLeft.Yes;
            BtnSave.Size = new Size(100, 37);
            BtnSave.TabIndex = 5;
            BtnSave.Text = "Save";
            BtnSave.UseVisualStyleBackColor = false;
            BtnSave.Click += Save_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(193, 39);
            label1.Name = "label1";
            label1.Size = new Size(113, 25);
            label1.TabIndex = 7;
            label1.Text = "Add Details";
            // 
            // TeacherDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(488, 436);
            Controls.Add(label1);
            Controls.Add(BtnSave);
            Controls.Add(btnCancel);
            Controls.Add(txtSalary);
            Controls.Add(txtAddress);
            Controls.Add(txtName);
            Controls.Add(label_salary);
            Controls.Add(label_address);
            Controls.Add(label_name);
            Name = "TeacherDetails";
            Text = "Teacher Details";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label_name;
        private Label label_address;
        private Label label_salary;
        private TextBox txtName;
        private TextBox txtAddress;
        private TextBox txtSalary;
        private Button btnCancel;
        private Button BtnSave;
        private Label label1;
    }
}