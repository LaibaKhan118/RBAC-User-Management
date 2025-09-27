namespace TeacherForm
{
    partial class PendingGroupsList
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
            btnReject = new Button();
            btnApprove = new Button();
            btnRefresh = new Button();
            btnBack = new Button();
            btnFind = new Button();
            dataGridView1 = new DataGridView();
            SearchBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnReject
            // 
            btnReject.Location = new Point(827, 132);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(85, 30);
            btnReject.TabIndex = 28;
            btnReject.Text = "Reject";
            btnReject.UseVisualStyleBackColor = true;
            btnReject.Click += btnReject_Click;
            // 
            // btnApprove
            // 
            btnApprove.Location = new Point(827, 96);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(85, 30);
            btnApprove.TabIndex = 26;
            btnApprove.Text = "Approve";
            btnApprove.UseVisualStyleBackColor = true;
            btnApprove.Click += btnApprove_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(827, 60);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(85, 30);
            btnRefresh.TabIndex = 25;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Red;
            btnBack.ForeColor = SystemColors.Control;
            btnBack.Location = new Point(827, 480);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(85, 35);
            btnBack.TabIndex = 24;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // btnFind
            // 
            btnFind.BackColor = Color.LawnGreen;
            btnFind.Location = new Point(827, 11);
            btnFind.Name = "btnFind";
            btnFind.Size = new Size(85, 33);
            btnFind.TabIndex = 23;
            btnFind.Text = "Find";
            btnFind.UseVisualStyleBackColor = false;
            btnFind.Click += btnFind_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(13, 50);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(808, 465);
            dataGridView1.TabIndex = 22;
            // 
            // SearchBox
            // 
            SearchBox.Location = new Point(13, 17);
            SearchBox.Name = "SearchBox";
            SearchBox.PlaceholderText = "Search by ID or Status";
            SearchBox.Size = new Size(808, 23);
            SearchBox.TabIndex = 21;
            // 
            // PendingGroupsList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(924, 527);
            Controls.Add(btnReject);
            Controls.Add(btnApprove);
            Controls.Add(btnRefresh);
            Controls.Add(btnBack);
            Controls.Add(btnFind);
            Controls.Add(dataGridView1);
            Controls.Add(SearchBox);
            Name = "PendingGroupsList";
            Text = "Pending Groups List";
            Load += PendingGroups_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnReject;
        private Button btnApprove;
        private Button btnRefresh;
        private Button btnBack;
        private Button btnFind;
        private DataGridView dataGridView1;
        private TextBox SearchBox;
    }
}