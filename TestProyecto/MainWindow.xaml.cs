using Microsoft.EntityFrameworkCore;
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
using TestProyecto.Context;
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
        private ApplicationDbContext _context = new ApplicationDbContext();
        CrudCliente logC = new CrudCliente();
        CrudVendedor logV = new CrudVendedor();
        CrudSA logSA = new CrudSA();

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            MenuCliente pc = new MenuCliente();
         //   MenuVendedor pv = new MenuVendedor();
            MenuAdminSA psa = new MenuAdminSA();
            //
           // ne.Show();

          //  Close();
            string correo = txtUser.Text;
            string contraseña = txtPassword.Text;

            if (txtPassword.Text != "" && txtUser.Text != "")
            {

               
                var cliente = _context.Clientes.FirstOrDefault(c => c.CorreoCliente == correo && c.PasswordCliente == contraseña);
                if (cliente != null)
                {
                    MessageBox.Show("Sesión iniciada como Cliente");

                    pc.Show();

                    this.Close();
                    return;
                }

                var vendedor = _context.Vendedores.FirstOrDefault(v => v.CorreoV == correo && v.ContraseñaVendedor == contraseña);
                if (vendedor != null)
                {
                    MessageBox.Show("Sesión iniciada como Vendedor");

                    MenuVendedor men = new MenuVendedor();
                    men.Show();
                    this.Close();
                    return;
                }

                var superAdmin = _context.SuperAdministradores.FirstOrDefault(sa => sa.CorreoSuperAdmin == correo && sa.ContraseñaSuperAdmin == contraseña);
                if (superAdmin != null)
                {
                    MessageBox.Show("Sesión iniciada como Super Administrador");

                    psa.Show();
                    this.Close();
                    return;
                }
            } else
            {
                MessageBox.Show("Correo o contraseña incorrectos");
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
