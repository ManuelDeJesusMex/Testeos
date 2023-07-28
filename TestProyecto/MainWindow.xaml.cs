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
        CrudVendedor logV = new CrudVendedor();
        CrudSA logSA = new CrudSA();

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            MenuVendedor ne = new MenuVendedor();
            //MenuAdminSA ne = new MenuAdminSA();

            ne.Show();

            Close();
            //string nombre = txtUser.Text;
            //string contraseña = txtPassword.Text;

            //if (nombre == "" || contraseña == "")
            //{
            //    MessageBox.Show("Faltan campos");
            //}
            //else
            //{
            //    var responser = logC.LoginC(nombre, contraseña);
            //    var responserV = logV.LoginV(nombre, contraseña);
            //    var responserSA = logSA.LogSA(nombre, contraseña);

                //if (responser.Roles.RolName == "Cliente")

                //{
                //    MessageBox.Show("Sesión iniciada");

                //    MenuCliente nuevo = new MenuCliente();
                //  //  MenuGeneral nuevo = new MenuGeneral();

                //    nuevo.Show();

                //    Close();
                //    //return "SA";
                //}
                //else
                //if (responserSA.Roles.RolName == "SA")
               // {
                //    MessageBox.Show("Sesión iniciada");
                 //   MenuAdminSA sa = new MenuAdminSA();

                  // sa.Show();

                  // Close();

               // }
                //else 
            //    if (responserV.Roles.RolName == "Vendedor")
            //    {
            //        MessageBox.Show("Sesión iniciada");

            //        MenuVendedor nuevo = new MenuVendedor();
            //        nuevo.Show();
            //        Close();

            //    }
            //    else if (responser.Roles.RolName == null)
            //    {
            //        MessageBox.Show("No hay usuario");
            //        //  return "";
            //    }

          // }                  

            
        }

        private void btnRegistrer_Click(object sender, RoutedEventArgs e)
        {
            RegistroC registrarC = new RegistroC();

            registrarC.Show();

            Close();
        }
    }
}
