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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestProyecto.Services;
using TestProyecto.Views;

namespace TestProyecto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        CrudCliente logC = new CrudCliente();

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            string nombre = txtUser.Text;
            string contraseña = txtPassword.Text;

            var responser = logC.LoginC(nombre, contraseña);

            if (responser.Roles.RolName == "Cliente")

            {
                MenuGeneral nuevo = new MenuGeneral();

                nuevo.Show();

                Close();
               //return "SA";
            }
            else
            {
                MessageBox.Show("No hay usuario");
              //  return "";
            }


           



            
        }

        private void btnRegistrer_Click(object sender, RoutedEventArgs e)
        {
            RegistroC registrarC = new RegistroC();

            registrarC.Show();

            Close();
        }
    }
}
