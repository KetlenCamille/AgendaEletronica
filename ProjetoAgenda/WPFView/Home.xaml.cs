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
using Models;

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

            var usuario = Application.Current.Properties["_user"] as Usuario;

            //btn_alterarDados.Content = usuario.NomeUsuario;

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

        private void ListCategoria(object sender, SelectionChangedEventArgs e)
        {
            EstabelecimentoController estabelecimentoController = new EstabelecimentoController();
            string categoria;
            if (bancoItem.IsSelected)
            {
                categoria = "Banco";
                dgBanco.ItemsSource = estabelecimentoController.ListarPorCategoria(categoria);
            }
            else if (estacionamentoItem.IsSelected)
            {
                categoria = "Estacionamento";
                dgEstacionamento.ItemsSource = estabelecimentoController.ListarPorCategoria(categoria);
            }
            else if (farmaciaItem.IsSelected)
            {
                categoria = "Farmácia";
                dgFarmacia.ItemsSource = estabelecimentoController.ListarPorCategoria(categoria);
            }
            else if (fastfoodItem.IsSelected)
            {
                categoria = "Fast-Food";
                dgFastfood.ItemsSource = estabelecimentoController.ListarPorCategoria(categoria);
            }
            else if (hotelItem.IsSelected)
            {
                categoria = "Hotel";
                dgHotel.ItemsSource = estabelecimentoController.ListarPorCategoria(categoria);
            }
            else if (petshopItem.IsSelected)
            {
                categoria = "Pet-Shop";
                dgPetshop.ItemsSource = estabelecimentoController.ListarPorCategoria(categoria);
            }

        } 

        private void alterarDadosConta_Click(object sender, RoutedEventArgs e)
        {
            configConta configConta = new configConta();
            configConta.Show();
        }

        private void PackIcon_MouseUpBanco(object sender, MouseButtonEventArgs e)
        {
            menuTab.SelectedIndex = bancoItem.TabIndex;
            menuTab.SelectedItem = bancoItem;
            bancoItem.IsSelected = true;
        }

        private void PackIcon_MouseUpDestaques(object sender, MouseButtonEventArgs e)
        {
            menuTab.SelectedIndex = destaquesItem.TabIndex;
            menuTab.SelectedItem = destaquesItem;
            destaquesItem.IsSelected = true;
        }

        private void PackIcon_MouseUpPesquisar(object sender, MouseButtonEventArgs e)
        {
            menuTab.SelectedIndex = pesquisarItem.TabIndex;
            menuTab.SelectedItem = pesquisarItem;
            pesquisarItem.IsSelected = true;
        }

        private void PackIcon_MouseUpEstacionamento(object sender, MouseButtonEventArgs e)
        {
            menuTab.SelectedIndex = estacionamentoItem.TabIndex;
            menuTab.SelectedItem = estacionamentoItem;
            estacionamentoItem.IsSelected = true;
        }

        private void PackIcon_MouseUpFarmacia(object sender, MouseButtonEventArgs e)
        {
            menuTab.SelectedIndex = farmaciaItem.TabIndex;
            menuTab.SelectedItem = farmaciaItem;
            farmaciaItem.IsSelected = true;
        }

        private void PackIcon_MouseUpFastFood(object sender, MouseButtonEventArgs e)
        {
            menuTab.SelectedIndex = farmaciaItem.TabIndex;
            menuTab.SelectedItem = fastfoodItem;
            fastfoodItem.IsSelected = true;
        }

        private void PackIcon_MouseUpHotel(object sender, MouseButtonEventArgs e)
        {
            menuTab.SelectedIndex = hotelItem.TabIndex;
            menuTab.SelectedItem = hotelItem;
            hotelItem.IsSelected = true;
        }

        private void PackIcon_MouseUpPetShop(object sender, MouseButtonEventArgs e)
        {
            menuTab.SelectedIndex = petshopItem.TabIndex;
            menuTab.SelectedItem = petshopItem;
            petshopItem.IsSelected = true;
        }

        private void ButtonPesquisar_Click(object sender, RoutedEventArgs e)
        {
            EstabelecimentoController estabelecimentoController = new EstabelecimentoController();
            string pesquisa = stringPesquisa.Text;
            dgPesquisar.ItemsSource = estabelecimentoController.ListarPorPesquisa(pesquisa);

        }
    }
}
