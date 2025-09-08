using adea_solution_wf.Models;
using adea_solution_wf.Services;

namespace adea_solution_wf
{
    public partial class Main : Form
    {
        private readonly ApiService _apiService;
        private List<Caja> _cajas;
        private List<Expediente> _expedientes;
        private FormCaja? _formCaja;
        private FormExpediente? _formExpediente;
        private bool _mostrandoCajas = true;

        public Main()
        {
            InitializeComponent();
            _apiService = new ApiService();
            _cajas = new List<Caja>();
            _expedientes = new List<Expediente>();
            InitializeApp();
        }

        private async void InitializeApp()
        {
            // Configurar DataGridView
            ConfigureDataGridView();

            // Cargar datos iniciales
            await LoadCajas();

            // Mostrar formulario de cajas por defecto
            radioButton1.Checked = true;
        }

        private void ConfigureDataGridView()
        {
            dataGridViewCajas.AutoGenerateColumns = false;
            dataGridViewCajas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCajas.MultiSelect = false;
            dataGridViewCajas.ReadOnly = true;

            // Limpiar columnas existentes
            dataGridViewCajas.Columns.Clear();

            // Configurar columnas para Cajas
            ConfigureCajasColumns();

            // Configurar evento de selección
            dataGridViewCajas.SelectionChanged += DataGridViewCajas_SelectionChanged;
        }

        private void ConfigureCajasColumns()
        {
            dataGridViewCajas.Columns.Clear();

            dataGridViewCajas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Caja_Id",
                HeaderText = "ID Caja",
                DataPropertyName = "Caja_Id",
                Width = 80
            });

            dataGridViewCajas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Estado",
                HeaderText = "Estado",
                DataPropertyName = "Estado",
                Width = 80
            });

            dataGridViewCajas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Ubicacion_Id",
                HeaderText = "Ubicación",
                DataPropertyName = "Ubicacion_Id",
                Width = 120
            });

            dataGridViewCajas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ExpedientesCount",
                HeaderText = "Expedientes",
                DataPropertyName = "ExpedientesCount",
                Width = 100
            });
        }

        private void ConfigureExpedientesColumns()
        {
            dataGridViewCajas.Columns.Clear();

            dataGridViewCajas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Expediente_Id",
                HeaderText = "ID Expediente",
                DataPropertyName = "Expediente_Id",
                Width = 100
            });

            dataGridViewCajas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Caja_Id",
                HeaderText = "ID Caja",
                DataPropertyName = "Caja_Id",
                Width = 80
            });

            dataGridViewCajas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nombre_Empleado",
                HeaderText = "Nombre Empleado",
                DataPropertyName = "Nombre_Empleado",
                Width = 200
            });

            dataGridViewCajas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Tipo_Expediente",
                HeaderText = "Tipo Expediente",
                DataPropertyName = "Tipo_Expediente",
                Width = 120
            });
        }

        private async Task LoadCajas()
        {
            _cajas = await _apiService.GetAllCajasAsync();
            if (_mostrandoCajas)
            {
                dataGridViewCajas.DataSource = _cajas;
            }
        }

        private async Task LoadExpedientes()
        {
            _expedientes = await _apiService.GetAllExpedientesAsync();
            if (!_mostrandoCajas)
            {
                dataGridViewCajas.DataSource = _expedientes;
            }
        }

        private void DataGridViewCajas_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewCajas.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewCajas.SelectedRows[0];

                if (_mostrandoCajas)
                {
                    var cajaSeleccionada = selectedRow.DataBoundItem as Caja;
                    if (cajaSeleccionada != null && _formCaja != null)
                    {
                        _formCaja.LoadCajaData(cajaSeleccionada);
                    }
                }
                else
                {
                    var expedienteSeleccionado = selectedRow.DataBoundItem as Expediente;
                    if (expedienteSeleccionado != null && _formExpediente != null)
                    {
                        _formExpediente.LoadExpedienteData(expedienteSeleccionado);
                    }
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                _mostrandoCajas = true;
                ConfigureCajasColumns();
                LoadCajas();

                panel1.Controls.Clear();

                _formCaja = new FormCaja();
                _formCaja.TopLevel = false;
                _formCaja.Dock = DockStyle.Fill;

                // Suscribirse a eventos del FormCaja
                _formCaja.CajasUpdated += FormCaja_CajasUpdated;

                panel1.Controls.Add(_formCaja);
                _formCaja.Show();
            }
            else
            {
                _mostrandoCajas = false;
                ConfigureExpedientesColumns();
                LoadExpedientes();

                panel1.Controls.Clear();

                _formExpediente = new FormExpediente();
                _formExpediente.TopLevel = false;
                _formExpediente.Dock = DockStyle.Fill;

                // Suscribirse a eventos del FormExpediente
                _formExpediente.ExpedientesUpdated += FormExpediente_ExpedientesUpdated;

                panel1.Controls.Add(_formExpediente);
                _formExpediente.Show();
            }
        }

        private async void FormCaja_CajasUpdated(object? sender, List<Caja> cajas)
        {
            // Actualizar la lista de cajas cuando FormCaja notifica cambios
            _cajas = cajas;
            dataGridViewCajas.DataSource = null;
            dataGridViewCajas.DataSource = _cajas;
        }

        private async void FormExpediente_ExpedientesUpdated(object? sender, List<Expediente> expedientes)
        {
            // Actualizar la lista de expedientes cuando FormExpediente notifica cambios
            _expedientes = expedientes;
            dataGridViewCajas.DataSource = null;
            dataGridViewCajas.DataSource = _expedientes;

            // También actualizar las cajas por si cambió el conteo
            await LoadCajas();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // La inicialización ya se hace en el constructor
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var formAbout = new Services.FormAbout())
            {
                formAbout.ShowDialog();
            }
        }
    }
}
