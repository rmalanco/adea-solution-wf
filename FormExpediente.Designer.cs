namespace adea_solution_wf
{
    partial class FormExpediente
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
            textBoxNameEmployee = new TextBox();
            comboBoxCaja = new ComboBox();
            buttonCancel = new Button();
            buttonDelete = new Button();
            buttonEdit = new Button();
            buttonSave = new Button();
            label3 = new Label();
            label2 = new Label();
            comboBoxExpediente = new ComboBox();
            labelNameEmployee = new Label();
            buttonNew = new Button();
            groupBoxTitle.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxTitle
            // 
            groupBoxTitle.Controls.Add(buttonNew);
            groupBoxTitle.Controls.Add(textBoxNameEmployee);
            groupBoxTitle.Controls.Add(comboBoxCaja);
            groupBoxTitle.Controls.Add(buttonCancel);
            groupBoxTitle.Controls.Add(buttonDelete);
            groupBoxTitle.Controls.Add(buttonEdit);
            groupBoxTitle.Controls.Add(buttonSave);
            groupBoxTitle.Controls.Add(label3);
            groupBoxTitle.Controls.Add(label2);
            groupBoxTitle.Controls.Add(comboBoxExpediente);
            groupBoxTitle.Controls.Add(labelNameEmployee);
            groupBoxTitle.Location = new Point(5, 5);
            groupBoxTitle.Name = "groupBoxTitle";
            groupBoxTitle.Size = new Size(274, 416);
            groupBoxTitle.TabIndex = 1;
            groupBoxTitle.TabStop = false;
            groupBoxTitle.Text = "Caja";
            // 
            // textBoxNameEmployee
            // 
            textBoxNameEmployee.Location = new Point(7, 44);
            textBoxNameEmployee.Name = "textBoxNameEmployee";
            textBoxNameEmployee.Size = new Size(260, 23);
            textBoxNameEmployee.TabIndex = 11;
            // 
            // comboBoxCaja
            // 
            comboBoxCaja.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCaja.FormattingEnabled = true;
            comboBoxCaja.Location = new Point(107, 73);
            comboBoxCaja.Name = "comboBoxCaja";
            comboBoxCaja.Size = new Size(160, 23);
            comboBoxCaja.TabIndex = 10;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(192, 387);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 9;
            buttonCancel.Text = "Cancelar";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(111, 387);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(75, 23);
            buttonDelete.TabIndex = 8;
            buttonDelete.Text = "Eliminar";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.Location = new Point(192, 358);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(75, 23);
            buttonEdit.TabIndex = 7;
            buttonEdit.Text = "Editar";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(111, 358);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 6;
            buttonSave.Text = "Guardar";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(68, 76);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 4;
            label3.Text = "Caja:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 105);
            label2.Name = "label2";
            label2.Size = new Size(94, 15);
            label2.TabIndex = 3;
            label2.Text = "Tipo Expediente:";
            // 
            // comboBoxExpediente
            // 
            comboBoxExpediente.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxExpediente.FormattingEnabled = true;
            comboBoxExpediente.Location = new Point(107, 102);
            comboBoxExpediente.Name = "comboBoxExpediente";
            comboBoxExpediente.Size = new Size(160, 23);
            comboBoxExpediente.TabIndex = 2;
            // 
            // labelNameEmployee
            // 
            labelNameEmployee.AutoSize = true;
            labelNameEmployee.Location = new Point(7, 26);
            labelNameEmployee.Name = "labelNameEmployee";
            labelNameEmployee.Size = new Size(126, 15);
            labelNameEmployee.TabIndex = 0;
            labelNameEmployee.Text = "Nombre del empleado";
            // 
            // buttonNew
            // 
            buttonNew.Location = new Point(30, 358);
            buttonNew.Name = "buttonNew";
            buttonNew.Size = new Size(75, 23);
            buttonNew.TabIndex = 12;
            buttonNew.Text = "Nuevo";
            buttonNew.UseVisualStyleBackColor = true;
            buttonNew.Click += buttonNew_Click;
            // 
            // FormExpediente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 427);
            Controls.Add(groupBoxTitle);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormExpediente";
            Text = "FormExpediente";
            groupBoxTitle.ResumeLayout(false);
            groupBoxTitle.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxTitle;
        private ComboBox comboBoxCaja;
        private Button buttonCancel;
        private Button buttonDelete;
        private Button buttonEdit;
        private Button buttonSave;
        private Label label3;
        private Label label2;
        private ComboBox comboBoxExpediente;
        private Label labelNameEmployee;
        private TextBox textBoxNameEmployee;
        private Button buttonNew;
    }
}