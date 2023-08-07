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
using System.Windows.Shapes;
using TestProyecto.Context;
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
            cbSearchOptions.Items.Add("NomProducto");
            cbSearchOptions.Items.Add("Nombre");
            cbSearchOptions.Items.Add("Cantidad");
            cbSearchOptions.Items.Add("Precio");
            cbSearchOptions.Items.Add("Vendido por");
            cbSearchOptions.Items.Add("Sabor");
            cbSearchOptions.Items.Add("Lote");
            
            
            
        }
        CrudProducto watchP = new CrudProducto();
        CrudCliente Compra = new CrudCliente();
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

        private void btnComprar_Click(object sender, RoutedEventArgs e)
        {
            if (txtCantidad.Text != "" && txtIDCliente.Text != "" && txtIDProducto.Text != "")
            {
                int IDC = int.Parse(txtIDCliente.Text);
                int IDP = int.Parse(txtIDProducto.Text);
                int Cantidad = int.Parse(txtCantidad.Text);

                Compra.Compra(IDP, Cantidad, IDC);

                GetProductos();

            } else
            {
                MessageBox.Show("Hay campos vacíos");
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text != "")
            {
                double Precio; 
                int ID;
                string Dato; 

                using (var _context = new ApplicationDbContext())
                {
                    if (cbSearchOptions.SelectedItem == "NomProducto")
                    {
                        ID = int.Parse(txtSearch.Text);

                        if (cbOptionsConditions.SelectedItem == "Específico")
                        {
                            
                            var Busqueda = _context.Productos.Where(x => x.PkProducto == ID).ToList();
                          //  var BusquedaFk = _context.Productos.Where(x => x.PkProducto == ID).Include(y => y.FkLote.ToString()).ToList();
                            ProductosTable.ItemsSource = Busqueda;
                            }
                            else if (cbOptionsConditions.SelectedItem == "Mayor que")
                            {
                                var Busqueda = _context.Productos.Where(x => x.PkProducto > ID).ToList();
                                ProductosTable.ItemsSource = Busqueda;

                            }
                            else if (cbOptionsConditions.SelectedItem == "Menor que")
                            {
                                var Busqueda = _context.Productos.Where(x => x.PkProducto < ID).ToList();
                                ProductosTable.ItemsSource = Busqueda;
                            }
                            else if (cbOptionsConditions.SelectedItem == "Diferente que")
                            {
                                var Busqueda = _context.Productos.Where(x => x.PkProducto != ID).ToList();
                                ProductosTable.ItemsSource = Busqueda;
                            }
                            else
                            {
                                MessageBox.Show("Aún no seleccionas una condicional");
                            }


                         
                        
                    }
                    else if (cbSearchOptions.SelectedItem == "Nombre")
                    {
                        Dato = txtSearch.Text;
                        if (cbOptionsConditions.SelectedItem == "Específico")
                        {
                            var Busqueda = _context.Productos.Where(x => x.Nombre == Dato).ToList();
                            ProductosTable.ItemsSource = Busqueda;
                        }
                        else if (cbOptionsConditions.SelectedItem == "Diferente que")
                        {
                            var Busqueda = _context.Productos.Where(x => x.Nombre != Dato).ToList();
                            ProductosTable.ItemsSource = Busqueda;
                        }
                        else
                        {
                            MessageBox.Show("Aún no seleccionas una condicional");
                        }

                    }
                    else if (cbSearchOptions.SelectedItem == "Cantidad")
                    {
                        ID = int.Parse(txtSearch.Text);
                        if (cbOptionsConditions.SelectedItem == "Específico")
                        {
                            var Busqueda = _context.Productos.Where(x => x.Cantidad == ID).ToList();
                            ProductosTable.ItemsSource = Busqueda;
                        }
                        else if (cbOptionsConditions.SelectedItem == "Mayor que")
                        {
                            var Busqueda = _context.Productos.Where(x => x.Cantidad > ID).ToList();
                            ProductosTable.ItemsSource = Busqueda;

                        }
                        else if (cbOptionsConditions.SelectedItem == "Menor que")
                        {
                            var Busqueda = _context.Productos.Where(x => x.Cantidad < ID).ToList();
                            ProductosTable.ItemsSource = Busqueda;
                        }
                        else if (cbOptionsConditions.SelectedItem == "Diferente que")
                        {
                            var Busqueda = _context.Productos.Where(x => x.Cantidad != ID).ToList();
                            ProductosTable.ItemsSource = Busqueda;
                        }
                        else
                        {
                            MessageBox.Show("Aún no seleccionas una condicional");
                        }
                    }
                    else if (cbSearchOptions.SelectedItem == "Precio")
                    {
                        Precio = double.Parse(txtSearch.Text);
                        if (cbOptionsConditions.SelectedItem == "Específico")
                        {
                            var Busqueda = _context.Productos.Where(x => x.PrecioUnitario == Precio).ToList();
                            ProductosTable.ItemsSource = Busqueda;
                        }
                        else if (cbOptionsConditions.SelectedItem == "Mayor que")
                        {
                            var Busqueda = _context.Productos.Where(x => x.PrecioUnitario > Precio).ToList();
                            ProductosTable.ItemsSource = Busqueda;

                        }
                        else if (cbOptionsConditions.SelectedItem == "Menor que")
                        {
                            var Busqueda = _context.Productos.Where(x => x.PrecioUnitario < Precio).ToList();
                            ProductosTable.ItemsSource = Busqueda;
                        }
                        else if (cbOptionsConditions.SelectedItem == "Diferente que")
                        {
                            var Busqueda = _context.Productos.Where(x => x.PrecioUnitario != Precio).ToList();
                            ProductosTable.ItemsSource = Busqueda;
                        }
                        else
                        {
                            MessageBox.Show("Aún no seleccionas una condicional");
                        }
                    }
                    else if (cbSearchOptions.SelectedItem == "Vendido por")
                    {
                        ID = int.Parse(txtSearch.Text);

                        if (cbOptionsConditions.SelectedItem == "Específico")
                        {
                            var Busqueda = _context.Productos.Where(x => x.FkVendedor == ID).ToList();
                            //  var BusquedaFk = _context.Productos.Where(x => x.PkProducto == ID).Include(y => y.FkLote.ToString()).ToList();
                            ProductosTable.ItemsSource = Busqueda;
                        }
                        else if (cbOptionsConditions.SelectedItem == "Mayor que")
                        {
                            var Busqueda = _context.Productos.Where(x => x.FkVendedor > ID).ToList();
                            ProductosTable.ItemsSource = Busqueda;

                        }
                        else if (cbOptionsConditions.SelectedItem == "Menor que")
                        {
                            var Busqueda = _context.Productos.Where(x => x.FkVendedor < ID).ToList();
                            ProductosTable.ItemsSource = Busqueda;
                        }
                        else if (cbOptionsConditions.SelectedItem == "Diferente que")
                        {
                            var Busqueda = _context.Productos.Where(x => x.FkVendedor != ID).ToList();
                            ProductosTable.ItemsSource = Busqueda;
                        }
                        else
                        {
                            MessageBox.Show("Aún no seleccionas una condicional");
                        }
                    }
                    else if (cbSearchOptions.SelectedItem == "Lote")
                    {
                        ID = int.Parse(txtSearch.Text);

                        if (cbOptionsConditions.SelectedItem == "Específico")
                        {
                            var Busqueda = _context.Productos.Where(x => x.FkLote == ID).ToList();
                            //  var BusquedaFk = _context.Productos.Where(x => x.PkProducto == ID).Include(y => y.FkLote.ToString()).ToList();
                            ProductosTable.ItemsSource = Busqueda;
                        }
                        else if (cbOptionsConditions.SelectedItem == "Mayor que")
                        {
                            var Busqueda = _context.Productos.Where(x => x.FkLote > ID).ToList();
                            ProductosTable.ItemsSource = Busqueda;

                        }
                        else if (cbOptionsConditions.SelectedItem == "Menor que")
                        {
                            var Busqueda = _context.Productos.Where(x => x.FkLote < ID).ToList();
                            ProductosTable.ItemsSource = Busqueda;
                        }
                        else if (cbOptionsConditions.SelectedItem == "Diferente que")
                        {
                            var Busqueda = _context.Productos.Where(x => x.FkLote != ID).ToList();
                            ProductosTable.ItemsSource = Busqueda;
                        }
                        //AAAAAA
                        else
                        {
                            MessageBox.Show("Aún no seleccionas una condicional");
                        }
                    }
                    else if (cbSearchOptions.SelectedItem == "Sabor")
                    {
                        ID = int.Parse(txtSearch.Text);

                        if (cbOptionsConditions.SelectedItem == "Específico")
                        {
                            var Busqueda = _context.Productos.Where(x => x.FkSabor == ID).ToList();
                            //  var BusquedaFk = _context.Productos.Where(x => x.PkProducto == ID).Include(y => y.FkLote.ToString()).ToList();
                            ProductosTable.ItemsSource = Busqueda;
                        }
                        else if (cbOptionsConditions.SelectedItem == "Mayor que")
                        {
                            var Busqueda = _context.Productos.Where(x => x.FkSabor > ID).ToList();
                            ProductosTable.ItemsSource = Busqueda;

                        }
                        else if (cbOptionsConditions.SelectedItem == "Menor que")
                        {
                            var Busqueda = _context.Productos.Where(x => x.FkSabor < ID).ToList();
                            ProductosTable.ItemsSource = Busqueda;
                        }
                        else if (cbOptionsConditions.SelectedItem == "Diferente que")
                        {
                            var Busqueda = _context.Productos.Where(x => x.FkSabor != ID).ToList();
                            ProductosTable.ItemsSource = Busqueda;
                        }
                        else
                        {
                            MessageBox.Show("Aún no seleccionas una condicional");
                        }
                    }
                    else if (cbSearchOptions.SelectedItem == "Tamano")
                    {
                        ID = int.Parse(txtSearch.Text);

                        if (cbOptionsConditions.SelectedItem == "Específico")
                        {
                            var Busqueda = _context.Productos.Where(x => x.FkTamano == ID).ToList();
                            //  var BusquedaFk = _context.Productos.Where(x => x.PkProducto == ID).Include(y => y.FkLote.ToString()).ToList();
                            ProductosTable.ItemsSource = Busqueda;
                        }
                        else if (cbOptionsConditions.SelectedItem == "Mayor que")
                        {
                            var Busqueda = _context.Productos.Where(x => x.FkTamano > ID).ToList();
                            ProductosTable.ItemsSource = Busqueda;

                        }
                        else if (cbOptionsConditions.SelectedItem == "Menor que")
                        {
                            var Busqueda = _context.Productos.Where(x => x.FkTamano < ID).ToList();
                            ProductosTable.ItemsSource = Busqueda;
                        }
                        else if (cbOptionsConditions.SelectedItem == "Diferente que")
                        {
                            var Busqueda = _context.Productos.Where(x => x.FkTamano != ID).ToList();
                            ProductosTable.ItemsSource = Busqueda;
                        }
                        else
                        {
                            MessageBox.Show("Aún no seleccionas una condicional");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No has seleccionado ningún dato para buscar");
                    }
                }
           
            }  else
            {
                MessageBox.Show("No has ingresado ningún dato de búsqueda");
            }         
        }

        private void cbSearchOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbSearchOptions.SelectedItem == "NomProducto")
            {
                cbOptionsConditions.Items.Clear();
                cbOptionsConditions.Items.Add("Específico");
                cbOptionsConditions.Items.Add("Mayor que");
                cbOptionsConditions.Items.Add("Menor que");
                cbOptionsConditions.Items.Add("Diferente que");
            }
            else if (cbSearchOptions.SelectedItem == "Nombre")
            {
                cbOptionsConditions.Items.Clear();
                cbOptionsConditions.Items.Add("Específico");
                cbOptionsConditions.Items.Add("Diferente que");
            }
            else if (cbSearchOptions.SelectedItem == "Cantidad")
            {
                cbOptionsConditions.Items.Clear();
                cbOptionsConditions.Items.Add("Específico");
                cbOptionsConditions.Items.Add("Mayor que");
                cbOptionsConditions.Items.Add("Menor que");
                cbOptionsConditions.Items.Add("Diferente que");
            }
            else if (cbSearchOptions.SelectedItem == "Precio")
            {
                cbOptionsConditions.Items.Clear();
                cbOptionsConditions.Items.Add("Específico");
                cbOptionsConditions.Items.Add("Mayor que");
                cbOptionsConditions.Items.Add("Menor que");
                cbOptionsConditions.Items.Add("Diferente que");
            }
            else if (cbSearchOptions.SelectedItem == "Vendido por")
            {
                MessageBox.Show("Ten en cuenta que se debe buscar por el número de vendedor");
                cbOptionsConditions.Items.Clear();
                cbOptionsConditions.Items.Add("Específico");
                cbOptionsConditions.Items.Add("Mayor que");
                cbOptionsConditions.Items.Add("Menor que");
                cbOptionsConditions.Items.Add("Diferente que");
            }
            else if (cbSearchOptions.SelectedItem == "Lote")
            {
                MessageBox.Show("Ten en cuenta que se debe buscar por el número de lote");
                cbOptionsConditions.Items.Clear();
                cbOptionsConditions.Items.Add("Específico");
                cbOptionsConditions.Items.Add("Mayor que");
                cbOptionsConditions.Items.Add("Menor que");
                cbOptionsConditions.Items.Add("Diferente que");
            }
            else if (cbSearchOptions.SelectedItem == "Sabor")
            {
                MessageBox.Show("Ten en cuenta que se debe buscar por el número de sabor");
                cbOptionsConditions.Items.Clear();
                cbOptionsConditions.Items.Add("Específico");
                cbOptionsConditions.Items.Add("Mayor que");
                cbOptionsConditions.Items.Add("Menor que");
                cbOptionsConditions.Items.Add("Diferente que");
            }
            else if (cbSearchOptions.SelectedItem == "Tamano")
            {
                MessageBox.Show("Ten en cuenta que se debe buscar por el número de tamaño");
                cbOptionsConditions.Items.Clear();
                cbOptionsConditions.Items.Add("Específico");
                cbOptionsConditions.Items.Add("Mayor que");
                cbOptionsConditions.Items.Add("Menor que");
                cbOptionsConditions.Items.Add("Diferente que");
            }
        }
    }
}
