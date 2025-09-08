namespace adea_solution_wf
{
    partial class FormCaja
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
            groupBoxTitle = new GroupBox();
            buttonCancel = new Button();
            buttonDelete = new Button();
            buttonEdit = new Button();
            buttonSave = new Button();
            textBoxIdCaja = new TextBox();
            label3 = new Label();
            label2 = new Label();
            comboBoxLocations = new ComboBox();
            comboBoxStatus = new ComboBox();
            label1 = new Label();
            buttonNew = new Button();
            groupBoxTitle.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxTitle
            // 
            groupBoxTitle.Controls.Add(buttonNew);
            groupBoxTitle.Controls.Add(buttonCancel);
            groupBoxTitle.Controls.Add(buttonDelete);
            groupBoxTitle.Controls.Add(buttonEdit);
            groupBoxTitle.Controls.Add(buttonSave);
            groupBoxTitle.Controls.Add(textBoxIdCaja);
            groupBoxTitle.Controls.Add(label3);
            groupBoxTitle.Controls.Add(label2);
            groupBoxTitle.Controls.Add(comboBoxLocations);
            groupBoxTitle.Controls.Add(comboBoxStatus);
            groupBoxTitle.Controls.Add(label1);
            groupBoxTitle.Location = new Point(5, 7);
            groupBoxTitle.Name = "groupBoxTitle";
            groupBoxTitle.Size = new Size(274, 416);
            groupBoxTitle.TabIndex = 0;
            groupBoxTitle.TabStop = false;
            groupBoxTitle.Text = "Caja";
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(192, 385);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 9;
            buttonCancel.Text = "Cancelar";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(111, 385);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(75, 23);
            buttonDelete.TabIndex = 8;
            buttonDelete.Text = "Eliminar";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.Location = new Point(192, 356);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(75, 23);
            buttonEdit.TabIndex = 7;
            buttonEdit.Text = "Editar";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(111, 356);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 6;
            buttonSave.Text = "Guardar";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // textBoxIdCaja
            // 
            textBoxIdCaja.Location = new Point(76, 22);
            textBoxIdCaja.Name = "textBoxIdCaja";
            textBoxIdCaja.ReadOnly = true;
            textBoxIdCaja.Size = new Size(191, 23);
            textBoxIdCaja.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 25);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 4;
            label3.Text = "#Caja";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 83);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 3;
            label2.Text = "Ubicación:";
            // 
            // comboBoxLocations
            // 
            comboBoxLocations.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLocations.FormattingEnabled = true;
            comboBoxLocations.Location = new Point(76, 80);
            comboBoxLocations.Name = "comboBoxLocations";
            comboBoxLocations.Size = new Size(191, 23);
            comboBoxLocations.TabIndex = 2;
            // 
            // comboBoxStatus
            // 
            comboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStatus.FormattingEnabled = true;
            comboBoxStatus.Location = new Point(76, 51);
            comboBoxStatus.Name = "comboBoxStatus";
            comboBoxStatus.Size = new Size(191, 23);
            comboBoxStatus.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 54);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 0;
            label1.Text = "Estado:";
            // 
            // buttonNew
            // 
            buttonNew.Location = new Point(30, 356);
            buttonNew.Name = "buttonNew";
            buttonNew.Size = new Size(75, 23);
            buttonNew.TabIndex = 10;
            buttonNew.Text = "Nuevo";
            buttonNew.UseVisualStyleBackColor = true;
            buttonNew.Click += buttonNew_Click;
            // 
            // FormCaja
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 427);
            Controls.Add(groupBoxTitle);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormCaja";
            Text = "FormCaja";
            groupBoxTitle.ResumeLayout(false);
            groupBoxTitle.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxTitle;
        private Label label1;
        private Label label2;
        private ComboBox comboBoxLocations;
        private ComboBox comboBoxStatus;
        private Button buttonSave;
        private TextBox textBoxIdCaja;
        private Label label3;
        private Button buttonCancel;
        private Button buttonDelete;
        private Button buttonEdit;
        private Button buttonNew;
    }
}