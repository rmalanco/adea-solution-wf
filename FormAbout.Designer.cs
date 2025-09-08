namespace adea_solution_wf.Services
{
    partial class FormAbout
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
            groupBox1 = new GroupBox();
            linkLabel5 = new LinkLabel();
            linkLabel4 = new LinkLabel();
            linkLabel3 = new LinkLabel();
            linkLabel2 = new LinkLabel();
            label3 = new Label();
            linkLabel1 = new LinkLabel();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(linkLabel5);
            groupBox1.Controls.Add(linkLabel4);
            groupBox1.Controls.Add(linkLabel3);
            groupBox1.Controls.Add(linkLabel2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(linkLabel1);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(458, 205);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Información del desarrollador";
            // 
            // linkLabel5
            // 
            linkLabel5.AutoSize = true;
            linkLabel5.Location = new Point(127, 167);
            linkLabel5.Name = "linkLabel5";
            linkLabel5.Size = new Size(269, 15);
            linkLabel5.TabIndex = 10;
            linkLabel5.TabStop = true;
            linkLabel5.Text = "https://github.com/rmalanco/adea-solution-web";
            linkLabel5.LinkClicked += linkLabel5_LinkClicked;
            // 
            // linkLabel4
            // 
            linkLabel4.AutoSize = true;
            linkLabel4.Location = new Point(127, 143);
            linkLabel4.Name = "linkLabel4";
            linkLabel4.Size = new Size(290, 15);
            linkLabel4.TabIndex = 9;
            linkLabel4.TabStop = true;
            linkLabel4.Text = "https://github.com/rmalanco/adea-solution-web-api";
            linkLabel4.LinkClicked += linkLabel4_LinkClicked;
            // 
            // linkLabel3
            // 
            linkLabel3.AutoSize = true;
            linkLabel3.Location = new Point(127, 119);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new Size(260, 15);
            linkLabel3.TabIndex = 8;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "https://github.com/rmalanco/adea-solution-wf";
            linkLabel3.LinkClicked += linkLabel3_LinkClicked;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(61, 93);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(164, 15);
            linkLabel2.TabIndex = 7;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "https://github.com/rmalanco";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 119);
            label3.Name = "label3";
            label3.Size = new Size(115, 15);
            label3.TabIndex = 6;
            label3.Text = "GitHub Project links:";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(70, 68);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(84, 15);
            linkLabel1.TabIndex = 5;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "rmalanco.com";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 93);
            label5.Name = "label5";
            label5.Size = new Size(49, 15);
            label5.TabIndex = 4;
            label5.Text = "Github: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 68);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 3;
            label4.Text = "Sitio web:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 44);
            label2.Name = "label2";
            label2.Size = new Size(187, 15);
            label2.TabIndex = 1;
            label2.Text = "Correo: rmalanco@rmalanco.com";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(153, 15);
            label1.TabIndex = 0;
            label1.Text = "Creado por: Rafael Malanco";
            // 
            // FormAbout
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(482, 229);
            Controls.Add(groupBox1);
            Name = "FormAbout";
            StartPosition = FormStartPosition.CenterParent;
            Text = "About";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label4;
        private Label label2;
        private Label label1;
        private Label label5;
        private LinkLabel linkLabel1;
        private Label label3;
        private LinkLabel linkLabel5;
        private LinkLabel linkLabel4;
        private LinkLabel linkLabel3;
        private LinkLabel linkLabel2;
    }
}