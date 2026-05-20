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
            btnControl = new Button();
            btnSearch = new Button();
            cmbCategory = new ComboBox();
            txtEquip = new TextBox();
            SuspendLayout();
            // 
            // btnControl
            // 
            btnControl.Location = new Point(159, 239);
            btnControl.Name = "btnControl";
            btnControl.Size = new Size(169, 89);
            btnControl.TabIndex = 7;
            btnControl.Text = "登録/開く";
            btnControl.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(271, 100);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(125, 48);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "検索";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(68, 54);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(151, 28);
            cmbCategory.TabIndex = 5;
            // 
            // txtEquip
            // 
            txtEquip.Location = new Point(68, 121);
            txtEquip.Name = "txtEquip";
            txtEquip.Size = new Size(125, 27);
            txtEquip.TabIndex = 4;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(494, 395);
            Controls.Add(btnControl);
            Controls.Add(btnSearch);
            Controls.Add(cmbCategory);
            Controls.Add(txtEquip);
            Name = "frmMain";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnControl;
        private Button btnSearch;
        private ComboBox cmbCategory;
        private TextBox txtEquip;
    }
}
