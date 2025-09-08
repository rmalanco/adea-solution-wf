using adea_solution_wf.Models;
using adea_solution_wf.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adea_solution_wf
{
    public partial class FormExpediente : Form
    {
        private readonly ApiService _apiService;
        private Expediente? _expedienteSeleccionado;
        private List<Caja> _cajas;
        private bool _modoEdicion = false;

        // Eventos para comunicarse con el formulario principal
        public event EventHandler<List<Expediente>>? ExpedientesUpdated;
        public event EventHandler<Expediente>? ExpedienteSelected;

        public FormExpediente()
        {
            InitializeComponent();
            _apiService = new ApiService();
            _cajas = new List<Caja>();
            InitializeForm();
        }

        private async void InitializeForm()
        {
            // Cargar datos iniciales
            await LoadCajas();
            await LoadTiposExpediente();
            
            // Estado inicial
            SetFormState(false);
        }

        private async Task LoadCajas()
        {
            _cajas = await _apiService.GetAllCajasAsync();
            comboBoxCaja.Items.Clear();
            
            foreach (var caja in _cajas)
            {
                comboBoxCaja.Items.Add($"{caja.Caja_Id} - {caja.Estado} ({caja.Ubicacion_Id})");
            }
        }

        private async Task LoadTiposExpediente()
        {
            var tipos = await _apiService.GetTiposExpedienteAsync();
            comboBoxExpediente.Items.Clear();
            comboBoxExpediente.Items.AddRange(tipos.ToArray());
        }

        private void SetFormState(bool editing)
        {
            _modoEdicion = editing;
            
            textBoxNameEmployee.Enabled = editing;
            comboBoxCaja.Enabled = editing;
            comboBoxExpediente.Enabled = editing;
            
            buttonSave.Enabled = editing;
            buttonCancel.Enabled = editing;
            buttonEdit.Enabled = !editing && _expedienteSeleccionado != null;
            buttonDelete.Enabled = !editing && _expedienteSeleccionado != null;
            buttonNew.Enabled = !editing;
        }

        private void ClearForm()
        {
            textBoxNameEmployee.Clear();
            comboBoxCaja.SelectedIndex = -1;
            comboBoxExpediente.SelectedIndex = -1;
            _expedienteSeleccionado = null;
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(textBoxNameEmployee.Text))
            {
                MessageBox.Show("El nombre del empleado es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNameEmployee.Focus();
                return false;
            }

            if (textBoxNameEmployee.Text.Length > 100)
            {
                MessageBox.Show("El nombre del empleado no puede exceder 100 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNameEmployee.Focus();
                return false;
            }

            if (comboBoxCaja.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una caja.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxCaja.Focus();
                return false;
            }

            if (comboBoxExpediente.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un tipo de expediente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxExpediente.Focus();
                return false;
            }

            return true;
        }

        private int GetCajaIdFromComboBox()
        {
            if (comboBoxCaja.SelectedItem == null) return 0;
            
            var selectedText = comboBoxCaja.SelectedItem.ToString()!;
            var cajaIdText = selectedText.Split(' ')[0];
            
            if (int.TryParse(cajaIdText, out int cajaId))
            {
                return cajaId;
            }
            
            return 0;
        }

        // Método público para cargar datos de un expediente seleccionado desde el Main
        public void LoadExpedienteData(Expediente expediente)
        {
            _expedienteSeleccionado = expediente;
            
            textBoxNameEmployee.Text = expediente.Nombre_Empleado;
            
            // Buscar la caja correspondiente
            var cajaText = $"{expediente.Caja_Id} - {_cajas.FirstOrDefault(c => c.Caja_Id == expediente.Caja_Id)?.Estado} ({_cajas.FirstOrDefault(c => c.Caja_Id == expediente.Caja_Id)?.Ubicacion_Id})";
            comboBoxCaja.Text = cajaText;
            
            comboBoxExpediente.Text = expediente.Tipo_Expediente;
            
            SetFormState(false);
        }

        // Método público para limpiar el formulario
        public void ClearExpedienteData()
        {
            ClearForm();
            SetFormState(false);
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            ClearForm();
            SetFormState(true);
            textBoxNameEmployee.Focus();
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                var cajaId = GetCajaIdFromComboBox();
                if (cajaId == 0)
                {
                    MessageBox.Show("Error al obtener el ID de la caja seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_expedienteSeleccionado == null)
                {
                    // Crear nuevo expediente
                    var request = new CreateExpedienteRequest
                    {
                        Caja_Id = cajaId,
                        Nombre_Empleado = textBoxNameEmployee.Text.Trim(),
                        Tipo_Expediente = comboBoxExpediente.SelectedItem.ToString()!
                    };

                    var nuevoExpediente = await _apiService.CreateExpedienteAsync(request);
                    if (nuevoExpediente != null)
                    {
                        MessageBox.Show("Expediente creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Notificar al Main que actualice la lista
                        var expedientes = await _apiService.GetAllExpedientesAsync();
                        ExpedientesUpdated?.Invoke(this, expedientes);
                        
                        // Actualizar también las cajas por si cambió el conteo
                        await LoadCajas();
                        
                        ClearForm();
                        SetFormState(false);
                    }
                }
                else
                {
                    // Actualizar expediente existente
                    var request = new UpdateExpedienteRequest
                    {
                        Expediente_Id = _expedienteSeleccionado.Expediente_Id,
                        Caja_Id = cajaId,
                        Nombre_Empleado = textBoxNameEmployee.Text.Trim(),
                        Tipo_Expediente = comboBoxExpediente.SelectedItem.ToString()!
                    };

                    var expedienteActualizado = await _apiService.UpdateExpedienteAsync(request);
                    if (expedienteActualizado != null)
                    {
                        MessageBox.Show("Expediente actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Notificar al Main que actualice la lista
                        var expedientes = await _apiService.GetAllExpedientesAsync();
                        ExpedientesUpdated?.Invoke(this, expedientes);
                        
                        // Actualizar también las cajas por si cambió el conteo
                        await LoadCajas();
                        
                        SetFormState(false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (_expedienteSeleccionado != null)
            {
                SetFormState(true);
                textBoxNameEmployee.Focus();
            }
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            if (_expedienteSeleccionado == null) return;

            var result = MessageBox.Show(
                $"¿Está seguro de que desea eliminar el expediente {_expedienteSeleccionado.Expediente_Id}?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var eliminado = await _apiService.DeleteExpedienteAsync(_expedienteSeleccionado.Expediente_Id);
                    if (eliminado)
                    {
                        MessageBox.Show("Expediente eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Notificar al Main que actualice la lista
                        var expedientes = await _apiService.GetAllExpedientesAsync();
                        ExpedientesUpdated?.Invoke(this, expedientes);
                        
                        // Actualizar también las cajas por si cambió el conteo
                        await LoadCajas();
                        
                        ClearForm();
                        SetFormState(false);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (_expedienteSeleccionado != null)
            {
                LoadExpedienteData(_expedienteSeleccionado);
            }
            else
            {
                ClearForm();
            }
            SetFormState(false);
        }
    }
}
