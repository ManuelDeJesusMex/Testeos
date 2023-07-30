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
    /// Lógica de interacción para MenuVendedor.xaml
    /// </summary>
    public partial class MenuVendedor : Window
    {
        public MenuVendedor()
        {
            InitializeComponent();
            GetProductosU();
            GetLotes();
            GetTamaños();
            GetSabores();

        }
        CrudProducto modproducto = new CrudProducto();


        public void GetProductosU()
        {
            ProductosTable.ItemsSource = modproducto.GetProductos();
        }
        public void GetSabores()
        {
            cbSabor.ItemsSource = modproducto.GetSabores();
            cbSabor.DisplayMemberPath = "NameSabor";
            cbSabor.SelectedValuePath = "PkSabor";
        }
        public void GetTamaños()
        {
            cbTamaño.ItemsSource = modproducto.GetTamaños();
            cbTamaño.DisplayMemberPath = "TamañoP";
            cbTamaño.SelectedValuePath = "PkTamaño";
        }
        public void GetLotes ()
        {
            cbLote.ItemsSource = modproducto.GetLotes();
            cbLote.DisplayMemberPath = "NomLote";
            cbLote.SelectedValuePath = "PkLote";
        }

        public void EditItemProducto (object sender, RoutedEventArgs e)
        {
            Producto producto = new Producto();

            producto = (sender as FrameworkElement).DataContext as Producto;
            txtNombre.Text = producto.Nombre.ToString();
            txtPkProducto.Text = producto.PkProducto.ToString();
            txtIDVendedor.Text = producto.FkVendedor.ToString();
            txtPrecioUnitario.Text = producto.PrecioUnitario.ToString();
            txtCantidad.Text = producto.Cantidad.ToString();
            cbLote.SelectedValue = producto.FkLote;
            cbTamaño.SelectedValue = producto.FkTamano;
            cbSabor.SelectedValue = producto.FkSabor;
            txtIDVendedor.IsEnabled = false;
        }
        public void DeleteItemProducto (object sender, RoutedEventArgs e)
        {
            Producto productoD = (sender as FrameworkElement).DataContext as Producto;

            modproducto.DeleteProducto (productoD);
            GetProductosU();
            MessageBox.Show("Eliminado");
            txtCantidad.Clear();
            txtIDVendedor.Clear();
            txtNombre.Clear();
            txtPrecioUnitario.Clear();
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Producto productoF = new Producto();
            if (txtPkProducto.Text == "")
            {
                int IDV = int.Parse(txtIDVendedor.Text);
                productoF.Nombre = txtNombre.Text;
                productoF.Cantidad = int.Parse(txtCantidad.Text);
                productoF.FkVendedor = int.Parse(txtIDVendedor.Text);
                productoF.PrecioUnitario = double.Parse(txtPrecioUnitario.Text);
                productoF.FkTamano = int.Parse(cbTamaño.SelectedValue.ToString());
                productoF.FkSabor = int.Parse(cbSabor.SelectedValue.ToString());
                productoF.FkLote = int.Parse(cbLote.SelectedValue.ToString());
                txtIDVendedor.IsEnabled = true;
                modproducto.CreateProducto(productoF, IDV);

                MessageBox.Show("Producto agregado");

                txtCantidad.Clear();
                txtIDVendedor.Clear();
                txtNombre.Clear();
                txtPrecioUnitario.Clear();
                cbLote.SelectedItem = null;
                cbTamaño.SelectedItem = null;
                cbSabor.SelectedItem = null;
                GetProductosU();

            } else if (txtPkProducto.Text != "")
            {
                productoF.FkVendedor = int.Parse(txtIDVendedor.Text);
                productoF.Nombre = txtNombre.Text;
                productoF.PkProducto = int.Parse(txtPkProducto.Text);
                productoF.Cantidad = int.Parse(txtCantidad.Text);
                productoF.PrecioUnitario = double.Parse(txtPrecioUnitario.Text);
                productoF.FkLote = int.Parse(cbLote.SelectedValue.ToString());
                productoF.FkSabor = int.Parse(cbSabor.SelectedValue.ToString());
                productoF.FkTamano = int.Parse(cbTamaño.SelectedValue.ToString());

                modproducto.UpdateProducto(productoF);

                MessageBox.Show("Producto actualizado");

                txtCantidad.Clear();
                txtIDVendedor.Clear();
                txtNombre.Clear();
                txtPrecioUnitario.Clear();
                cbLote.SelectedItem = null;
                cbTamaño.SelectedItem = null;
                cbSabor.SelectedItem = null;
                txtIDVendedor.IsEnabled = true;
                GetProductosU();
                 //JJJ

            }
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow logout = new MainWindow();

            logout.Show();

            Close();
        }
    }
}
