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
    public partial class FormCaja : Form
    {
        private readonly ApiService _apiService;
        private Caja? _cajaSeleccionada;
        private bool _modoEdicion = false;

        // Eventos para comunicarse con el formulario principal
        public event EventHandler<List<Caja>>? CajasUpdated;
        public event EventHandler<Caja>? CajaSelected;

        public FormCaja()
        {
            InitializeComponent();
            _apiService = new ApiService();
            InitializeForm();
        }

        private async void InitializeForm()
        {
            // Cargar ubicaciones
            await LoadUbicaciones();

            // Cargar estados predefinidos
            LoadEstados();

            // Estado inicial
            SetFormState(false);
        }

        private void LoadEstados()
        {
            comboBoxStatus.Items.AddRange(new[] { "ACT", "INA" });
        }

        private async Task LoadUbicaciones()
        {
            var ubicaciones = await _apiService.GetUbicacionesAsync();
            comboBoxLocations.Items.Clear();
            comboBoxLocations.Items.AddRange(ubicaciones.ToArray());
        }

        private void SetFormState(bool editing)
        {
            _modoEdicion = editing;

            comboBoxStatus.Enabled = editing;
            comboBoxLocations.Enabled = editing;

            buttonSave.Enabled = editing;
            buttonCancel.Enabled = editing;
            buttonEdit.Enabled = !editing && _cajaSeleccionada != null;
            buttonDelete.Enabled = !editing && _cajaSeleccionada != null;
            buttonNew.Enabled = !editing;
        }

        private void ClearForm()
        {
            textBoxIdCaja.Clear();
            comboBoxStatus.SelectedIndex = -1;
            comboBoxLocations.SelectedIndex = -1;
            _cajaSeleccionada = null;
        }

        private bool ValidateForm()
        {
            if (comboBoxStatus.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un estado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxStatus.Focus();
                return false;
            }

            if (comboBoxLocations.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una ubicación.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxLocations.Focus();
                return false;
            }

            return true;
        }

        // Método público para cargar datos de una caja seleccionada desde el Main
        public void LoadCajaData(Caja caja)
        {
            _cajaSeleccionada = caja;
            textBoxIdCaja.Text = caja.Caja_Id.ToString();
            comboBoxStatus.Text = caja.Estado;
            comboBoxLocations.Text = caja.Ubicacion_Id;
            SetFormState(false);
        }

        // Método público para limpiar el formulario
        public void ClearCajaData()
        {
            ClearForm();
            SetFormState(false);
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            ClearForm();
            SetFormState(true);
            comboBoxStatus.Focus();
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                if (_cajaSeleccionada == null)
                {
                    // Crear nueva caja
                    var request = new CreateCajaRequest
                    {
                        Estado = comboBoxStatus.SelectedItem.ToString()!,
                        Ubicacion_Id = comboBoxLocations.SelectedItem.ToString()!
                    };

                    var nuevaCaja = await _apiService.CreateCajaAsync(request);
                    if (nuevaCaja != null)
                    {
                        MessageBox.Show("Caja creada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Notificar al Main que actualice la lista
                        var cajas = await _apiService.GetAllCajasAsync();
                        CajasUpdated?.Invoke(this, cajas);

                        ClearForm();
                        SetFormState(false);
                    }
                }
                else
                {
                    // Actualizar caja existente
                    var request = new UpdateCajaRequest
                    {
                        Caja_Id = _cajaSeleccionada.Caja_Id,
                        Estado = comboBoxStatus.SelectedItem.ToString()!,
                        Ubicacion_Id = comboBoxLocations.SelectedItem.ToString()!
                    };

                    var cajaActualizada = await _apiService.UpdateCajaAsync(request);
                    if (cajaActualizada != null)
                    {
                        MessageBox.Show("Caja actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Notificar al Main que actualice la lista
                        var cajas = await _apiService.GetAllCajasAsync();
                        CajasUpdated?.Invoke(this, cajas);

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
            if (_cajaSeleccionada != null)
            {
                SetFormState(true);
                comboBoxStatus.Focus();
            }
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            if (_cajaSeleccionada == null) return;

            // Verificar si la caja tiene expedientes
            if (_cajaSeleccionada.ExpedientesCount > 0)
            {
                MessageBox.Show("No se puede eliminar una caja que contiene expedientes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"¿Está seguro de que desea eliminar la caja {_cajaSeleccionada.Caja_Id}?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var eliminada = await _apiService.DeleteCajaAsync(_cajaSeleccionada.Caja_Id);
                    if (eliminada)
                    {
                        MessageBox.Show("Caja eliminada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Notificar al Main que actualice la lista
                        var cajas = await _apiService.GetAllCajasAsync();
                        CajasUpdated?.Invoke(this, cajas);

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
            if (_cajaSeleccionada != null)
            {
                LoadCajaData(_cajaSeleccionada);
            }
            else
            {
                ClearForm();
            }
            SetFormState(false);
        }
    }
}
