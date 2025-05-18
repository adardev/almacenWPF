using System.Windows;
using System.Windows.Controls;

namespace almacenWPF {
    public partial class Window1 : Window {
        public Window1() {
            InitializeComponent();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) {

        }
        private void foliobtn(object sender, RoutedEventArgs e) {
            Folio dashboard = new Folio();
            dashboard.Show();
            this.Close();
        }
        private void materialbtn(object sender, RoutedEventArgs e) {
            Material dashboard = new Material();
            dashboard.Show();
            this.Close();
        }
        private void ordenbtn(object sender, RoutedEventArgs e) {
            Orden dashboard = new Orden();
            dashboard.Show();
            this.Close();
        }

    }
}
