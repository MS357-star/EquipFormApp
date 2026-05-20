namespace EquipFormApp
{
    partial class frmSub
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
            txtEquipId = new TextBox();
            txtEquipName = new TextBox();
            txtEquipSum = new TextBox();
            txtEquipFrom = new TextBox();
            comboBox1 = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // txtEquipId
            // 
            txtEquipId.Location = new Point(66, 55);
            txtEquipId.Name = "txtEquipId";
            txtEquipId.Size = new Size(125, 27);
            txtEquipId.TabIndex = 0;
            // 
            // txtEquipName
            // 
            txtEquipName.Location = new Point(66, 88);
            txtEquipName.Name = "txtEquipName";
            txtEquipName.Size = new Size(125, 27);
            txtEquipName.TabIndex = 1;
            // 
            // txtEquipSum
            // 
            txtEquipSum.Location = new Point(66, 121);
            txtEquipSum.Name = "txtEquipSum";
            txtEquipSum.Size = new Size(125, 27);
            txtEquipSum.TabIndex = 2;
            // 
            // txtEquipFrom
            // 
            txtEquipFrom.Location = new Point(66, 154);
            txtEquipFrom.Name = "txtEquipFrom";
            txtEquipFrom.Size = new Size(125, 27);
            txtEquipFrom.TabIndex = 3;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(327, 28);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(97, 294);
            button1.Name = "button1";
            button1.Size = new Size(134, 67);
            button1.TabIndex = 5;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(327, 294);
            button2.Name = "button2";
            button2.Size = new Size(136, 67);
            button2.TabIndex = 6;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(66, 187);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(240, 53);
            textBox1.TabIndex = 7;
            // 
            // frmSub
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(535, 406);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(txtEquipFrom);
            Controls.Add(txtEquipSum);
            Controls.Add(txtEquipName);
            Controls.Add(txtEquipId);
            Name = "frmSub";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEquipId;
        private TextBox txtEquipName;
        private TextBox txtEquipSum;
        private TextBox txtEquipFrom;
        private ComboBox comboBox1;
        private Button button1;
        private Button button2;
        private TextBox textBox1;
    }
}