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
            cadastrarEstab_btn.Visibility = Visibility.Collapsed;
        }

        private void cadastrarEstab_Click(object sender, RoutedEventArgs e)
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

        private void LimparNomeF(object sender, MouseEventArgs e)
        {
            string campo = nomeFantasia.Text;

            if(campo.Equals("Digite o nome fantasia"))
            {
                nomeFantasia.Clear();
            }
        }

        private void LimparCnpj(object sender, MouseEventArgs e)
        {
            string campo = cnpj.Text;

            if (campo.Equals("Digite o CNPJ"))
            {
                cnpj.Clear();
            }
        }

        private void LimparTel(object sender, MouseEventArgs e)
        {
            string campo = telefone.Text;

            if (campo.Equals("(xx) xxxx-xxxx"))
            {
                telefone.Clear();
            }
        }

        private void LimparWeb(object sender, MouseEventArgs e)
        {
            string campo = website.Text;

            if(campo.Equals("Digite o website"))
            {
                website.Clear();
            }
        }

        private void LimparEmail(object sender, MouseEventArgs e)
        {
            string campo = email.Text;

            if (campo.Equals("Digite seu e-mail"))
            {
                email.Clear();
            }
        }

    }
}
