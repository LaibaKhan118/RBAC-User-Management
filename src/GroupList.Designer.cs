namespace TeacherForm
{
    partial class GroupList
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
            cmbFilter = new ComboBox();
            btnBack = new Button();
            dataGridView1 = new DataGridView();
            SearchBox = new TextBox();
            flowActionsPanel = new FlowLayoutPanel();
            btnFind = new Button();
            btnRefresh = new Button();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnView = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            flowActionsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(739, 48);
            label1.Name = "label1";
            label1.Size = new Size(42, 19);
            label1.TabIndex = 29;
            label1.Text = "Filter:";
            // 
            // cmbFilter
            // 
            cmbFilter.FormattingEnabled = true;
            cmbFilter.Items.AddRange(new object[] { "Pending", "Approved", "Rejected" });
            cmbFilter.Location = new Point(781, 45);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(121, 23);
            cmbFilter.TabIndex = 28;
            cmbFilter.SelectedIndexChanged += cmbFilter_SelectedIndexChanged;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Red;
            btnBack.ForeColor = SystemColors.Control;
            btnBack.Location = new Point(908, 481);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(85, 35);
            btnBack.TabIndex = 26;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(9, 74);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(896, 442);
            dataGridView1.TabIndex = 25;
            // 
            // SearchBox
            // 
            SearchBox.Location = new Point(9, 16);
            SearchBox.Name = "SearchBox";
            SearchBox.PlaceholderText = "Search by ID or Username";
            SearchBox.Size = new Size(896, 23);
            SearchBox.TabIndex = 24;
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
            flowActionsPanel.Location = new Point(908, 10);
            flowActionsPanel.Name = "flowActionsPanel";
            flowActionsPanel.Size = new Size(91, 465);
            flowActionsPanel.TabIndex = 27;
            flowActionsPanel.WrapContents = false;
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
            // btnView
            // 
            btnView.Location = new Point(3, 186);
            btnView.Name = "btnView";
            btnView.Size = new Size(85, 30);
            btnView.TabIndex = 29;
            btnView.Text = "View";
            btnView.UseVisualStyleBackColor = true;
            btnView.Click += btnView_Click;
            // 
            // GroupList
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
            HelpButton = true;
            Name = "GroupList";
            Text = "Group List";
            Load += GroupList_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            flowActionsPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbFilter;
        private Button btnBack;
        private DataGridView dataGridView1;
        private TextBox SearchBox;
        private FlowLayoutPanel flowActionsPanel;
        private Button btnFind;
        private Button btnRefresh;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnView;
    }
}