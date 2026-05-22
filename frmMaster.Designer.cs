namespace EquipFormApp
{
    partial class frmMaster
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dgvCategory = new DataGridView();
            txtCateCode = new TextBox();
            txtCateName = new TextBox();
            btnInsert = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClose = new Button();
            lblCateCode = new Label();
            lblCateName = new Label();
            grpBottom = new GroupBox();
            grpTop = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvCategory).BeginInit();
            grpBottom.SuspendLayout();
            grpTop.SuspendLayout();
            SuspendLayout();
            // 
            // dgvCategory
            // 
            dgvCategory.AllowUserToAddRows = false;
            dgvCategory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.LightSkyBlue;
            dataGridViewCellStyle1.Font = new Font("Yu Gothic UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCategory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCategory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategory.EnableHeadersVisualStyles = false;
            dgvCategory.Location = new Point(12, 12);
            dgvCategory.Name = "dgvCategory";
            dgvCategory.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.LightSkyBlue;
            dataGridViewCellStyle2.Font = new Font("Yu Gothic UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvCategory.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvCategory.RowHeadersWidth = 51;
            dgvCategory.Size = new Size(420, 248);
            dgvCategory.TabIndex = 7;
            dgvCategory.TabStop = false;
            dgvCategory.CellClick += dgvCategory_CellClick;
            dgvCategory.RowPostPaint += dgvCategory_RowPostPaint;
            dgvCategory.KeyDown += btnInsert_KeyDown;
            // 
            // txtCateCode
            // 
            txtCateCode.Location = new Point(12, 78);
            txtCateCode.MaxLength = 3;
            txtCateCode.Name = "txtCateCode";
            txtCateCode.Size = new Size(150, 27);
            txtCateCode.TabIndex = 1;
            txtCateCode.TextChanged += txtCateCode_TextChanged;
            txtCateCode.KeyDown += txtCateCode_KeyDown;
            txtCateCode.Leave += txtCateCode_Leave;
            // 
            // txtCateName
            // 
            txtCateName.Location = new Point(12, 159);
            txtCateName.MaxLength = 20;
            txtCateName.Name = "txtCateName";
            txtCateName.Size = new Size(150, 27);
            txtCateName.TabIndex = 2;
            txtCateName.KeyDown += btnInsert_KeyDown;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(18, 30);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(113, 77);
            btnInsert.TabIndex = 3;
            btnInsert.Text = "追加(F1)";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            btnInsert.KeyDown += btnInsert_KeyDown;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(168, 30);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(113, 77);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "更新(F3)";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            btnUpdate.KeyDown += btnInsert_KeyDown;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(318, 30);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(113, 77);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "削除(F6)";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            btnDelete.KeyDown += btnInsert_KeyDown;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(468, 30);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(113, 77);
            btnClose.TabIndex = 6;
            btnClose.Text = "閉じる(F10)";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            btnClose.KeyDown += btnInsert_KeyDown;
            // 
            // lblCateCode
            // 
            lblCateCode.AutoSize = true;
            lblCateCode.Location = new Point(12, 55);
            lblCateCode.Name = "lblCateCode";
            lblCateCode.Size = new Size(83, 20);
            lblCateCode.TabIndex = 7;
            lblCateCode.Text = "カテゴリコード";
            // 
            // lblCateName
            // 
            lblCateName.AutoSize = true;
            lblCateName.Location = new Point(12, 136);
            lblCateName.Name = "lblCateName";
            lblCateName.Size = new Size(67, 20);
            lblCateName.TabIndex = 8;
            lblCateName.Text = "カテゴリ名";
            // 
            // grpBottom
            // 
            grpBottom.Controls.Add(btnInsert);
            grpBottom.Controls.Add(btnUpdate);
            grpBottom.Controls.Add(btnDelete);
            grpBottom.Controls.Add(btnClose);
            grpBottom.Location = new Point(12, 266);
            grpBottom.Name = "grpBottom";
            grpBottom.Size = new Size(597, 125);
            grpBottom.TabIndex = 9;
            grpBottom.TabStop = false;
            // 
            // grpTop
            // 
            grpTop.Controls.Add(txtCateName);
            grpTop.Controls.Add(txtCateCode);
            grpTop.Controls.Add(lblCateName);
            grpTop.Controls.Add(lblCateCode);
            grpTop.Location = new Point(438, 3);
            grpTop.Name = "grpTop";
            grpTop.Size = new Size(171, 257);
            grpTop.TabIndex = 10;
            grpTop.TabStop = false;
            // 
            // frmMaster
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(618, 395);
            Controls.Add(grpTop);
            Controls.Add(grpBottom);
            Controls.Add(dgvCategory);
            Name = "frmMaster";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "カテゴリマスタ管理画面";
            Activated += frmMaster_Activated;
            Load += frmMaster_Load;
            KeyDown += btnInsert_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dgvCategory).EndInit();
            grpBottom.ResumeLayout(false);
            grpTop.ResumeLayout(false);
            grpTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvCategory;
        private TextBox txtCateCode;
        private TextBox txtCateName;
        private Button btnInsert;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClose;
        private Label lblCateCode;
        private Label lblCateName;
        private GroupBox grpBottom;
        private GroupBox grpTop;
    }
}
