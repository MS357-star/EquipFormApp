namespace EquipFormApp
{
    partial class frmEdit
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
            txtEquipName = new TextBox();
            txtEquipSum = new TextBox();
            txtEquipFrom = new TextBox();
            cmbCategory = new ComboBox();
            btnSave = new Button();
            btnClose = new Button();
            txtRem = new TextBox();
            lblEquipID = new Label();
            lblEquipName = new Label();
            lblCategory = new Label();
            lblEquipSum = new Label();
            lblEquipFrom = new Label();
            lblRem = new Label();
            txtEquipId = new MaskedTextBox();
            grpTop = new GroupBox();
            grpBottom = new GroupBox();
            grpTop.SuspendLayout();
            grpBottom.SuspendLayout();
            SuspendLayout();
            // 
            // txtEquipName
            // 
            txtEquipName.Location = new Point(110, 108);
            txtEquipName.MaxLength = 50;
            txtEquipName.Name = "txtEquipName";
            txtEquipName.Size = new Size(125, 27);
            txtEquipName.TabIndex = 2;
            txtEquipName.KeyDown += frmEdit_KeyDown;
            // 
            // txtEquipSum
            // 
            txtEquipSum.Location = new Point(110, 141);
            txtEquipSum.MaxLength = 6;
            txtEquipSum.Name = "txtEquipSum";
            txtEquipSum.Size = new Size(125, 27);
            txtEquipSum.TabIndex = 3;
            txtEquipSum.TextAlign = HorizontalAlignment.Right;
            txtEquipSum.TextChanged += txtEquipSum_TextChanged;
            txtEquipSum.KeyDown += frmEdit_KeyDown;
            txtEquipSum.KeyPress += txtEquipSum_KeyPress;
            txtEquipSum.Leave += txtEquipSum_Leave;
            // 
            // txtEquipFrom
            // 
            txtEquipFrom.Location = new Point(110, 174);
            txtEquipFrom.MaxLength = 30;
            txtEquipFrom.Name = "txtEquipFrom";
            txtEquipFrom.Size = new Size(125, 27);
            txtEquipFrom.TabIndex = 4;
            txtEquipFrom.KeyDown += frmEdit_KeyDown;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(110, 27);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(151, 28);
            cmbCategory.TabIndex = 0;
            cmbCategory.KeyDown += frmEdit_KeyDown;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(38, 21);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(134, 67);
            btnSave.TabIndex = 6;
            btnSave.Text = "保存(F1)";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            btnSave.KeyDown += frmEdit_KeyDown;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(209, 21);
            btnClose.Name = "btnClose";
            btnClose.RightToLeft = RightToLeft.No;
            btnClose.Size = new Size(136, 67);
            btnClose.TabIndex = 7;
            btnClose.Text = "閉じる(F10)";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            btnClose.KeyDown += frmEdit_KeyDown;
            // 
            // txtRem
            // 
            txtRem.Location = new Point(110, 207);
            txtRem.MaxLength = 200;
            txtRem.Multiline = true;
            txtRem.Name = "txtRem";
            txtRem.Size = new Size(240, 53);
            txtRem.TabIndex = 5;
            txtRem.KeyDown += frmEdit_KeyDown;
            // 
            // lblEquipID
            // 
            lblEquipID.AutoSize = true;
            lblEquipID.Location = new Point(50, 78);
            lblEquipID.Name = "lblEquipID";
            lblEquipID.Size = new Size(54, 20);
            lblEquipID.TabIndex = 8;
            lblEquipID.Text = "備品ID";
            // 
            // lblEquipName
            // 
            lblEquipName.AutoSize = true;
            lblEquipName.Location = new Point(50, 111);
            lblEquipName.Name = "lblEquipName";
            lblEquipName.Size = new Size(54, 20);
            lblEquipName.TabIndex = 9;
            lblEquipName.Text = "備品名";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(52, 30);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(52, 20);
            lblCategory.TabIndex = 10;
            lblCategory.Text = "カテゴリ";
            // 
            // lblEquipSum
            // 
            lblEquipSum.AutoSize = true;
            lblEquipSum.Location = new Point(50, 144);
            lblEquipSum.Name = "lblEquipSum";
            lblEquipSum.Size = new Size(54, 20);
            lblEquipSum.TabIndex = 11;
            lblEquipSum.Text = "在庫数";
            // 
            // lblEquipFrom
            // 
            lblEquipFrom.AutoSize = true;
            lblEquipFrom.Location = new Point(35, 177);
            lblEquipFrom.Name = "lblEquipFrom";
            lblEquipFrom.Size = new Size(69, 20);
            lblEquipFrom.TabIndex = 12;
            lblEquipFrom.Text = "保管場所";
            // 
            // lblRem
            // 
            lblRem.AutoSize = true;
            lblRem.Location = new Point(65, 210);
            lblRem.Name = "lblRem";
            lblRem.Size = new Size(39, 20);
            lblRem.TabIndex = 13;
            lblRem.Text = "備考";
            // 
            // txtEquipId
            // 
            txtEquipId.Location = new Point(110, 75);
            txtEquipId.Mask = "\\E\\Q0000";
            txtEquipId.Name = "txtEquipId";
            txtEquipId.PromptChar = ' ';
            txtEquipId.Size = new Size(125, 27);
            txtEquipId.TabIndex = 1;
            txtEquipId.Enter += txtEquipId_Enter;
            txtEquipId.KeyDown += txtEquipId_KeyDown;
            txtEquipId.KeyPress += txtEquipId_KeyPress;
            txtEquipId.Validating += txtEquipId_Validating;
            // 
            // grpTop
            // 
            grpTop.Controls.Add(txtRem);
            grpTop.Controls.Add(txtEquipId);
            grpTop.Controls.Add(txtEquipName);
            grpTop.Controls.Add(lblRem);
            grpTop.Controls.Add(txtEquipSum);
            grpTop.Controls.Add(lblEquipFrom);
            grpTop.Controls.Add(txtEquipFrom);
            grpTop.Controls.Add(lblEquipSum);
            grpTop.Controls.Add(cmbCategory);
            grpTop.Controls.Add(lblCategory);
            grpTop.Controls.Add(lblEquipID);
            grpTop.Controls.Add(lblEquipName);
            grpTop.Location = new Point(12, 12);
            grpTop.Name = "grpTop";
            grpTop.Size = new Size(380, 279);
            grpTop.TabIndex = 8;
            grpTop.TabStop = false;
            // 
            // grpBottom
            // 
            grpBottom.Controls.Add(btnSave);
            grpBottom.Controls.Add(btnClose);
            grpBottom.Location = new Point(12, 297);
            grpBottom.Name = "grpBottom";
            grpBottom.Size = new Size(380, 97);
            grpBottom.TabIndex = 9;
            grpBottom.TabStop = false;
            // 
            // frmEdit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 406);
            Controls.Add(grpBottom);
            Controls.Add(grpTop);
            Name = "frmEdit";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "備品登録・編集画面";
            Activated += frmEdit_Activated;
            Load += frmEdit_Load;
            KeyDown += frmEdit_KeyDown;
            grpTop.ResumeLayout(false);
            grpTop.PerformLayout();
            grpBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TextBox txtEquipName;
        private TextBox txtEquipSum;
        private TextBox txtEquipFrom;
        private ComboBox cmbCategory;
        private Button btnSave;
        private Button btnClose;
        private TextBox txtRem;
        private Label lblEquipID;
        private Label lblEquipName;
        private Label lblCategory;
        private Label lblEquipSum;
        private Label lblEquipFrom;
        private Label lblRem;
        private MaskedTextBox txtEquipId;
        private GroupBox grpTop;
        private GroupBox grpBottom;
    }
}
