namespace adea_solution_wf
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            dataGridViewCajas = new DataGridView();
            radioButton1 = new RadioButton();
            groupBoxType = new GroupBox();
            radioButton2 = new RadioButton();
            panel1 = new Panel();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCajas).BeginInit();
            groupBoxType.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewCajas
            // 
            dataGridViewCajas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCajas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCajas.Location = new Point(12, 12);
            dataGridViewCajas.Name = "dataGridViewCajas";
            dataGridViewCajas.Size = new Size(606, 490);
            dataGridViewCajas.TabIndex = 0;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(15, 22);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(48, 19);
            radioButton1.TabIndex = 1;
            radioButton1.Text = "Caja";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // groupBoxType
            // 
            groupBoxType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBoxType.Controls.Add(button1);
            groupBoxType.Controls.Add(radioButton2);
            groupBoxType.Controls.Add(radioButton1);
            groupBoxType.Location = new Point(624, 12);
            groupBoxType.Name = "groupBoxType";
            groupBoxType.Size = new Size(284, 57);
            groupBoxType.TabIndex = 2;
            groupBoxType.TabStop = false;
            groupBoxType.Text = "Tipo Movimiento";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(69, 22);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(83, 19);
            radioButton2.TabIndex = 2;
            radioButton2.Text = "Expediente";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panel1.Location = new Point(624, 75);
            panel1.Name = "panel1";
            panel1.Size = new Size(284, 427);
            panel1.TabIndex = 3;
            // 
            // button1
            // 
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(241, 16);
            button1.Name = "button1";
            button1.Size = new Size(35, 31);
            button1.TabIndex = 3;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(912, 514);
            Controls.Add(panel1);
            Controls.Add(groupBoxType);
            Controls.Add(dataGridViewCajas);
            MinimumSize = new Size(928, 553);
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdeA Solution";
            Load += Main_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewCajas).EndInit();
            groupBoxType.ResumeLayout(false);
            groupBoxType.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private RadioButton radioButton1;
        private GroupBox groupBoxType;
        private RadioButton radioButton2;
        private Panel panel1;
        private DataGridView dataGridViewCajas;
        private Button button1;
    }
}
