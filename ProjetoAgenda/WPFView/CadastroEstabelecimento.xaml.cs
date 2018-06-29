using Controllers;
using Models;
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

namespace WPFView
{
    /// <summary>
    /// Interaction logic for CadastroEstabelecimento.xaml
    /// </summary>
    public partial class CadastroEstabelecimento : Window
    {
        public CadastroEstabelecimento()
        {
            EnderecoEstabelecimentoController endestabContro = new EnderecoEstabelecimentoController();

            InitializeComponent();
            enderecoEstab.ItemsSource = endestabContro.ListarTodos();
        }

        private void proximo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Estabelecimento estabelecimentoView = new Estabelecimento();
                estabelecimentoView.idEndereco = int.Parse(enderecoEstab.SelectedValue.ToString());
                estabelecimentoView.nomeFantasia = nomeFantasia.Text;
                estabelecimentoView.cnpjEstabelecimento = cnpj.Text;
                estabelecimentoView.categoria = categoria.Text;
                estabelecimentoView.telefoneEstabelecimento = telefone.Text;
                estabelecimentoView.websiteEstabelecimento = website.Text;
                estabelecimentoView.emailEstabelecimento = email.Text;
                estabelecimentoView.senhaE = senha.Password;

                EstabelecimentoController estacionamentoController = new EstabelecimentoController();
                int resp = estacionamentoController.Cadastrar(estabelecimentoView);

                if (resp == 1)
                {
                    MessageBox.Show("Cadastrado com Sucesso!");
                }
                else if (resp == 0)
                {
                    MessageBox.Show("Houston, temos um problema!");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ligue para o suporte: " + ex);

            } 
        }

        private void button_ClickEndereço(object sender, RoutedEventArgs e)
        {
            CadastroEnderecoEstabelecimento cadEndereco = new CadastroEnderecoEstabelecimento();
            cadEndereco.Show();
            this.Close();
        }
    }
}
