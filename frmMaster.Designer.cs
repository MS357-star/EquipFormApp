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
            dgvCategory = new DataGridView();
            txtCateCode = new TextBox();
            txtCateName = new TextBox();
            btnInsert = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClose = new Button();
            lblCateCode = new Label();
            lblCateName = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCategory).BeginInit();
            SuspendLayout();
            // 
            // dgvCategory
            // 
            dgvCategory.AllowUserToAddRows = false;
            dgvCategory.AllowUserToDeleteRows = false;
            dgvCategory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategory.Location = new Point(12, 12);
            dgvCategory.Name = "dgvCategory";
            dgvCategory.ReadOnly = true;
            dgvCategory.RowHeadersWidth = 51;
            dgvCategory.Size = new Size(420, 248);
            dgvCategory.TabIndex = 0;
            // 
            // txtCateCode
            // 
            txtCateCode.Location = new Point(462, 83);
            txtCateCode.Name = "txtCateCode";
            txtCateCode.Size = new Size(125, 27);
            txtCateCode.TabIndex = 1;
            // 
            // txtCateName
            // 
            txtCateName.Location = new Point(462, 164);
            txtCateName.Name = "txtCateName";
            txtCateName.Size = new Size(125, 27);
            txtCateName.TabIndex = 2;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(71, 293);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(113, 77);
            btnInsert.TabIndex = 3;
            btnInsert.Text = "追加";
            btnInsert.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(196, 293);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(113, 77);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "更新";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(319, 293);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(113, 77);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "削除";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(441, 293);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(113, 77);
            btnClose.TabIndex = 6;
            btnClose.Text = "閉じる";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // lblCateCode
            // 
            lblCateCode.AutoSize = true;
            lblCateCode.Location = new Point(462, 60);
            lblCateCode.Name = "lblCateCode";
            lblCateCode.Size = new Size(83, 20);
            lblCateCode.TabIndex = 7;
            lblCateCode.Text = "カテゴリコード";
            // 
            // lblCateName
            // 
            lblCateName.AutoSize = true;
            lblCateName.Location = new Point(462, 141);
            lblCateName.Name = "lblCateName";
            lblCateName.Size = new Size(67, 20);
            lblCateName.TabIndex = 8;
            lblCateName.Text = "カテゴリ名";
            // 
            // frmMaster
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(621, 397);
            Controls.Add(lblCateName);
            Controls.Add(lblCateCode);
            Controls.Add(btnClose);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnInsert);
            Controls.Add(txtCateName);
            Controls.Add(txtCateCode);
            Controls.Add(dgvCategory);
            Name = "frmMaster";
            Text = "カテゴリマスタ管理画面";
            ((System.ComponentModel.ISupportInitialize)dgvCategory).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
    }
}