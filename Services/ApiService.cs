using adea_solution_wf.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adea_solution_wf.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public ApiService()
        {
            _httpClient = new HttpClient();
            _baseUrl = "https://adea-solution-web-api-gffedgehbahqdvhh.canadacentral-01.azurewebsites.net";
        }

        // Métodos para Cajas
        public async Task<List<Caja>> GetAllCajasAsync()
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"{_baseUrl}/cajas");
                return JsonConvert.DeserializeObject<List<Caja>>(response) ?? new List<Caja>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener cajas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Caja>();
            }
        }

        public async Task<Caja?> GetCajaByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"{_baseUrl}/cajas/{id}");
                return JsonConvert.DeserializeObject<Caja>(response);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener caja: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<Caja?> CreateCajaAsync(CreateCajaRequest request)
        {
            try
            {
                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"{_baseUrl}/cajas", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Caja>(responseContent);
                }
                else
                {
                    MessageBox.Show($"Error al crear caja: {response.ReasonPhrase}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear caja: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<Caja?> UpdateCajaAsync(UpdateCajaRequest request)
        {
            try
            {
                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"{_baseUrl}/cajas/{request.Caja_Id}", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Caja>(responseContent);
                }
                else
                {
                    MessageBox.Show($"Error al actualizar caja: {response.ReasonPhrase}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar caja: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<bool> DeleteCajaAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_baseUrl}/cajas/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show($"Error al eliminar caja: {response.ReasonPhrase}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar caja: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Métodos para Expedientes
        public async Task<List<Expediente>> GetAllExpedientesAsync()
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"{_baseUrl}/expedientes");
                return JsonConvert.DeserializeObject<List<Expediente>>(response) ?? new List<Expediente>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener expedientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Expediente>();
            }
        }

        public async Task<List<Expediente>> GetExpedientesByCajaIdAsync(int cajaId)
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"{_baseUrl}/expedientes/caja/{cajaId}");
                return JsonConvert.DeserializeObject<List<Expediente>>(response) ?? new List<Expediente>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener expedientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Expediente>();
            }
        }

        public async Task<Expediente?> CreateExpedienteAsync(CreateExpedienteRequest request)
        {
            try
            {
                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"{_baseUrl}/expedientes", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Expediente>(responseContent);
                }
                else
                {
                    MessageBox.Show($"Error al crear expediente: {response.ReasonPhrase}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear expediente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<Expediente?> UpdateExpedienteAsync(UpdateExpedienteRequest request)
        {
            try
            {
                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"{_baseUrl}/expedientes/{request.Expediente_Id}", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Expediente>(responseContent);
                }
                else
                {
                    MessageBox.Show($"Error al actualizar expediente: {response.ReasonPhrase}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar expediente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<bool> DeleteExpedienteAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_baseUrl}/expedientes/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show($"Error al eliminar expediente: {response.ReasonPhrase}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar expediente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Métodos de utilidad
        public async Task<List<string>> GetUbicacionesAsync()
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"{_baseUrl}/opciones/ubicaciones");
                return JsonConvert.DeserializeObject<List<string>>(response) ?? new List<string>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener ubicaciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<string>();
            }
        }

        public async Task<List<string>> GetTiposExpedienteAsync()
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"{_baseUrl}/opciones/tipos-expediente");
                return JsonConvert.DeserializeObject<List<string>>(response) ?? new List<string>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener tipos de expediente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<string>();
            }
        }
    }
}
