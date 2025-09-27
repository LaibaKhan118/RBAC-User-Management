namespace TeacherForm
{
    partial class UserList
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
            SearchBox = new TextBox();
            dataGridView1 = new DataGridView();
            btnFind = new Button();
            btnBack = new Button();
            btnRefresh = new Button();
            btnAdd = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            flowActionsPanel = new FlowLayoutPanel();
            btnView = new Button();
            cmbFilter = new ComboBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            flowActionsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // SearchBox
            // 
            SearchBox.Location = new Point(12, 14);
            SearchBox.Name = "SearchBox";
            SearchBox.PlaceholderText = "Search by ID or Username";
            SearchBox.Size = new Size(896, 23);
            SearchBox.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 72);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(896, 442);
            dataGridView1.TabIndex = 2;
            // 
            // btnFind
            // 
            btnFind.BackColor = Color.LawnGreen;
            btnFind.Location = new Point(3, 3);
            btnFind.Name = "btnFind";
            btnFind.Size = new Size(85, 33);
            btnFind.TabIndex = 14;
            btnFind.Text = "Find";
            btnFind.UseVisualStyleBackColor = false;
            btnFind.Click += btnFind_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Red;
            btnBack.ForeColor = SystemColors.Control;
            btnBack.Location = new Point(911, 479);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(85, 35);
            btnBack.TabIndex = 15;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(3, 42);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(85, 30);
            btnRefresh.TabIndex = 16;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(3, 78);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(85, 30);
            btnAdd.TabIndex = 17;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(3, 150);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(85, 30);
            btnDelete.TabIndex = 18;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(3, 114);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(85, 30);
            btnEdit.TabIndex = 20;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // flowActionsPanel
            // 
            flowActionsPanel.AutoSize = true;
            flowActionsPanel.Controls.Add(btnFind);
            flowActionsPanel.Controls.Add(btnRefresh);
            flowActionsPanel.Controls.Add(btnAdd);
            flowActionsPanel.Controls.Add(btnEdit);
            flowActionsPanel.Controls.Add(btnDelete);
            flowActionsPanel.Controls.Add(btnView);
            flowActionsPanel.FlowDirection = FlowDirection.TopDown;
            flowActionsPanel.Location = new Point(911, 8);
            flowActionsPanel.Name = "flowActionsPanel";
            flowActionsPanel.Size = new Size(91, 465);
            flowActionsPanel.TabIndex = 21;
            flowActionsPanel.WrapContents = false;
            // 
            // btnView
            // 
            btnView.Location = new Point(3, 186);
            btnView.Name = "btnView";
            btnView.Size = new Size(85, 30);
            btnView.TabIndex = 30;
            btnView.Text = "View";
            btnView.UseVisualStyleBackColor = true;
            btnView.Click += btnView_Click;
            // 
            // cmbFilter
            // 
            cmbFilter.FormattingEnabled = true;
            cmbFilter.Items.AddRange(new object[] { "Pending", "Approved", "Rejected" });
            cmbFilter.Location = new Point(784, 43);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(121, 23);
            cmbFilter.TabIndex = 22;
            cmbFilter.SelectedIndexChanged += cmbFilter_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(742, 46);
            label1.Name = "label1";
            label1.Size = new Size(42, 19);
            label1.TabIndex = 23;
            label1.Text = "Filter:";
            // 
            // UserList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 526);
            Controls.Add(label1);
            Controls.Add(cmbFilter);
            Controls.Add(btnBack);
            Controls.Add(dataGridView1);
            Controls.Add(SearchBox);
            Controls.Add(flowActionsPanel);
            Name = "UserList";
            Text = "User List";
            Load += UserList_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            flowActionsPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox SearchBox;
        private Button btnFind;
        private Button btnBack;
        private Button btnRefresh;
        private Button btnAdd;
        private Button btnDelete;
        private DataGridView dataGridView1;
        private Button btnEdit;
        private FlowLayoutPanel flowActionsPanel;
        private ComboBox cmbFilter;
        private Label label1;
        private Button btnView;
    }
}