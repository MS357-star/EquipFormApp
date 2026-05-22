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
            SuspendLayout();
            // 
            // txtEquipName
            // 
            txtEquipName.Location = new Point(132, 115);
            txtEquipName.Name = "txtEquipName";
            txtEquipName.Size = new Size(125, 27);
            txtEquipName.TabIndex = 1;
            // 
            // txtEquipSum
            // 
            txtEquipSum.Location = new Point(132, 148);
            txtEquipSum.Name = "txtEquipSum";
            txtEquipSum.Size = new Size(125, 27);
            txtEquipSum.TabIndex = 2;
            txtEquipSum.KeyPress += txtEquipSum_KeyPress;
            txtEquipSum.Leave += txtEquipSum_Leave;
            // 
            // txtEquipFrom
            // 
            txtEquipFrom.Location = new Point(132, 181);
            txtEquipFrom.Name = "txtEquipFrom";
            txtEquipFrom.Size = new Size(125, 27);
            txtEquipFrom.TabIndex = 3;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(132, 34);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(151, 28);
            cmbCategory.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(45, 307);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(134, 67);
            btnSave.TabIndex = 5;
            btnSave.Text = "保存";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(256, 307);
            btnClose.Name = "btnClose";
            btnClose.RightToLeft = RightToLeft.No;
            btnClose.Size = new Size(136, 67);
            btnClose.TabIndex = 6;
            btnClose.Text = "閉じる";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // txtRem
            // 
            txtRem.Location = new Point(132, 214);
            txtRem.Multiline = true;
            txtRem.Name = "txtRem";
            txtRem.Size = new Size(240, 53);
            txtRem.TabIndex = 7;
            // 
            // lblEquipID
            // 
            lblEquipID.AutoSize = true;
            lblEquipID.Location = new Point(72, 89);
            lblEquipID.Name = "lblEquipID";
            lblEquipID.Size = new Size(54, 20);
            lblEquipID.TabIndex = 8;
            lblEquipID.Text = "備品ID";
            // 
            // lblEquipName
            // 
            lblEquipName.AutoSize = true;
            lblEquipName.Location = new Point(72, 122);
            lblEquipName.Name = "lblEquipName";
            lblEquipName.Size = new Size(54, 20);
            lblEquipName.TabIndex = 9;
            lblEquipName.Text = "備品名";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(74, 42);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(52, 20);
            lblCategory.TabIndex = 10;
            lblCategory.Text = "カテゴリ";
            // 
            // lblEquipSum
            // 
            lblEquipSum.AutoSize = true;
            lblEquipSum.Location = new Point(72, 155);
            lblEquipSum.Name = "lblEquipSum";
            lblEquipSum.Size = new Size(54, 20);
            lblEquipSum.TabIndex = 11;
            lblEquipSum.Text = "在庫数";
            // 
            // lblEquipFrom
            // 
            lblEquipFrom.AutoSize = true;
            lblEquipFrom.Location = new Point(57, 188);
            lblEquipFrom.Name = "lblEquipFrom";
            lblEquipFrom.Size = new Size(69, 20);
            lblEquipFrom.TabIndex = 12;
            lblEquipFrom.Text = "保管場所";
            // 
            // lblRem
            // 
            lblRem.AutoSize = true;
            lblRem.Location = new Point(87, 247);
            lblRem.Name = "lblRem";
            lblRem.Size = new Size(39, 20);
            lblRem.TabIndex = 13;
            lblRem.Text = "備考";
            // 
            // txtEquipId
            // 
            txtEquipId.Location = new Point(132, 82);
            txtEquipId.Mask = "\\E\\Q0000";
            txtEquipId.Name = "txtEquipId";
            txtEquipId.PromptChar = ' ';
            txtEquipId.Size = new Size(125, 27);
            txtEquipId.TabIndex = 14;
            txtEquipId.Enter += txtEquipId_Enter;
            // 
            // frmEdit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(427, 406);
            Controls.Add(txtEquipId);
            Controls.Add(lblRem);
            Controls.Add(lblEquipFrom);
            Controls.Add(lblEquipSum);
            Controls.Add(lblCategory);
            Controls.Add(lblEquipName);
            Controls.Add(lblEquipID);
            Controls.Add(txtRem);
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            Controls.Add(cmbCategory);
            Controls.Add(txtEquipFrom);
            Controls.Add(txtEquipSum);
            Controls.Add(txtEquipName);
            Name = "frmEdit";
            Text = "備品登録・編集画面";
            Load += frmEdit_Load;
            ResumeLayout(false);
            PerformLayout();
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
    }
}