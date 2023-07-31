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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TestProyecto.Context;
using TestProyecto.Entities;
using TestProyecto.Services;

namespace TestProyecto.Views
{
    /// <summary>
    /// Lógica de interacción para RegistroC.xaml
    /// </summary>
    public partial class RegistroC : Window
    {

        private ApplicationDbContext _context;
        public RegistroC()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
        }
        CrudCliente servicios = new CrudCliente();

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (cmbRoles.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un rol antes de registrar.");
                return;
            }

            string rolSeleccionado = ((ComboBoxItem)cmbRoles.SelectedItem).Content.ToString();

            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtCorreo.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            if (rolSeleccionado == "Vendedor" || rolSeleccionado == "SuperAdmin")
            {
                if (txtAutenticacion.Text != "12345")
                {
                    MessageBox.Show("Código de autenticación incorrecto.");
                    return;
                }
            }

            if (rolSeleccionado == "Cliente")
            {
                if (!double.TryParse(txtSaldo.Text, out double saldo))
                {
                    MessageBox.Show("Por favor, ingrese un saldo válido.");
                    return;
                }

                Cliente cliente = new Cliente
                {
                    NombreCliente = txtNombre.Text,
                    ApellidoCliente = txtApellido.Text,
                    CorreoCliente = txtCorreo.Text,
                    PasswordCliente = txtPassword.Text,
                    SaldoCliente = saldo,
                    FkRol = 1
                };

                _context.Clientes.Add(cliente);
            }
            else if (rolSeleccionado == "Vendedor")
            {
                Vendedor vendedor = new Vendedor
                {
                    NombreVendedor = txtNombre.Text,
                    ApellidoVendedor = txtApellido.Text,
                    CorreoV = txtCorreo.Text,
                    ContraseñaVendedor = txtPassword.Text,
                    FkRol = 2
                };

                _context.Vendedores.Add(vendedor);
            }
            else if (rolSeleccionado == "SuperAdmin")
            {
                SuperAdmin superAdmin = new SuperAdmin
                {
                    NombreSuperAdmin = txtNombre.Text,
                    ApellidoSuperAdmin = txtApellido.Text,
                    CorreoSuperAdmin = txtCorreo.Text,
                    ContraseñaSuperAdmin = txtPassword.Text,
                    FkRol = 3
                };

                _context.SuperAdministradores.Add(superAdmin);
            }

            // Guardar los cambios en la base de datos
            _context.SaveChanges();

            MessageBox.Show("Se ha registrado con éxito.");
        }

        private void cmbRoles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbRoles.SelectedItem != null)
            {
                string rolSeleccionado = ((ComboBoxItem)cmbRoles.SelectedItem).Content.ToString();

                // Mostrar y ocultar campos según el rol seleccionado
                if (rolSeleccionado == "Cliente")
                {
                    txtNombre.Visibility = Visibility.Visible;
                    txtApellido.Visibility = Visibility.Visible;
                    txtCorreo.Visibility = Visibility.Visible;
                    txtPassword.Visibility = Visibility.Visible;
                    txtAutenticacion.Visibility = Visibility.Collapsed;
                    txtSaldo.Visibility = Visibility.Visible;
                    lbName.Visibility = Visibility.Visible;
                    lbApellido.Visibility = Visibility.Visible;
                    lbCorreo.Visibility = Visibility.Visible;
                    lbPassword.Visibility = Visibility.Visible;
                    lbSaldo.Visibility = Visibility.Visible;
                    lbCod.Visibility = Visibility.Collapsed;
                }
                else if (rolSeleccionado == "Vendedor" || rolSeleccionado == "SuperAdmin")
                {
                    txtNombre.Visibility = Visibility.Visible;
                    txtApellido.Visibility = Visibility.Visible;
                    txtCorreo.Visibility = Visibility.Visible;
                    txtPassword.Visibility = Visibility.Visible;
                    txtAutenticacion.Visibility = Visibility.Visible;
                    txtSaldo.Visibility = Visibility.Collapsed;
                    lbName.Visibility = Visibility.Visible;
                    lbApellido.Visibility = Visibility.Visible;
                    lbCorreo.Visibility = Visibility.Visible;
                    lbPassword.Visibility = Visibility.Visible;
                    lbSaldo.Visibility = Visibility.Collapsed;
                    lbCod.Visibility = Visibility.Visible;
                }
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtApellido.Clear();
            txtCorreo.Clear();
            txtNombre.Clear();
            txtPassword.Clear();
            txtSaldo.Clear();
            txtAutenticacion.Clear();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow reg = new MainWindow();
            Close();
            reg.Show();
        }


    }
}
