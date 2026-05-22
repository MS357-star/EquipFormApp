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
            grpBottom = new GroupBox();
            grpTop = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvEquipCate).BeginInit();
            grpBottom.SuspendLayout();
            grpTop.SuspendLayout();
            SuspendLayout();
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(86, 26);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(169, 89);
            btnInsert.TabIndex = 1;
            btnInsert.Text = "新規登録";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(946, 38);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(125, 48);
            btnSearch.TabIndex = 7;
            btnSearch.Text = "検索";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(766, 20);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(151, 28);
            cmbCategory.TabIndex = 5;
            // 
            // txtEquip
            // 
            txtEquip.Location = new Point(766, 59);
            txtEquip.MaxLength = 50;
            txtEquip.Name = "txtEquip";
            txtEquip.Size = new Size(151, 27);
            txtEquip.TabIndex = 6;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(665, 28);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(52, 20);
            lblCategory.TabIndex = 8;
            lblCategory.Text = "カテゴリ";
            // 
            // lblEquipName
            // 
            lblEquipName.AutoSize = true;
            lblEquipName.Location = new Point(665, 66);
            lblEquipName.Name = "lblEquipName";
            lblEquipName.Size = new Size(54, 20);
            lblEquipName.TabIndex = 9;
            lblEquipName.Text = "備品名";
            // 
            // dgvEquipCate
            // 
            dgvEquipCate.AllowUserToAddRows = false;
            dgvEquipCate.AllowUserToDeleteRows = false;
            dgvEquipCate.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEquipCate.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEquipCate.Location = new Point(10, 115);
            dgvEquipCate.Name = "dgvEquipCate";
            dgvEquipCate.ReadOnly = true;
            dgvEquipCate.RowHeadersWidth = 51;
            dgvEquipCate.Size = new Size(1087, 269);
            dgvEquipCate.TabIndex = 10;
            dgvEquipCate.TabStop = false;
            dgvEquipCate.RowPostPaint += dgvEquipCate_RowPostPaint;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(336, 26);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(169, 89);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "編集";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdju
            // 
            btnAdju.Location = new Point(586, 26);
            btnAdju.Name = "btnAdju";
            btnAdju.Size = new Size(169, 89);
            btnAdju.TabIndex = 3;
            btnAdju.Text = "在庫調整";
            btnAdju.UseVisualStyleBackColor = true;
            btnAdju.Click += btnAdju_Click;
            // 
            // btnMaster
            // 
            btnMaster.Location = new Point(836, 26);
            btnMaster.Name = "btnMaster";
            btnMaster.Size = new Size(169, 89);
            btnMaster.TabIndex = 4;
            btnMaster.Text = "カテゴリマスタ管理";
            btnMaster.UseVisualStyleBackColor = true;
            btnMaster.Click += btnMaster_Click;
            // 
            // grpBottom
            // 
            grpBottom.Controls.Add(btnInsert);
            grpBottom.Controls.Add(btnMaster);
            grpBottom.Controls.Add(btnEdit);
            grpBottom.Controls.Add(btnAdju);
            grpBottom.Location = new Point(10, 381);
            grpBottom.Name = "grpBottom";
            grpBottom.Size = new Size(1087, 125);
            grpBottom.TabIndex = 14;
            grpBottom.TabStop = false;
            // 
            // grpTop
            // 
            grpTop.Controls.Add(btnSearch);
            grpTop.Controls.Add(txtEquip);
            grpTop.Controls.Add(cmbCategory);
            grpTop.Controls.Add(lblEquipName);
            grpTop.Controls.Add(lblCategory);
            grpTop.Location = new Point(12, 7);
            grpTop.Name = "grpTop";
            grpTop.Size = new Size(1085, 97);
            grpTop.TabIndex = 15;
            grpTop.TabStop = false;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1109, 517);
            Controls.Add(grpTop);
            Controls.Add(grpBottom);
            Controls.Add(dgvEquipCate);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "備品一覧画面";
            Load += frmMain_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEquipCate).EndInit();
            grpBottom.ResumeLayout(false);
            grpTop.ResumeLayout(false);
            grpTop.PerformLayout();
            ResumeLayout(false);
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
        private GroupBox grpBottom;
        private GroupBox grpTop;
    }
}
