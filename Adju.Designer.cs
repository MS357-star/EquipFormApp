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
            ((System.ComponentModel.ISupportInitialize)dgvStock).BeginInit();
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
            dgvStock.Size = new Size(402, 270);
            dgvStock.TabIndex = 0;
            // 
            // txtAdjuSum
            // 
            txtAdjuSum.Location = new Point(447, 113);
            txtAdjuSum.Name = "txtAdjuSum";
            txtAdjuSum.Size = new Size(125, 27);
            txtAdjuSum.TabIndex = 1;
            // 
            // cmbAdjuUnder
            // 
            cmbAdjuUnder.FormattingEnabled = true;
            cmbAdjuUnder.Location = new Point(447, 216);
            cmbAdjuUnder.Name = "cmbAdjuUnder";
            cmbAdjuUnder.Size = new Size(151, 28);
            cmbAdjuUnder.TabIndex = 2;
            // 
            // btnEnter
            // 
            btnEnter.Location = new Point(112, 321);
            btnEnter.Name = "btnEnter";
            btnEnter.Size = new Size(138, 65);
            btnEnter.TabIndex = 3;
            btnEnter.Text = "確定";
            btnEnter.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(378, 321);
            button2.Name = "button2";
            button2.Size = new Size(138, 65);
            button2.TabIndex = 4;
            button2.Text = "閉じる";
            button2.UseVisualStyleBackColor = true;
            // 
            // lblAdjuSum
            // 
            lblAdjuSum.AutoSize = true;
            lblAdjuSum.Location = new Point(447, 90);
            lblAdjuSum.Name = "lblAdjuSum";
            lblAdjuSum.Size = new Size(54, 20);
            lblAdjuSum.TabIndex = 5;
            lblAdjuSum.Text = "調整数";
            // 
            // lblAdjuUnder
            // 
            lblAdjuUnder.AutoSize = true;
            lblAdjuUnder.Location = new Point(447, 193);
            lblAdjuUnder.Name = "lblAdjuUnder";
            lblAdjuUnder.Size = new Size(69, 20);
            lblAdjuUnder.TabIndex = 6;
            lblAdjuUnder.Text = "調整理由";
            // 
            // Adju
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(619, 416);
            Controls.Add(lblAdjuUnder);
            Controls.Add(lblAdjuSum);
            Controls.Add(button2);
            Controls.Add(btnEnter);
            Controls.Add(cmbAdjuUnder);
            Controls.Add(txtAdjuSum);
            Controls.Add(dgvStock);
            Name = "Adju";
            Text = "在庫調整画面";
            ((System.ComponentModel.ISupportInitialize)dgvStock).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvStock;
        private TextBox txtAdjuSum;
        private ComboBox cmbAdjuUnder;
        private Button btnEnter;
        private Button button2;
        private Label lblAdjuSum;
        private Label lblAdjuUnder;
    }
}