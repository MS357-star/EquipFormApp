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
            dgvStock = new DataGridView();
            txtAdjuSum = new TextBox();
            cmbAdjuUnder = new ComboBox();
            btnEnter = new Button();
            button2 = new Button();
            lblAdjuSum = new Label();
            lblAdjuUnder = new Label();
            grpTop = new GroupBox();
            grpBottom = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvStock).BeginInit();
            grpTop.SuspendLayout();
            grpBottom.SuspendLayout();
            SuspendLayout();
            // 
            // dgvStock
            // 
            dgvStock.AllowUserToAddRows = false;
            dgvStock.AllowUserToDeleteRows = false;
            dgvStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStock.Location = new Point(12, 12);
            dgvStock.Name = "dgvStock";
            dgvStock.ReadOnly = true;
            dgvStock.RowHeadersWidth = 51;
            dgvStock.Size = new Size(420, 248);
            dgvStock.TabIndex = 0;
            // 
            // txtAdjuSum
            // 
            txtAdjuSum.Location = new Point(12, 68);
            txtAdjuSum.Name = "txtAdjuSum";
            txtAdjuSum.Size = new Size(150, 27);
            txtAdjuSum.TabIndex = 1;
            txtAdjuSum.TextAlign = HorizontalAlignment.Right;
            // 
            // cmbAdjuUnder
            // 
            cmbAdjuUnder.FormattingEnabled = true;
            cmbAdjuUnder.Location = new Point(11, 148);
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
            btnEnter.Text = "確定";
            btnEnter.UseVisualStyleBackColor = true;
            btnEnter.Click += btnEnter_Click;
            // 
            // button2
            // 
            button2.Location = new Point(358, 36);
            button2.Name = "button2";
            button2.Size = new Size(138, 65);
            button2.TabIndex = 4;
            button2.Text = "閉じる";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnClose_Click;
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
            lblAdjuUnder.Location = new Point(12, 125);
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
            grpTop.Location = new Point(439, 12);
            grpTop.Name = "grpTop";
            grpTop.Size = new Size(169, 248);
            grpTop.TabIndex = 7;
            grpTop.TabStop = false;
            // 
            // grpBottom
            // 
            grpBottom.Controls.Add(btnEnter);
            grpBottom.Controls.Add(button2);
            grpBottom.Location = new Point(12, 266);
            grpBottom.Name = "grpBottom";
            grpBottom.Size = new Size(595, 117);
            grpBottom.TabIndex = 8;
            grpBottom.TabStop = false;
            // 
            // Adju
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(618, 395);
            Controls.Add(grpBottom);
            Controls.Add(grpTop);
            Controls.Add(dgvStock);
            Name = "Adju";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "在庫調整画面";
            Load += Adju_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStock).EndInit();
            grpTop.ResumeLayout(false);
            grpTop.PerformLayout();
            grpBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvStock;
        private TextBox txtAdjuSum;
        private ComboBox cmbAdjuUnder;
        private Button btnEnter;
        private Button button2;
        private Label lblAdjuSum;
        private Label lblAdjuUnder;
        private GroupBox grpTop;
        private GroupBox grpBottom;
    }
}