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

namespace TestProyecto.Views
{
    /// <summary>
    /// Lógica de interacción para MenuGeneral.xaml
    /// </summary>
    public partial class MenuGeneral : Window
    {
        public MenuGeneral()
        {
            InitializeComponent();
            

        }

        

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            
            MainWindow Login = new MainWindow();
            Login.Show();
            Close();
        }

        private void btnAdminUsers_Click(object sender, RoutedEventArgs e)
        {
            MenuAdminSA sa = new MenuAdminSA();

            sa.Show();
            Close();
            //JASIJFD
        }
    }
}
