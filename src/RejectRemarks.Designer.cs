namespace TeacherForm
{
    partial class RejectRemarks
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
            txtRemarks = new TextBox();
            label2 = new Label();
            btnCancel = new Button();
            btnSave = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(127, 70);
            label1.Name = "label1";
            label1.Size = new Size(188, 25);
            label1.TabIndex = 0;
            label1.Text = "Add Reject Remarks";
            // 
            // txtRemarks
            // 
            txtRemarks.Location = new Point(79, 123);
            txtRemarks.Multiline = true;
            txtRemarks.Name = "txtRemarks";
            txtRemarks.ScrollBars = ScrollBars.Vertical;
            txtRemarks.Size = new Size(290, 155);
            txtRemarks.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 126);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 2;
            label2.Text = "Remarks:";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(54, 342);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(96, 31);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Green;
            btnSave.ForeColor = SystemColors.Control;
            btnSave.Location = new Point(288, 342);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(96, 31);
            btnSave.TabIndex = 11;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // RejectRemarks
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(443, 413);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(label2);
            Controls.Add(txtRemarks);
            Controls.Add(label1);
            Name = "RejectRemarks";
            Text = "Reject Remarks";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtRemarks;
        private Label label2;
        private Button btnCancel;
        private Button btnSave;
    }
}