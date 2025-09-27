namespace TeacherForm
{
    partial class GroupsDetails
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
            btnCancel = new Button();
            btnSave = new Button();
            label5 = new Label();
            txtGroupName = new TextBox();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            txtDescription = new TextBox();
            treePermissions = new TreeView();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(27, 369);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(96, 31);
            btnCancel.TabIndex = 22;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Green;
            btnSave.ForeColor = SystemColors.Control;
            btnSave.Location = new Point(261, 369);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(96, 31);
            btnSave.TabIndex = 21;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 224);
            label5.Name = "label5";
            label5.Size = new Size(73, 15);
            label5.TabIndex = 19;
            label5.Text = "Permissions:";
            // 
            // txtGroupName
            // 
            txtGroupName.Location = new Point(106, 115);
            txtGroupName.Name = "txtGroupName";
            txtGroupName.PlaceholderText = "Group name";
            txtGroupName.Size = new Size(213, 23);
            txtGroupName.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 118);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 13;
            label2.Text = "Group Name:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(48, 47);
            label1.Name = "label1";
            label1.Size = new Size(293, 25);
            label1.TabIndex = 12;
            label1.Text = "Groups And Permissions Details";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 148);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 14;
            label3.Text = "Description:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(106, 145);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Description";
            txtDescription.Size = new Size(213, 66);
            txtDescription.TabIndex = 16;
            // 
            // treePermissions
            // 
            treePermissions.CheckBoxes = true;
            treePermissions.FullRowSelect = true;
            treePermissions.Location = new Point(106, 220);
            treePermissions.Name = "treePermissions";
            treePermissions.Size = new Size(213, 128);
            treePermissions.TabIndex = 23;
            // 
            // GroupsDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(385, 439);
            Controls.Add(treePermissions);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(label5);
            Controls.Add(txtDescription);
            Controls.Add(txtGroupName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "GroupsDetails";
            Text = "Groups And Permissions Details";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnCancel;
        private Button btnSave;
        private Label label5;
        private TextBox txtGroupName;
        private Label label2;
        private Label label1;
        private Label label3;
        private TextBox txtDescription;
        private TreeView treePermissions;
    }
}