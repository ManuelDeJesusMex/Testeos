using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TestProyecto.Views
{
    /// <summary>
    /// Lógica de interacción para CarritodeCompra.xaml
    /// </summary>
    public partial class CarritodeCompra : Window
    {
        public CarritodeCompra()
        {
            InitializeComponent();
        }

        private void btnback_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            mainWindow.Show();
            Close();
        }

        private void MouseMessage (object sender, MouseEventArgs e)
        {
            MessageBox.Show("HOLA");
        }
    }
}
