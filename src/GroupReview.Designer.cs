namespace TeacherForm
{
    partial class GroupReview
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
            label5 = new Label();
            txtGroupName = new TextBox();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            txtDescription = new TextBox();
            treePermissions = new TreeView();
            btnApprove = new Button();
            btnReject = new Button();
            lblOldName = new Label();
            lblOldDesc = new Label();
            lblActionTitle = new Label();
            lblAction = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            flowLayoutPanel3 = new FlowLayoutPanel();
            flowLayoutPanel4 = new FlowLayoutPanel();
            flowLayoutPanel5 = new FlowLayoutPanel();
            flowLayoutPanel6 = new FlowLayoutPanel();
            flowLayoutPanel7 = new FlowLayoutPanel();
            lblRemarks = new Label();
            txtRemarks = new TextBox();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            flowLayoutPanel5.SuspendLayout();
            flowLayoutPanel6.SuspendLayout();
            flowLayoutPanel7.SuspendLayout();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(228, 3);
            btnCancel.Margin = new Padding(10, 3, 3, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(96, 31);
            btnCancel.TabIndex = 22;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(0, 0);
            label5.Margin = new Padding(0, 0, 3, 0);
            label5.Name = "label5";
            label5.Size = new Size(73, 15);
            label5.TabIndex = 19;
            label5.Text = "Permissions:";
            // 
            // txtGroupName
            // 
            txtGroupName.Enabled = false;
            txtGroupName.Location = new Point(78, 3);
            txtGroupName.Margin = new Padding(0, 3, 0, 0);
            txtGroupName.Name = "txtGroupName";
            txtGroupName.PlaceholderText = "Group name";
            txtGroupName.ReadOnly = true;
            txtGroupName.Size = new Size(213, 23);
            txtGroupName.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(0, 6);
            label2.Margin = new Padding(0, 6, 0, 0);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 13;
            label2.Text = "Group Name:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(114, 42);
            label1.Name = "label1";
            label1.Size = new Size(137, 25);
            label1.TabIndex = 12;
            label1.Text = "Group Review";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(0, 0);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 14;
            label3.Text = "Description:";
            // 
            // txtDescription
            // 
            txtDescription.Enabled = false;
            txtDescription.Location = new Point(81, 0);
            txtDescription.Margin = new Padding(11, 0, 0, 0);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Description";
            txtDescription.ReadOnly = true;
            txtDescription.Size = new Size(216, 66);
            txtDescription.TabIndex = 16;
            // 
            // treePermissions
            // 
            treePermissions.CheckBoxes = true;
            treePermissions.FullRowSelect = true;
            treePermissions.Location = new Point(76, 0);
            treePermissions.Margin = new Padding(0);
            treePermissions.Name = "treePermissions";
            treePermissions.Size = new Size(221, 128);
            treePermissions.TabIndex = 23;
            // 
            // btnApprove
            // 
            btnApprove.BackColor = Color.Green;
            btnApprove.ForeColor = SystemColors.Control;
            btnApprove.Location = new Point(10, 3);
            btnApprove.Margin = new Padding(10, 3, 3, 3);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(96, 31);
            btnApprove.TabIndex = 31;
            btnApprove.Text = "Approve";
            btnApprove.UseVisualStyleBackColor = false;
            btnApprove.Click += btnApprove_Click;
            // 
            // btnReject
            // 
            btnReject.BackColor = Color.Red;
            btnReject.ForeColor = SystemColors.Control;
            btnReject.Location = new Point(119, 3);
            btnReject.Margin = new Padding(10, 3, 3, 3);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(96, 31);
            btnReject.TabIndex = 32;
            btnReject.Text = "Reject";
            btnReject.UseVisualStyleBackColor = false;
            btnReject.Click += btnReject_Click;
            // 
            // lblOldName
            // 
            lblOldName.AutoSize = true;
            lblOldName.ForeColor = SystemColors.ControlDarkDark;
            lblOldName.Location = new Point(90, 53);
            lblOldName.Margin = new Padding(90, 0, 3, 0);
            lblOldName.Name = "lblOldName";
            lblOldName.Size = new Size(37, 15);
            lblOldName.TabIndex = 33;
            lblOldName.Text = "Old: -";
            lblOldName.Visible = false;
            // 
            // lblOldDesc
            // 
            lblOldDesc.AutoSize = true;
            lblOldDesc.ForeColor = SystemColors.ControlDarkDark;
            lblOldDesc.Location = new Point(90, 140);
            lblOldDesc.Margin = new Padding(90, 0, 3, 0);
            lblOldDesc.Name = "lblOldDesc";
            lblOldDesc.Size = new Size(37, 15);
            lblOldDesc.TabIndex = 34;
            lblOldDesc.Text = "Old: -";
            lblOldDesc.Visible = false;
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
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(lblActionTitle);
            flowLayoutPanel1.Controls.Add(lblAction);
            flowLayoutPanel1.Location = new Point(0, 3);
            flowLayoutPanel1.Margin = new Padding(0, 3, 3, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(92, 15);
            flowLayoutPanel1.TabIndex = 37;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel2.Controls.Add(label2);
            flowLayoutPanel2.Controls.Add(txtGroupName);
            flowLayoutPanel2.Location = new Point(0, 24);
            flowLayoutPanel2.Margin = new Padding(0, 3, 3, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(291, 26);
            flowLayoutPanel2.TabIndex = 38;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.AutoSize = true;
            flowLayoutPanel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel3.Controls.Add(label3);
            flowLayoutPanel3.Controls.Add(txtDescription);
            flowLayoutPanel3.Location = new Point(0, 71);
            flowLayoutPanel3.Margin = new Padding(0, 3, 3, 3);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(297, 66);
            flowLayoutPanel3.TabIndex = 39;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.AutoSize = true;
            flowLayoutPanel4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel4.Controls.Add(label5);
            flowLayoutPanel4.Controls.Add(treePermissions);
            flowLayoutPanel4.Location = new Point(0, 158);
            flowLayoutPanel4.Margin = new Padding(0, 3, 3, 3);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(297, 128);
            flowLayoutPanel4.TabIndex = 40;
            // 
            // flowLayoutPanel5
            // 
            flowLayoutPanel5.Controls.Add(btnApprove);
            flowLayoutPanel5.Controls.Add(btnReject);
            flowLayoutPanel5.Controls.Add(btnCancel);
            flowLayoutPanel5.Location = new Point(3, 391);
            flowLayoutPanel5.Margin = new Padding(3, 30, 3, 3);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            flowLayoutPanel5.Size = new Size(333, 38);
            flowLayoutPanel5.TabIndex = 41;
            // 
            // flowLayoutPanel6
            // 
            flowLayoutPanel6.AutoSize = true;
            flowLayoutPanel6.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel6.Controls.Add(flowLayoutPanel1);
            flowLayoutPanel6.Controls.Add(flowLayoutPanel2);
            flowLayoutPanel6.Controls.Add(lblOldName);
            flowLayoutPanel6.Controls.Add(flowLayoutPanel3);
            flowLayoutPanel6.Controls.Add(lblOldDesc);
            flowLayoutPanel6.Controls.Add(flowLayoutPanel4);
            flowLayoutPanel6.Controls.Add(flowLayoutPanel7);
            flowLayoutPanel6.Controls.Add(flowLayoutPanel5);
            flowLayoutPanel6.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel6.Location = new Point(24, 83);
            flowLayoutPanel6.Margin = new Padding(3, 3, 3, 20);
            flowLayoutPanel6.Name = "flowLayoutPanel6";
            flowLayoutPanel6.Size = new Size(339, 432);
            flowLayoutPanel6.TabIndex = 42;
            flowLayoutPanel6.WrapContents = false;
            // 
            // flowLayoutPanel7
            // 
            flowLayoutPanel7.AutoSize = true;
            flowLayoutPanel7.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel7.Controls.Add(lblRemarks);
            flowLayoutPanel7.Controls.Add(txtRemarks);
            flowLayoutPanel7.Location = new Point(0, 292);
            flowLayoutPanel7.Margin = new Padding(0, 3, 3, 3);
            flowLayoutPanel7.Name = "flowLayoutPanel7";
            flowLayoutPanel7.Size = new Size(297, 66);
            flowLayoutPanel7.TabIndex = 41;
            flowLayoutPanel7.Visible = false;
            // 
            // lblRemarks
            // 
            lblRemarks.AutoSize = true;
            lblRemarks.Location = new Point(0, 0);
            lblRemarks.Margin = new Padding(0, 0, 3, 0);
            lblRemarks.Name = "lblRemarks";
            lblRemarks.Size = new Size(55, 15);
            lblRemarks.TabIndex = 19;
            lblRemarks.Text = "Remarks:";
            lblRemarks.Visible = false;
            // 
            // txtRemarks
            // 
            txtRemarks.Enabled = false;
            txtRemarks.Location = new Point(76, 0);
            txtRemarks.Margin = new Padding(18, 0, 0, 0);
            txtRemarks.Multiline = true;
            txtRemarks.Name = "txtRemarks";
            txtRemarks.PlaceholderText = "Remarks";
            txtRemarks.ReadOnly = true;
            txtRemarks.Size = new Size(221, 66);
            txtRemarks.TabIndex = 20;
            // 
            // GroupReview
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(385, 566);
            Controls.Add(flowLayoutPanel6);
            Controls.Add(label1);
            MinimumSize = new Size(401, 0);
            Name = "GroupReview";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Group Review";
            Load += GroupReview_Load;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            flowLayoutPanel5.ResumeLayout(false);
            flowLayoutPanel6.ResumeLayout(false);
            flowLayoutPanel6.PerformLayout();
            flowLayoutPanel7.ResumeLayout(false);
            flowLayoutPanel7.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnCancel;
        private Label label5;
        private TextBox txtGroupName;
        private Label label2;
        private Label label1;
        private Label label3;
        private TextBox txtDescription;
        private TreeView treePermissions;
        private Button btnApprove;
        private Button btnReject;
        private Label lblOldName;
        private Label lblOldDesc;
        private Label lblActionTitle;
        private Label lblAction;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel3;
        private FlowLayoutPanel flowLayoutPanel4;
        private FlowLayoutPanel flowLayoutPanel5;
        private FlowLayoutPanel flowLayoutPanel6;
        private FlowLayoutPanel flowLayoutPanel7;
        private Label lblRemarks;
        private TextBox txtRemarks;
    }
}