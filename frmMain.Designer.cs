namespace EquipFormApp
{
    partial class frmMain
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
            btnInsert = new Button();
            btnSearch = new Button();
            cmbCategory = new ComboBox();
            txtEquip = new TextBox();
            lblCategory = new Label();
            lblEquipName = new Label();
            dgvEquipCate = new DataGridView();
            btnEdit = new Button();
            btnAdju = new Button();
            btnMaster = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEquipCate).BeginInit();
            SuspendLayout();
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(18, 403);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(169, 89);
            btnInsert.TabIndex = 7;
            btnInsert.Text = "新規登録";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(637, 41);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(125, 48);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "検索";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(457, 23);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(151, 28);
            cmbCategory.TabIndex = 5;
            // 
            // txtEquip
            // 
            txtEquip.Location = new Point(457, 62);
            txtEquip.Name = "txtEquip";
            txtEquip.Size = new Size(125, 27);
            txtEquip.TabIndex = 4;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(356, 31);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(52, 20);
            lblCategory.TabIndex = 8;
            lblCategory.Text = "カテゴリ";
            // 
            // lblEquipName
            // 
            lblEquipName.AutoSize = true;
            lblEquipName.Location = new Point(356, 69);
            lblEquipName.Name = "lblEquipName";
            lblEquipName.Size = new Size(54, 20);
            lblEquipName.TabIndex = 9;
            lblEquipName.Text = "備品名";
            // 
            // dgvEquipCate
            // 
            dgvEquipCate.AllowUserToAddRows = false;
            dgvEquipCate.AllowUserToDeleteRows = false;
            dgvEquipCate.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEquipCate.Location = new Point(10, 115);
            dgvEquipCate.Name = "dgvEquipCate";
            dgvEquipCate.ReadOnly = true;
            dgvEquipCate.RowHeadersWidth = 51;
            dgvEquipCate.Size = new Size(750, 260);
            dgvEquipCate.TabIndex = 10;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(212, 403);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(169, 89);
            btnEdit.TabIndex = 11;
            btnEdit.Text = "編集";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdju
            // 
            btnAdju.Location = new Point(399, 403);
            btnAdju.Name = "btnAdju";
            btnAdju.Size = new Size(169, 89);
            btnAdju.TabIndex = 12;
            btnAdju.Text = "在庫調整";
            btnAdju.UseVisualStyleBackColor = true;
            btnAdju.Click += btnAdju_Click;
            // 
            // btnMaster
            // 
            btnMaster.Location = new Point(584, 403);
            btnMaster.Name = "btnMaster";
            btnMaster.Size = new Size(169, 89);
            btnMaster.TabIndex = 13;
            btnMaster.Text = "カテゴリマスタ管理";
            btnMaster.UseVisualStyleBackColor = true;
            btnMaster.Click += btnMaster_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(774, 517);
            Controls.Add(btnMaster);
            Controls.Add(btnAdju);
            Controls.Add(btnEdit);
            Controls.Add(dgvEquipCate);
            Controls.Add(lblEquipName);
            Controls.Add(lblCategory);
            Controls.Add(btnInsert);
            Controls.Add(btnSearch);
            Controls.Add(cmbCategory);
            Controls.Add(txtEquip);
            Name = "frmMain";
            Text = "備品一覧画面";
            Load += frmMain_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEquipCate).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnInsert;
        private Button btnSearch;
        private ComboBox cmbCategory;
        private TextBox txtEquip;
        private Label lblCategory;
        private Label lblEquipName;
        private DataGridView dgvEquipCate;
        private Button btnEdit;
        private Button btnAdju;
        private Button btnMaster;
    }
}
