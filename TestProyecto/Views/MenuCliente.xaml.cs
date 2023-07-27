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
using TestProyecto.Services;

namespace TestProyecto.Views
{
    /// <summary>
    /// Lógica de interacción para MenuCliente.xaml
    /// </summary>
    public partial class MenuCliente : Window
    {
        public MenuCliente()
        {
            InitializeComponent();
            GetProductos();
        }
        CrudProducto watchP = new CrudProducto();
       public void GetProductos ()
        {
            ProductosTable.ItemsSource = watchP.GetProductos();
        }

        private void btnCarritoCompra_Click(object sender, RoutedEventArgs e)
        {
            CarritodeCompra carroCliente = new CarritodeCompra();

            carroCliente.Show();
            Close();
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow log = new MainWindow();

            log.Show();
            Close();
        }
    }
}
