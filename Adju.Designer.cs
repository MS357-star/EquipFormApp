namespace EquipFormApp
{
    partial class Adju
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
            txtAdjuSum = new TextBox();
            cmbAdjuUnder = new ComboBox();
            btnEnter = new Button();
            btnClose = new Button();
            lblAdjuSum = new Label();
            lblAdjuUnder = new Label();
            grpTop = new GroupBox();
            grpBottom = new GroupBox();
            lbl1 = new Label();
            txtEquipId = new TextBox();
            lbl2 = new Label();
            txtEquipName = new TextBox();
            lbl3 = new Label();
            txtCurrentStock = new TextBox();
            grpinfo = new GroupBox();
            grpTop.SuspendLayout();
            grpBottom.SuspendLayout();
            grpinfo.SuspendLayout();
            SuspendLayout();
            // 
            // txtAdjuSum
            // 
            txtAdjuSum.Location = new Point(12, 68);
            txtAdjuSum.MaxLength = 5;
            txtAdjuSum.Name = "txtAdjuSum";
            txtAdjuSum.Size = new Size(150, 27);
            txtAdjuSum.TabIndex = 1;
            txtAdjuSum.TextAlign = HorizontalAlignment.Right;
            txtAdjuSum.KeyPress += txtAdjuSum_KeyPress;
            txtAdjuSum.Leave += txtAdjuSum_Leave;
            // 
            // cmbAdjuUnder
            // 
            cmbAdjuUnder.FormattingEnabled = true;
            cmbAdjuUnder.Location = new Point(181, 68);
            cmbAdjuUnder.Name = "cmbAdjuUnder";
            cmbAdjuUnder.Size = new Size(151, 28);
            cmbAdjuUnder.TabIndex = 2;
            // 
            // btnEnter
            // 
            btnEnter.Location = new Point(100, 36);
            btnEnter.Name = "btnEnter";
            btnEnter.Size = new Size(138, 65);
            btnEnter.TabIndex = 3;
            btnEnter.Text = "確定(F1)";
            btnEnter.UseVisualStyleBackColor = true;
            btnEnter.Click += btnEnter_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(358, 36);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(138, 65);
            btnClose.TabIndex = 4;
            btnClose.Text = "閉じる(F10)";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblAdjuSum
            // 
            lblAdjuSum.AutoSize = true;
            lblAdjuSum.Location = new Point(12, 45);
            lblAdjuSum.Name = "lblAdjuSum";
            lblAdjuSum.Size = new Size(54, 20);
            lblAdjuSum.TabIndex = 5;
            lblAdjuSum.Text = "調整数";
            // 
            // lblAdjuUnder
            // 
            lblAdjuUnder.AutoSize = true;
            lblAdjuUnder.Location = new Point(181, 45);
            lblAdjuUnder.Name = "lblAdjuUnder";
            lblAdjuUnder.Size = new Size(69, 20);
            lblAdjuUnder.TabIndex = 6;
            lblAdjuUnder.Text = "調整理由";
            // 
            // grpTop
            // 
            grpTop.Controls.Add(cmbAdjuUnder);
            grpTop.Controls.Add(txtAdjuSum);
            grpTop.Controls.Add(lblAdjuUnder);
            grpTop.Controls.Add(lblAdjuSum);
            grpTop.Location = new Point(270, 12);
            grpTop.Name = "grpTop";
            grpTop.Size = new Size(338, 155);
            grpTop.TabIndex = 7;
            grpTop.TabStop = false;
            // 
            // grpBottom
            // 
            grpBottom.Controls.Add(btnEnter);
            grpBottom.Controls.Add(btnClose);
            grpBottom.Location = new Point(13, 173);
            grpBottom.Name = "grpBottom";
            grpBottom.Size = new Size(595, 117);
            grpBottom.TabIndex = 8;
            grpBottom.TabStop = false;
            // 
            // lbl1
            // 
            lbl1.AutoSize = true;
            lbl1.Location = new Point(53, 29);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(54, 20);
            lbl1.TabIndex = 9;
            lbl1.Text = "備品ID";
            // 
            // txtEquipId
            // 
            txtEquipId.Location = new Point(113, 26);
            txtEquipId.Name = "txtEquipId";
            txtEquipId.ReadOnly = true;
            txtEquipId.Size = new Size(125, 27);
            txtEquipId.TabIndex = 10;
            txtEquipId.TabStop = false;
            // 
            // lbl2
            // 
            lbl2.AutoSize = true;
            lbl2.Location = new Point(53, 72);
            lbl2.Name = "lbl2";
            lbl2.Size = new Size(54, 20);
            lbl2.TabIndex = 11;
            lbl2.Text = "備品名";
            // 
            // txtEquipName
            // 
            txtEquipName.Location = new Point(113, 69);
            txtEquipName.Name = "txtEquipName";
            txtEquipName.ReadOnly = true;
            txtEquipName.Size = new Size(125, 27);
            txtEquipName.TabIndex = 12;
            txtEquipName.TabStop = false;
            // 
            // lbl3
            // 
            lbl3.AutoSize = true;
            lbl3.Location = new Point(11, 116);
            lbl3.Name = "lbl3";
            lbl3.Size = new Size(96, 20);
            lbl3.TabIndex = 13;
            lbl3.Text = "現在の在庫数";
            // 
            // txtCurrentStock
            // 
            txtCurrentStock.Location = new Point(113, 113);
            txtCurrentStock.Name = "txtCurrentStock";
            txtCurrentStock.ReadOnly = true;
            txtCurrentStock.Size = new Size(125, 27);
            txtCurrentStock.TabIndex = 14;
            txtCurrentStock.TabStop = false;
            // 
            // grpinfo
            // 
            grpinfo.Controls.Add(lbl1);
            grpinfo.Controls.Add(txtEquipId);
            grpinfo.Controls.Add(txtEquipName);
            grpinfo.Controls.Add(txtCurrentStock);
            grpinfo.Controls.Add(lbl2);
            grpinfo.Controls.Add(lbl3);
            grpinfo.Location = new Point(13, 12);
            grpinfo.Name = "grpinfo";
            grpinfo.Size = new Size(251, 155);
            grpinfo.TabIndex = 15;
            grpinfo.TabStop = false;
            // 
            // Adju
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(618, 304);
            Controls.Add(grpinfo);
            Controls.Add(grpBottom);
            Controls.Add(grpTop);
            KeyPreview = true;
            Name = "Adju";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "在庫調整画面";
            Load += Adju_Load;
            KeyDown += Adju_KeyDown;
            grpTop.ResumeLayout(false);
            grpTop.PerformLayout();
            grpBottom.ResumeLayout(false);
            grpinfo.ResumeLayout(false);
            grpinfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TextBox txtAdjuSum;
        private ComboBox cmbAdjuUnder;
        private Button btnEnter;
        private Button btnClose;
        private Label lblAdjuSum;
        private Label lblAdjuUnder;
        private GroupBox grpTop;
        private GroupBox grpBottom;
        private Label lbl1;
        private TextBox txtEquipId;
        private Label lbl2;
        private TextBox txtEquipName;
        private Label lbl3;
        private TextBox txtCurrentStock;
        private GroupBox grpinfo;
    }
}
