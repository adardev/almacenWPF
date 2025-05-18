using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace almacenWPF
{
    public partial class signup : Window
    {
        public signup()
        {
            InitializeComponent();
        }

        private void nombre_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Puedes eliminar esto si no lo usas
        }

        private async void signupbtn(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();

            var supabaseUrl = "https://yvhkwhirvzavpbpaxxrb.supabase.co";
            var supabaseKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Inl2aGt3aGlydnphdnBicGF4eHJiIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NDczNjMwMDIsImV4cCI6MjA2MjkzOTAwMn0.7A9YtrIoS-W0tZ-q8VJnTPkiSCf6fhBtY046sSbltLs";
            var requestUrl = $"{supabaseUrl}/rest/v1/usuario";

            var user = new
            {
                nombre = nombre.Text,
                apellidos = apellido.Text,
                password = password.Password,
                fecha_nac = DateTime.Parse(fechanac.Text).ToString("yyyy-MM-dd"),
                tipo = tipo.Text
            };

            var json = JsonSerializer.Serialize(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", supabaseKey);
            client.DefaultRequestHeaders.Add("apikey", supabaseKey);
            client.DefaultRequestHeaders.Add("Prefer", "return=representation");

            var response = await client.PostAsync(requestUrl, content);

            if (response.IsSuccessStatusCode) {
                Window1 dashboard = new Window1();
                dashboard.Show();
                this.Close();
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Error: {response.StatusCode}\n{error}");
            }
        }
    }
}
