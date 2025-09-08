namespace adea_solution_wf
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                panel1.Controls.Clear();
                FormCaja formCaja = new FormCaja();
                formCaja.TopLevel = false;
                panel1.Controls.Add(formCaja);
                formCaja.Show();
            }
            else
            {
                panel1.Controls.Clear();
                FormExpediente formExpediente = new FormExpediente();
                formExpediente.TopLevel = false;
                panel1.Controls.Add(formExpediente);
                formExpediente.Show();
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            InitializeApp();
        }

        private void InitializeApp()
        {
            radioButton1.Checked = true;
        }
    }
}
