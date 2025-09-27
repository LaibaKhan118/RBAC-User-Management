namespace TeacherForm
{
    partial class TeacherReview
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // label_name
            // 
            label_name.AutoSize = true;
            label_name.Location = new Point(3, 0);
            label_name.Margin = new Padding(3, 0, 3, 2);
            label_name.Name = "label_name";
            label_name.Size = new Size(39, 15);
            label_name.TabIndex = 0;
            label_name.Text = "Name";
            // 
            // label_address
            // 
            label_address.AutoSize = true;
            label_address.Location = new Point(3, 58);
            label_address.Margin = new Padding(3, 0, 3, 2);
            label_address.Name = "label_address";
            label_address.Size = new Size(49, 15);
            label_address.TabIndex = 0;
            label_address.Text = "Address";
            // 
            // label_salary
            // 
            label_salary.AutoSize = true;
            label_salary.Location = new Point(3, 116);
            label_salary.Margin = new Padding(3, 0, 3, 2);
            label_salary.Name = "label_salary";
            label_salary.Size = new Size(38, 15);
            label_salary.TabIndex = 0;
            label_salary.Text = "Salary";
            // 
            // txtName
            // 
            txtName.Location = new Point(3, 20);
            txtName.Margin = new Padding(3, 3, 3, 15);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Name";
            txtName.Size = new Size(320, 23);
            txtName.TabIndex = 2;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(3, 78);
            txtAddress.Margin = new Padding(3, 3, 3, 15);
            txtAddress.Name = "txtAddress";
            txtAddress.PlaceholderText = "Address";
            txtAddress.Size = new Size(320, 23);
            txtAddress.TabIndex = 3;
            // 
            // txtSalary
            // 
            txtSalary.Location = new Point(3, 136);
            txtSalary.Margin = new Padding(3, 3, 3, 15);
            txtSalary.Name = "txtSalary";
            txtSalary.PlaceholderText = "Salary";
            txtSalary.Size = new Size(320, 23);
            txtSalary.TabIndex = 4;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.Control;
            btnCancel.Location = new Point(0, 0);
            btnCancel.Margin = new Padding(0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 37);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += Cancel_Click;
            // 
            // BtnSave
            // 
            BtnSave.BackColor = Color.Green;
            BtnSave.ForeColor = SystemColors.Control;
            BtnSave.Location = new Point(225, 0);
            BtnSave.Margin = new Padding(125, 0, 0, 0);
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
            label1.Location = new Point(145, 41);
            label1.Name = "label1";
            label1.Size = new Size(138, 25);
            label1.TabIndex = 7;
            label1.Text = "Review Details";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(btnCancel);
            flowLayoutPanel1.Controls.Add(BtnSave);
            flowLayoutPanel1.Location = new Point(3, 204);
            flowLayoutPanel1.Margin = new Padding(3, 30, 3, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(325, 37);
            flowLayoutPanel1.TabIndex = 8;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel2.Controls.Add(label_name);
            flowLayoutPanel2.Controls.Add(txtName);
            flowLayoutPanel2.Controls.Add(label_address);
            flowLayoutPanel2.Controls.Add(txtAddress);
            flowLayoutPanel2.Controls.Add(label_salary);
            flowLayoutPanel2.Controls.Add(txtSalary);
            flowLayoutPanel2.Controls.Add(flowLayoutPanel1);
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel2.Location = new Point(58, 88);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(331, 244);
            flowLayoutPanel2.TabIndex = 9;
            // 
            // TeacherReview
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(448, 399);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(label1);
            Name = "TeacherReview";
            Text = "Teacher Review";
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
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
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
    }
}