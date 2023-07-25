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
    /// Lógica de interacción para MenuAdminSA.xaml
    /// </summary>
    public partial class MenuAdminSA : Window
    {
        public MenuAdminSA()
        {
            InitializeComponent();
            GetRoles();
            GetTamañosB();
            GetSabores();
            GetLotes();
            cboptionsUsers.Items.Add("Cliente");
            cboptionsUsers.Items.Add("Vendedor");
            cboptionsUsers.Items.Add("SA");
            cboptionsUsers.Items.Add("Producto");
        }
        CrudCliente modcliente = new CrudCliente();
        CrudProducto modProducto = new CrudProducto();
        CrudVendedor modVendedor = new CrudVendedor();
        CrudSA modSA = new CrudSA();
        private void cboptionsUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboptionsUsers.SelectedItem == "Cliente")
            {
                //  DataGridTextColumn.HeaderProperty(Saldo) = Visibility.Visible;
                txtSaldo.Visibility = Visibility.Visible;
                lbSaldo.Visibility = Visibility.Visible;
                cbLote.Visibility = Visibility.Hidden;
                cbRol.Visibility = Visibility.Visible;
                cbSabor.Visibility = Visibility.Hidden;
                cbTamaño.Visibility = Visibility.Hidden;
                GetClientesTable();


            } else if (cboptionsUsers.SelectedItem == "Vendedor")
            {
                txtSaldo.Visibility = Visibility.Hidden;
                lbSaldo.Visibility = Visibility.Hidden;

                cbLote.Visibility = Visibility.Hidden;
                cbRol.Visibility = Visibility.Visible;
                cbSabor.Visibility = Visibility.Hidden;
                cbTamaño.Visibility = Visibility.Hidden;

            } else if (cboptionsUsers.SelectedItem == "Producto")
            {
                txtSaldo.Visibility = Visibility.Hidden;
                lbSaldo.Visibility = Visibility.Hidden;
                lbApellido.Content = "HOLA";
                cbLote.Visibility = Visibility.Visible;
                cbRol.Visibility = Visibility.Hidden;
                cbSabor.Visibility = Visibility.Visible;
                cbTamaño.Visibility = Visibility.Visible;

            } else if (cboptionsUsers.SelectedItem == "SA")
            {
                txtSaldo.Visibility = Visibility.Hidden;
                lbSaldo.Visibility = Visibility.Hidden;

                cbLote.Visibility = Visibility.Hidden;
                cbRol.Visibility = Visibility.Visible;
                cbSabor.Visibility = Visibility.Hidden;
                cbTamaño.Visibility = Visibility.Hidden;
            }
        }
        public void GetRoles()
        {
            cbRol.ItemsSource = modSA.GetRoles();
            cbRol.DisplayMemberPath = "RolName";
            cbRol.SelectedValuePath = "PkRol";
        }
        public void GetSabores()
        {
            cbSabor.ItemsSource = modProducto.GetSabores();
            cbSabor.DisplayMemberPath = "NameSabor";
            cbSabor.SelectedValuePath = "PkSabor";
        }
        public void GetLotes()
        {
            cbLote.ItemsSource = modProducto.GetLotes();
            cbLote.DisplayMemberPath = "LoteName";
            cbLote.SelectedValuePath = "PkLote";
        }
        public void GetTamañosB()
        {
            cbTamaño.ItemsSource = modProducto.GetTamaños();
            cbRol.DisplayMemberPath = "TamañoP";
            cbRol.SelectedValuePath = "PkTamaño";
        }
        public void GetClientesTable ()
        {
            UserTable.ItemsSource = modSA.GetClientes();
        }
        public void GetVendedoresTable ()
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (cboptionsUsers.SelectedItem == "Cliente")
            {
                Cliente ClienteF = new Cliente();
                
                if (txtPkUser.Text == "")
                {
                    ClienteF.NombreCliente = txtNombre.Text;
                    ClienteF.ApellidoCliente = txtApellido.Text;
                    ClienteF.CorreoCliente = txtCorreo.Text;
                    ClienteF.PasswordCliente = txtPassword.Text;
                    ClienteF.SaldoCliente = double.Parse(txtSaldo.Text);
                    ClienteF.FkRol = 1;

                    modcliente.CreateCliente(ClienteF);

                    MessageBox.Show("Agregado con éxito");
                }
                else
                {
                    //Hacer función de update
                }
            } 
            else if (cboptionsUsers.SelectedItem == "Vendedor")
            {
                Vendedor vendedorF = new Vendedor();
                 if (txtPkUser.Text == "")
                {
                    vendedorF.NombreVendedor = txtNombre.Text;
                    vendedorF.ApellidoVendedor = txtApellido.Text;
                    vendedorF.CorreoV = txtCorreo.Text;
                    vendedorF.ContraseñaVendedor = txtPassword.Text;
                   
                    vendedorF.FkRol = 2;

                    modVendedor.CreateVendedor(vendedorF);


                    MessageBox.Show("Agregado con éxito");
                }
            }
            else if (cboptionsUsers.SelectedItem == "SA")
            {

            }
            else if (cboptionsUsers.SelectedItem == "Producto")
            {
                
            }
        }

        
    }
}
