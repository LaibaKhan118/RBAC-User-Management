namespace TeacherForm
{
    partial class TeacherList
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Add = new Button();
            Delete = new Button();
            ShowAll = new Button();
            btnBack = new Button();
            search = new TextBox();
            Find = new Button();
            dataGridView1 = new DataGridView();
            btnEdit = new Button();
            label1 = new Label();
            cmbFilter = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // Add
            // 
            Add.Location = new Point(628, 88);
            Add.Name = "Add";
            Add.Size = new Size(85, 30);
            Add.TabIndex = 9;
            Add.Text = "Add";
            Add.UseVisualStyleBackColor = true;
            Add.Click += Add_Click;
            // 
            // Delete
            // 
            Delete.Location = new Point(629, 160);
            Delete.Name = "Delete";
            Delete.Size = new Size(85, 30);
            Delete.TabIndex = 10;
            Delete.Text = "Delete";
            Delete.UseVisualStyleBackColor = true;
            Delete.Click += Delete_Click;
            // 
            // ShowAll
            // 
            ShowAll.Location = new Point(628, 52);
            ShowAll.Name = "ShowAll";
            ShowAll.Size = new Size(85, 30);
            ShowAll.TabIndex = 7;
            ShowAll.Text = "Refresh";
            ShowAll.UseVisualStyleBackColor = true;
            ShowAll.Click += ShowAll_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Red;
            btnBack.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = SystemColors.Control;
            btnBack.Location = new Point(629, 429);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(85, 35);
            btnBack.TabIndex = 11;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // search
            // 
            search.Location = new Point(12, 12);
            search.Name = "search";
            search.PlaceholderText = "Search by ID or Username";
            search.Size = new Size(610, 23);
            search.TabIndex = 12;
            // 
            // Find
            // 
            Find.BackColor = Color.LawnGreen;
            Find.ForeColor = SystemColors.ControlText;
            Find.Location = new Point(629, 6);
            Find.Name = "Find";
            Find.Size = new Size(85, 33);
            Find.TabIndex = 13;
            Find.Text = "Find";
            Find.UseVisualStyleBackColor = false;
            Find.Click += Search_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 72);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(610, 392);
            dataGridView1.TabIndex = 14;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(628, 124);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(85, 30);
            btnEdit.TabIndex = 16;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(458, 44);
            label1.Name = "label1";
            label1.Size = new Size(42, 19);
            label1.TabIndex = 31;
            label1.Text = "Filter:";
            // 
            // cmbFilter
            // 
            cmbFilter.FormattingEnabled = true;
            cmbFilter.Items.AddRange(new object[] { "Pending", "Approved", "Rejected" });
            cmbFilter.Location = new Point(500, 41);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(121, 23);
            cmbFilter.TabIndex = 30;
            cmbFilter.SelectedIndexChanged += TeacherList_Load;
            // 
            // TeacherList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(726, 476);
            Controls.Add(label1);
            Controls.Add(cmbFilter);
            Controls.Add(btnEdit);
            Controls.Add(dataGridView1);
            Controls.Add(Find);
            Controls.Add(search);
            Controls.Add(btnBack);
            Controls.Add(ShowAll);
            Controls.Add(Delete);
            Controls.Add(Add);
            Name = "TeacherList";
            Text = "Teacher List";
            Load += TeacherList_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button Add;
        private Button Delete;
        private Button ShowAll;
        private Button btnBack;
        private TextBox search;
        private Button Find;
        private DataGridView dataGridView1;
        private Button btnEdit;
        private Label label1;
        private ComboBox cmbFilter;
    }
}
