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
using TestProyecto.Entities;
using TestProyecto.Services;

namespace TestProyecto.Views
{
    /// <summary>
    /// Lógica de interacción para RegistroC.xaml
    /// </summary>
    public partial class RegistroC : Window
    {
        public RegistroC()
        {
            InitializeComponent();
        }
        CrudCliente servicios = new CrudCliente();
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MenuPrincipal = new MainWindow();

            MenuPrincipal.Show();

            Close();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtApellido.Clear();
            txtCorreo.Clear();
            txtNombre.Clear();
            txtPassword.Clear();
            txtSaldo.Clear();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Cliente AddCliente = new Cliente();

            if (!string.IsNullOrEmpty(txtApellido.Text) || !string.IsNullOrEmpty(txtCorreo.Text) || !string.IsNullOrEmpty(txtNombre.Text) || !string.IsNullOrEmpty(txtSaldo.Text) || !string.IsNullOrEmpty(txtPassword.Text))
            {
                

                AddCliente.Nombre = txtNombre.Text;
                AddCliente.Apellido = txtApellido.Text;
                AddCliente.Correo = txtCorreo.Text;
                AddCliente.Password = txtPassword.Text;
                AddCliente.FkRol = 1;

               // AddCliente.FkRol = int.Parse(SelectRol.SelectedValue.ToString());

                //Al tratarse de un cliente, directamente se le asigna el FkRol de 1 (Cliente)

                txtSaldo.Text = AddCliente.Saldo.ToString();

                servicios.CreateCliente(AddCliente);

                MessageBox.Show("Se ha registrado con éxito");

                MainWindow Login = new MainWindow();

                Login.Show();

            
                //HOla
                Close();
            }
        }

       
    }
}
