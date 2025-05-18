using almacenWPF.Models;
using Supabase;
using System.Windows;
using static Supabase.Postgrest.Constants;

namespace almacenWPF {
    public partial class MainWindow : Window {
        private Client supabase;
        public MainWindow() {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
        private async void MainWindow_Loaded(object sender, RoutedEventArgs e) {
            var url = "https://yvhkwhirvzavpbpaxxrb.supabase.co";
            var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Inl2aGt3aGlydnphdnBicGF4eHJiIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NDczNjMwMDIsImV4cCI6MjA2MjkzOTAwMn0.7A9YtrIoS-W0tZ-q8VJnTPkiSCf6fhBtY046sSbltLs";
            var options = new SupabaseOptions {
                AutoConnectRealtime = true
            };
            supabase = new Client(url, key, options);
            await supabase.InitializeAsync();
        }
        private async void goToSignup(object sender, RoutedEventArgs e) {
            signup dashboard = new signup();
            dashboard.Show();
            this.Close();
        }
        private async void login(object sender, RoutedEventArgs e) {
            string nombreUsuario = nombre.Text.Trim();
            string contraseña = password.Password.Trim();
            var response = await supabase
                .From<Usuario>()
                .Filter("nombre", Operator.Equals, nombreUsuario)
                .Filter("password", Operator.Equals, contraseña)
                .Get();
            if (response.Models.Count > 0) {
                MessageBox.Show("Inicio de sesión exitoso.");
                Window1 dashboard = new Window1();
                dashboard.Show();
                this.Close();
            }
            else {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }
        
    }
}
