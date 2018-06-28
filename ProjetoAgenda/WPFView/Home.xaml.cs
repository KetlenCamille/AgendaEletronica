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
using Controllers;

namespace WPFView
{
    /// <summary>
    /// Lógica interna para Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        private void ButtonPopUpLogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UsuarioController usuario = new UsuarioController();
            dgEstabBanco.ItemsSource = usuario.ListarTodos();
        }

        private void ListCategoria(object sender, SelectionChangedEventArgs e)
        {
            if(bancoItem.IsSelected)
            {
                string categoria = "Banco";
                EstabelecimentoController estabelecimentoController = new EstabelecimentoController();
                dgBanco.ItemsSource = estabelecimentoController.ListarPorCategoria(categoria);
            }
            
        }

        private void alterarDadosConta_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
