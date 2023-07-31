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
            GetProductosTable();
            GetClientesTable();
            GetVendedoresTable();
            GetSuperAdminTable();
            cboptionsUsers.Items.Add("Cliente");
            cboptionsUsers.Items.Add("Vendedor");
            cboptionsUsers.Items.Add("SA");
            cboptionsUsers.Items.Add("Producto");
            cboptionsUsers.Items.Add("Sabores");
            cboptionsUsers.Items.Add("Lotes");
            cboptionsUsers.Items.Add("Tamanos");
            cboptionsUsers.Items.Add("Detalle de ventas");

        }
        CrudCliente modcliente = new CrudCliente();
        CrudProducto modProducto = new CrudProducto();
        CrudVendedor modVendedor = new CrudVendedor();
        CrudSA modSA = new CrudSA();
        private void cboptionsUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboptionsUsers.SelectedItem == "Cliente")
            {
                GetRoles();
                //  DataGridTextColumn.HeaderProperty(Saldo) = Visibility.Visible;
                lbApellido.Content = "Apellido";
                lbSaldo.Content = "Saldo";
                lbCorreo.Content = "Correo";
                lbPassword.Content = "Contraseña";
                cbRol.Visibility = Visibility.Hidden;
                lbApellido.Visibility = Visibility.Visible;
                lbPassword.Visibility = Visibility.Visible;
                lbCorreo.Visibility = Visibility.Visible;
                txtApellido.Visibility = Visibility.Visible;
                txtCorreo.Visibility = Visibility.Visible;
                txtPassword.Visibility = Visibility.Visible;
                lbtamaño.Visibility = Visibility.Hidden;
                lblote.Visibility = Visibility.Hidden;
                lbsabor.Visibility = Visibility.Hidden;
                txtSaldo.Visibility = Visibility.Visible;
                lbSaldo.Visibility = Visibility.Visible;
                cbLote.Visibility = Visibility.Hidden;
                cbSabor.Visibility = Visibility.Hidden;
                cbTamaño.Visibility = Visibility.Hidden;
                GetClientesTable();
                ProductosTable.Visibility = Visibility.Hidden;
                VendedorTable.Visibility = Visibility.Hidden;
                SuperAdminTable.Visibility = Visibility.Hidden;
                ClienteTable.Visibility = Visibility.Visible;
                DetalleVentaTable.Visibility = Visibility.Hidden;
                TamañosTable.Visibility = Visibility.Hidden;
                SaboresTable.Visibility = Visibility.Hidden;
                LotesTable.Visibility = Visibility.Hidden;
                txtNombre.Clear();
                txtCorreo.Clear();
                txtApellido.Clear();
                txtPassword.Clear();
                txtPkUser.Clear();
                txtSaldo.Clear();



            } else if (cboptionsUsers.SelectedItem == "Vendedor")
            {
                GetVendedoresTable();

                lbApellido.Visibility = Visibility.Visible;
                lbPassword.Visibility = Visibility.Visible;
                lbCorreo.Visibility = Visibility.Visible;
                txtApellido.Visibility = Visibility.Visible;
                txtCorreo.Visibility = Visibility.Visible;
                txtPassword.Visibility = Visibility.Visible;
                txtSaldo.Visibility = Visibility.Hidden;
                lbSaldo.Visibility = Visibility.Hidden;
                cbRol.Visibility = Visibility.Hidden;
                lbApellido.Content = "Apellido";
                lbCorreo.Content = "Correo";
                lbPassword.Content = "Contraseña";
                lbtamaño.Visibility = Visibility.Hidden;
                lblote.Visibility = Visibility.Hidden;
                lbsabor.Visibility = Visibility.Hidden;
                cbLote.Visibility = Visibility.Hidden;
                cbSabor.Visibility = Visibility.Hidden;
                cbTamaño.Visibility = Visibility.Hidden;
                ClienteTable.Visibility = Visibility.Hidden;
                ProductosTable.Visibility = Visibility.Hidden;
                SuperAdminTable.Visibility = Visibility.Hidden;
                VendedorTable.Visibility = Visibility.Visible;
                DetalleVentaTable.Visibility = Visibility.Hidden;
                TamañosTable.Visibility = Visibility.Hidden;
                SaboresTable.Visibility = Visibility.Hidden;
                LotesTable.Visibility = Visibility.Hidden;
                txtNombre.Clear();
                txtCorreo.Clear();
                txtApellido.Clear();
                txtPassword.Clear();
                txtPkUser.Clear();
                txtSaldo.Clear();


            } else if (cboptionsUsers.SelectedItem == "Producto")
            {
                GetProductosTable();

                txtSaldo.Visibility = Visibility.Hidden;
                lbSaldo.Visibility = Visibility.Visible;
                txtSaldo.Visibility = Visibility.Visible;
                lbsabor.Visibility = Visibility.Visible;
                lblote.Visibility = Visibility.Visible;
                lbtamaño.Visibility = Visibility.Visible;
                lbApellido.Content = "Cantidad";
                lbSaldo.Content = "Precio unitario";
                lbCorreo.Content = "Coloca ID de vendedor/SA";
                lbPassword.Visibility = Visibility.Hidden;
                txtPassword.Visibility = Visibility.Hidden;
                cbLote.Visibility = Visibility.Visible;
                cbRol.Visibility = Visibility.Hidden;
                cbSabor.Visibility = Visibility.Visible;
                cbTamaño.Visibility = Visibility.Visible;
                ClienteTable.Visibility = Visibility.Hidden;
                ProductosTable.Visibility = Visibility.Hidden;
                VendedorTable.Visibility = Visibility.Hidden;
                ProductosTable.Visibility = Visibility.Visible;
                DetalleVentaTable.Visibility = Visibility.Hidden;
                TamañosTable.Visibility = Visibility.Hidden;
                SaboresTable.Visibility = Visibility.Hidden;
                LotesTable.Visibility = Visibility.Hidden;
                txtNombre.Clear();
                txtCorreo.Clear();
                txtApellido.Clear();
                txtPassword.Clear();
                txtPkUser.Clear();
                txtSaldo.Clear();



            } else if (cboptionsUsers.SelectedItem == "SA")
            {

                lbApellido.Visibility = Visibility.Visible;
                lbPassword.Visibility = Visibility.Visible;
                lbCorreo.Visibility = Visibility.Visible;
                txtApellido.Visibility = Visibility.Visible;
                txtCorreo.Visibility = Visibility.Visible;
                txtPassword.Visibility = Visibility.Visible;
                GetSuperAdminTable();
                txtSaldo.Visibility = Visibility.Hidden;
                lbSaldo.Visibility = Visibility.Hidden;
                cbRol.Visibility = Visibility.Hidden;
                lbApellido.Content = "Apellido";
                lbCorreo.Content = "Correo";
                lbPassword.Content = "Contraseña";
                lbtamaño.Visibility = Visibility.Hidden;
                lblote.Visibility = Visibility.Hidden;
                lbsabor.Visibility = Visibility.Hidden;
                cbLote.Visibility = Visibility.Hidden;
                cbSabor.Visibility = Visibility.Hidden;
                cbTamaño.Visibility = Visibility.Hidden;
                ClienteTable.Visibility = Visibility.Hidden;
                VendedorTable.Visibility = Visibility.Hidden;
                ProductosTable.Visibility = Visibility.Hidden;
                SuperAdminTable.Visibility = Visibility.Visible;
                DetalleVentaTable.Visibility = Visibility.Hidden;
                SaboresTable.Visibility = Visibility.Hidden;
                TamañosTable.Visibility = Visibility.Hidden;
                LotesTable.Visibility = Visibility.Hidden;
                txtNombre.Clear();
                txtCorreo.Clear();
                txtApellido.Clear();
                txtPassword.Clear();
                txtPkUser.Clear();
                txtSaldo.Clear();

            } else if (cboptionsUsers.SelectedItem == "Detalle de ventas")
            {
                DetalleVentaTable.Visibility = Visibility.Visible;
                GetDetalleVentaTable();
            } else if (cboptionsUsers.SelectedItem == "Sabores")
            {
                
                lbApellido.Visibility = Visibility.Hidden;
                lbPassword.Visibility = Visibility.Hidden;
                lbCorreo.Visibility = Visibility.Hidden;
                txtSaldo.Visibility = Visibility.Hidden;
                txtApellido.Visibility = Visibility.Hidden;
                txtCorreo.Visibility = Visibility.Hidden;
                txtPassword.Visibility = Visibility.Hidden;
                SaboresTable.Visibility = Visibility.Visible;
                ClienteTable.Visibility = Visibility.Hidden;
                VendedorTable.Visibility = Visibility.Hidden;
                ProductosTable.Visibility = Visibility.Hidden;
                SuperAdminTable.Visibility = Visibility.Hidden;
                DetalleVentaTable.Visibility = Visibility.Hidden;
                TamañosTable.Visibility = Visibility.Hidden;
                LotesTable.Visibility = Visibility.Hidden;
                cbLote.Visibility = Visibility.Hidden;
                cbSabor.Visibility = Visibility.Hidden;
                cbTamaño.Visibility = Visibility.Hidden;
                lbtamaño.Visibility = Visibility.Hidden;
                lblote.Visibility = Visibility.Hidden;
                lbsabor.Visibility = Visibility.Hidden;
                lbSaldo.Visibility = Visibility.Hidden;
                GetSaboresTables();

            } else if (cboptionsUsers.SelectedItem == "Tamanos")
            {
                txtSaldo.Visibility = Visibility.Hidden;
                lbApellido.Visibility = Visibility.Hidden;
                lbPassword.Visibility = Visibility.Hidden;
                lbCorreo.Visibility = Visibility.Hidden;
                txtApellido.Visibility = Visibility.Hidden;
                txtCorreo.Visibility = Visibility.Hidden;
                txtPassword.Visibility = Visibility.Hidden;
                TamañosTable.Visibility = Visibility.Visible;
                ClienteTable.Visibility = Visibility.Hidden;
                VendedorTable.Visibility = Visibility.Hidden;
                ProductosTable.Visibility = Visibility.Hidden;
                SuperAdminTable.Visibility = Visibility.Hidden;
                DetalleVentaTable.Visibility = Visibility.Hidden;
                SaboresTable.Visibility = Visibility.Hidden;
                LotesTable.Visibility = Visibility.Hidden;
                cbLote.Visibility = Visibility.Hidden;
                cbSabor.Visibility = Visibility.Hidden;
                cbTamaño.Visibility = Visibility.Hidden;
                lbtamaño.Visibility = Visibility.Hidden;
                lblote.Visibility = Visibility.Hidden;
                lbsabor.Visibility = Visibility.Hidden;
                lbSaldo.Visibility = Visibility.Hidden;
                GetTamanosTable();
            } else if (cboptionsUsers.SelectedItem == "Lotes")
            {
                lbApellido.Visibility = Visibility.Hidden;
                lbPassword.Visibility = Visibility.Hidden;
                lbCorreo.Visibility = Visibility.Hidden;
                txtApellido.Visibility = Visibility.Hidden;
                txtCorreo.Visibility = Visibility.Hidden;
                txtPassword.Visibility = Visibility.Hidden;
                txtSaldo.Visibility = Visibility.Hidden;
                LotesTable.Visibility = Visibility.Visible;
                ClienteTable.Visibility = Visibility.Hidden;
                VendedorTable.Visibility = Visibility.Hidden;
                ProductosTable.Visibility = Visibility.Hidden;
                SuperAdminTable.Visibility = Visibility.Hidden;
                DetalleVentaTable.Visibility = Visibility.Hidden;
                SaboresTable.Visibility = Visibility.Hidden;
                TamañosTable.Visibility = Visibility.Hidden;
                cbLote.Visibility = Visibility.Hidden;
                cbSabor.Visibility = Visibility.Hidden;
                cbTamaño.Visibility = Visibility.Hidden;
                lbtamaño.Visibility = Visibility.Hidden;
                lblote.Visibility = Visibility.Hidden;
                lbsabor.Visibility = Visibility.Hidden;
                lbSaldo.Visibility = Visibility.Hidden;

                GetLotesTable();
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
            cbLote.DisplayMemberPath = "NomLote";
            cbLote.SelectedValuePath = "PkLote";
        }
        public void GetTamañosB()
        {
            cbTamaño.ItemsSource = modProducto.GetTamaños();
            cbRol.DisplayMemberPath = "TamanoP";
            cbRol.SelectedValuePath = "PkTamano";
        }
        public void GetClientesTable()
        {
            ClienteTable.ItemsSource = modSA.GetClientes();
        }
        public void GetVendedoresTable()
        {
            VendedorTable.ItemsSource = modSA.GetVendedores();
        }
        public void GetProductosTable()
        {
            ProductosTable.ItemsSource = modProducto.GetProductos();

        }
        public void GetSuperAdminTable()
        {
            SuperAdminTable.ItemsSource = modSA.GetSuperAdmins();
        }
        public void GetDetalleVentaTable()
        {
            DetalleVentaTable.ItemsSource = modProducto.GetDetalleVentas();
        }
        public void GetSaboresTables()
        {
            SaboresTable.ItemsSource = modProducto.GetSabores();
        }
        public void GetLotesTable()
        {
            LotesTable.ItemsSource = modProducto.GetLotes();
        }
        public void GetTamanosTable()
        {
            TamañosTable.ItemsSource = modProducto.GetTamaños();
        }
        public void EditItemCliente(Object sender, RoutedEventArgs e)
        {
            Cliente modC = new Cliente();

            modC = (sender as FrameworkElement).DataContext as Cliente;

            txtNombre.Text = modC.NombreCliente.ToString();
            txtApellido.Text = modC.ApellidoCliente.ToString();
            txtCorreo.Text = modC.CorreoCliente.ToString();
            txtPassword.Text = modC.PasswordCliente.ToString();
            txtSaldo.Text = modC.SaldoCliente.ToString();
            txtPkUser.Text = modC.PkCliente.ToString();
            cbRol.SelectedValue = modC.FkRol;
            txtCorreo.IsEnabled = true;
            cbRol.Visibility = Visibility.Visible;
        }
        public void EditItemVendedor(object sender, RoutedEventArgs e)
        {
            Vendedor vendedorc = new Vendedor();

            vendedorc = (sender as FrameworkElement).DataContext as Vendedor;

            txtNombre.Text = vendedorc.NombreVendedor.ToString();
            txtApellido.Text = vendedorc.ApellidoVendedor.ToString();
            txtCorreo.Text = vendedorc.CorreoV.ToString();
            txtPassword.Text = vendedorc.ContraseñaVendedor.ToString();
            txtPkUser.Text = vendedorc.PkVendedor.ToString();
            cbRol.SelectedValue = vendedorc.FkRol;
            txtCorreo.IsEnabled = true;
            cbRol.Visibility = Visibility.Visible;

        }
        public void EditItemSA(object sender, RoutedEventArgs e)
        {
            SuperAdmin sac = new SuperAdmin();

            sac = (sender as FrameworkElement).DataContext as SuperAdmin;


            txtPkUser.Text = sac.PkSuperAdmin.ToString();
            txtNombre.Text = sac.NombreSuperAdmin.ToString();
            txtApellido.Text = sac.ApellidoSuperAdmin.ToString();
            txtCorreo.Text = sac.CorreoSuperAdmin.ToString();
            txtPassword.Text = sac.ContraseñaSuperAdmin.ToString();
            cbRol.SelectedValue = sac.FkRol;
            txtCorreo.IsEnabled = true;
            cbRol.Visibility = Visibility.Visible;
        }
        public void EditItemProducto(object sender, RoutedEventArgs e)
        {
            Producto productoc = new Producto();

            productoc = (sender as FrameworkElement).DataContext as Producto;

            txtNombre.Text = productoc.Nombre.ToString();
            txtApellido.Text = productoc.Cantidad.ToString();
            txtSaldo.Text = productoc.PrecioUnitario.ToString();
            txtCorreo.Text = productoc.FkVendedor.ToString();
            txtPkUser.Text = productoc.PkProducto.ToString();
            cbLote.SelectedValue = productoc.FkLote;
            cbSabor.SelectedValue = productoc.FkSabor;
            cbTamaño.SelectedValue = productoc.FkTamano;
            txtCorreo.IsEnabled = false;

        }
        //EL
        public void EditItemSabor(object sender, RoutedEventArgs e)
        {
            Sabor saborc = new Sabor();
            saborc = (sender as FrameworkElement).DataContext as Sabor;
            txtNombre.Text = saborc.NameSabor.ToString();
            txtPkUser.Text = saborc.PkSabor.ToString();
        }
        public void EditItemTamano(object sender, RoutedEventArgs e)
        {
            Tamano tamanoc = new Tamano();
            tamanoc = (sender as FrameworkElement).DataContext as Tamano;
            txtNombre.Text = tamanoc.TamanoP.ToString();
            txtPkUser.Text = tamanoc.PkTamano.ToString();
        }
        public void EditItemLote(object sender, RoutedEventArgs e)
        {
            Lote lotec = new Lote();
            lotec = (sender as FrameworkElement).DataContext as Lote;
            txtNombre.Text = lotec.NomLote.ToString();
            txtPkUser.Text = lotec.PkLote.ToString();
        }
        public void DeleteItemCliente(object sender, RoutedEventArgs e)
        {
            
                Cliente deleteC = (sender as FrameworkElement).DataContext as Cliente;

                modcliente.DeleteCliente(deleteC);

                MessageBox.Show("Eliminado");
                GetClientesTable();
                txtNombre.Clear();
                txtCorreo.Clear();
                txtApellido.Clear();
                txtPassword.Clear();
                txtPkUser.Clear();
                txtSaldo.Clear();
        }
        public void DeteleItemVendedor(object sender, RoutedEventArgs e)
        {
            
                Vendedor deletev = (sender as FrameworkElement).DataContext as Vendedor;              
                modVendedor.DeleteVendedor(deletev);
                MessageBox.Show("Eliminado");
                GetVendedoresTable();
                txtNombre.Clear();
                txtCorreo.Clear();
                txtApellido.Clear();
                txtPassword.Clear();
                txtPkUser.Clear();
                txtSaldo.Clear();            
        }
        public void DeleteItemSA (object sender, RoutedEventArgs e)
        {
            
                SuperAdmin deleteSA = (sender as FrameworkElement).DataContext as SuperAdmin;
                

                modSA.DeleteSA(deleteSA);
                MessageBox.Show("Eliminado");
                GetSuperAdminTable();
                txtNombre.Clear();
                txtCorreo.Clear();
                txtApellido.Clear();
                txtPassword.Clear();
                txtPkUser.Clear();
                txtSaldo.Clear();
            
        }
        public void DeleteItemProducto (object sender, RoutedEventArgs e)
        {
            
                Producto DeleteP = (sender as FrameworkElement).DataContext as Producto;

                modProducto.DeleteProducto(DeleteP);
                MessageBox.Show("Eliminado");
            GetProductosTable();
                txtNombre.Clear();
                txtCorreo.Clear();
                txtApellido.Clear();
                txtPassword.Clear();
                txtPkUser.Clear();
                txtSaldo.Clear();
                GetVendedoresTable();
            
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

                    txtPkUser.Clear();
                    txtPassword.Clear();
                    txtSaldo.Clear();
                    txtApellido.Clear();
                    txtCorreo.Clear();
                    txtNombre.Clear();
                    GetClientesTable();

                }
                else if (txtPkUser.Text != "")
                {
                    ClienteF.PkCliente = int.Parse(txtPkUser.Text);
                    ClienteF.NombreCliente = txtNombre.Text;
                    ClienteF.ApellidoCliente = txtApellido.Text;
                    ClienteF.CorreoCliente = txtCorreo.Text;
                    ClienteF.PasswordCliente = txtPassword.Text;
                    ClienteF.SaldoCliente = double.Parse(txtSaldo.Text);
                    ClienteF.FkRol = int.Parse(cbRol.SelectedValue.ToString());
                    modcliente.UCliente(ClienteF);
                    MessageBox.Show("Se editó correctamente");
                    txtPkUser.Clear();
                    txtPassword.Clear();
                    txtSaldo.Clear();
                    txtApellido.Clear();
                    txtCorreo.Clear();
                    txtNombre.Clear();
                    GetClientesTable();
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

                    txtPkUser.Clear();
                    txtPassword.Clear();
                    txtSaldo.Clear();
                    txtApellido.Clear();
                    txtCorreo.Clear();
                    txtNombre.Clear();
                    GetVendedoresTable();
                } else if (txtPkUser.Text != "")
                {
                    vendedorF.PkVendedor = int.Parse(txtPkUser.Text);
                    vendedorF.NombreVendedor = txtNombre.Text;
                    vendedorF.ApellidoVendedor = txtApellido.Text;
                    vendedorF.CorreoV = txtCorreo.Text;
                    vendedorF.ContraseñaVendedor = txtPassword.Text;
                    vendedorF.FkRol = int.Parse(cbRol.SelectedValue.ToString());

                    modSA.UpdateVendedores(vendedorF);

                    MessageBox.Show("Se editó con éxito");

                    txtPkUser.Clear();
                    txtPassword.Clear();
                    txtSaldo.Clear();
                    txtApellido.Clear();
                    txtCorreo.Clear();
                    txtNombre.Clear();
                    GetVendedoresTable();
                }
            }
            else if (cboptionsUsers.SelectedItem == "SA")
            {
                SuperAdmin superAdminF = new SuperAdmin();
                if (txtPkUser.Text == "")
                {
                    superAdminF.NombreSuperAdmin = txtNombre.Text;
                    superAdminF.ApellidoSuperAdmin = txtApellido.Text;
                    superAdminF.CorreoSuperAdmin = txtCorreo.Text;
                    superAdminF.ContraseñaSuperAdmin = txtCorreo.Text;
                    superAdminF.FkRol = 3; //Se le asigna directamente 3 porque estamos registrando directamente
                    modSA.CreateAdmin(superAdminF);
                    MessageBox.Show("Agregado con éxito");
                    txtPkUser.Clear();
                    txtPassword.Clear();
                    txtSaldo.Clear();
                    txtApellido.Clear();
                    txtCorreo.Clear();
                    txtNombre.Clear();
                    GetSuperAdminTable();
                }
                else if (txtPkUser.Text != "")
                {
                    superAdminF.PkSuperAdmin = int.Parse(txtPkUser.Text);
                    superAdminF.NombreSuperAdmin = txtNombre.Text;
                    superAdminF.ApellidoSuperAdmin = txtApellido.Text;
                    superAdminF.CorreoSuperAdmin = txtCorreo.Text;
                    superAdminF.ContraseñaSuperAdmin = txtCorreo.Text;

                    superAdminF.FkRol = int.Parse(cbRol.SelectedValue.ToString());
                    modSA.UpdateSA(superAdminF);
                    MessageBox.Show("Se editó con exito");
                    txtPkUser.Clear();
                    txtPassword.Clear();
                    txtSaldo.Clear();
                    txtApellido.Clear();
                    txtCorreo.Clear();
                    txtNombre.Clear();
                    GetSuperAdminTable();
                }
            }
            else if (cboptionsUsers.SelectedItem == "Producto")
            {
                Producto ProductoF = new Producto();
                if (txtPkUser.Text == "")
                {
                    int IDSA = int.Parse(txtCorreo.Text);
                    //Pendiente por pedir fk de vendedor
                    ProductoF.Nombre = txtNombre.Text;
                    ProductoF.Cantidad = int.Parse(txtApellido.Text);
                    ProductoF.PrecioUnitario = double.Parse(txtSaldo.Text);
                    ProductoF.FkVendedor = int.Parse(txtCorreo.Text); //Tener en cuenta que esto es para asignar un vendedor al producto
                    ProductoF.FkLote = int.Parse(cbLote.Text.ToString());
                    ProductoF.FkTamano = int.Parse(cbTamaño.SelectedValue.ToString());
                    ProductoF.FkSabor = int.Parse(cbTamaño.SelectedValue.ToString());

                    //Al tratarse de un superadmin, tendrá que ingresar el id de Superadmin

                    modProducto.CreateProducto(ProductoF, IDSA);

                    MessageBox.Show("Producto agregado");
                    txtPkUser.Clear();
                    txtPassword.Clear();
                    txtSaldo.Clear();
                    txtApellido.Clear();
                    txtCorreo.Clear();
                    txtNombre.Clear();
                    //
                    GetProductosTable();

                }
                else if (txtPkUser.Text != "")
                {
                    ProductoF.FkVendedor = int.Parse(txtCorreo.Text);
                    ProductoF.PkProducto = int.Parse(txtPkUser.Text);
                    ProductoF.Nombre = txtNombre.Text;
                    ProductoF.Cantidad = int.Parse(txtApellido.Text);
                    ProductoF.PrecioUnitario = double.Parse(txtSaldo.Text);
                    ProductoF.FkLote = int.Parse(cbLote.SelectedValue.ToString());
                    ProductoF.FkTamano = int.Parse(cbTamaño.SelectedValue.ToString());
                    ProductoF.FkSabor = int.Parse(cbTamaño.SelectedValue.ToString());

                    modProducto.UpdateProducto(ProductoF);

                    MessageBox.Show("Producto actualizado");
                    GetProductosTable();
                    txtCorreo.IsEnabled = true;
                    txtPkUser.Clear();
                    txtPassword.Clear();
                    txtSaldo.Clear();
                    txtApellido.Clear();
                    txtCorreo.Clear();
                    txtNombre.Clear();

                }
            }
            else if (cboptionsUsers.SelectedItem == "Tamanos") {
                Tamano tamanoc = new Tamano();
                if (txtPkUser.Text == "")
                {
                    if (txtNombre.Text != "")
                    {
                        tamanoc.TamanoP = txtNombre.Text;
                        modProducto.CreateTamaño(tamanoc);

                        MessageBox.Show("Agregado");
                        txtPkUser.Clear();
                        txtNombre.Clear();
                        GetTamanosTable();
                    } else
                    {
                        MessageBox.Show("Hay datos vacíos");
                    }
                }
                else {
                    int IDT = int.Parse(txtPkUser.Text);
                    tamanoc.TamanoP = txtNombre.Text;
                    modProducto.UpdateTamano(tamanoc.TamanoP, IDT);
                    MessageBox.Show("Actualizado");
                    GetTamanosTable();
                }
                
            } else if (cboptionsUsers.SelectedItem == "Sabores")
            {
                Sabor sabor = new Sabor();
                if (txtPkUser.Text == "")
                {
                    if (txtNombre.Text != "")
                    {
                        //int IDS = int.Parse(txtPkUser.Text);
                        sabor.NameSabor = txtNombre.Text;

                        modProducto.CreateSabor(sabor);
                        MessageBox.Show("Agregado");
                        txtPkUser.Clear();
                        txtNombre.Clear();
                        GetSaboresTables();
                        GetSabores();
                    } else
                    {
                        MessageBox.Show("Hay datos vacíos");
                    }
                } else
                {
                    int ids = int.Parse(txtPkUser.Text);
                    sabor.NameSabor = txtNombre.Text;

                    modProducto.UpdateSabor(sabor.NameSabor, ids);
                    MessageBox.Show("Actualizado");
                    txtPkUser.Clear();
                    txtNombre.Clear();
                    GetSaboresTables();
                    GetSabores();
                }

            } else if (cboptionsUsers.SelectedItem == "Lotes")
            {
                Lote lotec = new Lote();
                if (txtPkUser.Text == "")
                {
                    if (txtNombre.Text != "")
                    {
                       
                        lotec.NomLote = int.Parse(txtNombre.Text);
                        modProducto.CreateLote(lotec);
                        MessageBox.Show("Agregado");
                        txtPkUser.Clear();
                        txtNombre.Clear();
                        GetLotesTable();
                    } else
                    {
                        MessageBox.Show("Hay datos vacíos");
                    }
                } else
                {
                    int IDL = int.Parse(txtPkUser.Text);
                    lotec.NomLote = int.Parse(txtNombre.Text);

                    modProducto.UpdateLote(lotec.NomLote, IDL);
                    MessageBox.Show("Actualizado");
                    txtPkUser.Clear();
                    txtNombre.Clear();
                    GetLotesTable();
                }
            }
            
            
            else if (cboptionsUsers.SelectedItem == null)
            {
                MessageBox.Show("No has seleccionado el tipo de usuario");
            }
        }       
    }
}
