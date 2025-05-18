using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace almacenWPF
{
    public partial class Material : Window
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string supabaseUrl = "https://yvhkwhirvzavpbpaxxrb.supabase.co";
        private readonly string supabaseKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Inl2aGt3aGlydnphdnBicGF4eHJiIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NDczNjMwMDIsImV4cCI6MjA2MjkzOTAwMn0.7A9YtrIoS-W0tZ-q8VJnTPkiSCf6fhBtY046sSbltLs";

        public Material()
        {
            InitializeComponent();
            CargarMateriales();
        }

        private async void CargarMateriales()
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", supabaseKey);
            client.DefaultRequestHeaders.Add("apikey", supabaseKey);

            var response = await client.GetAsync($"{supabaseUrl}/rest/v1/material?select=*");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var lista = JsonSerializer.Deserialize<List<Models.Material>>(json);
                materialesGrid.ItemsSource = lista;
            }
            else
            {
                MessageBox.Show("Error al cargar materiales.");
            }
        }

        private async void AgregarMaterial_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nombreMaterial.Text) ||
                    string.IsNullOrWhiteSpace(descripcionMaterial.Text) ||
                    tipoMaterial.SelectedItem == null ||
                    !int.TryParse(cantidadDisponible.Text, out int cantidad) ||
                    !float.TryParse(precioMaterial.Text, out float precio))
                {
                    MessageBox.Show("Por favor completa todos los campos correctamente.");
                    return;
                }

                var nuevoMaterial = new
                {
                    nombre = nombreMaterial.Text,
                    descripcion = descripcionMaterial.Text,
                    tipo = ((ComboBoxItem)tipoMaterial.SelectedItem).Content.ToString(),
                    cant_disp = cantidad,
                    precio = precio
                };

                var json = JsonSerializer.Serialize(nuevoMaterial);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", supabaseKey);
                client.DefaultRequestHeaders.Add("apikey", supabaseKey);
                client.DefaultRequestHeaders.Add("Prefer", "return=representation");

                var response = await client.PostAsync($"{supabaseUrl}/rest/v1/material", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Material agregado correctamente.");
                    CargarMateriales();
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error: {response.StatusCode}\n{error}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar material: {ex.Message}");
            }
        }
    }
}
