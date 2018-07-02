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
    /// Lógica interna para AlterarEstabelecimento.xaml
    /// </summary>
    public partial class AlterarEstabelecimento : Window
    {
        private Estabelecimento _est;
        private EnderecoEstabelecimento _endEst;

        public AlterarEstabelecimento()
        {
            InitializeComponent();

            EstabelecimentoController estCtr = new EstabelecimentoController();
            EnderecoEstabelecimentoController endEstCtr = new EnderecoEstabelecimentoController();

            _est = Application.Current.Properties["_user"] as Estabelecimento;
            _endEst = Application.Current.Properties["_user"] as EnderecoEstabelecimento;

            nomeFantasia.Text = _est.nomeFantasia;
            cnpj.Text = _est.cnpjEstabelecimento;
            categoria.Text = _est.categoria;
            telefone.Text = _est.telefoneEstabelecimento;
            website.Text = _est.websiteEstabelecimento;
            //enderecoEstab.Text = _endEst.logradouroEstabelecimento;
            email.Text = _est.emailEstabelecimento;
            senha.Password = _est.senhaE;

            btn_salvarEst.Visibility = Visibility.Collapsed;
            btn_editarEst.Visibility = Visibility.Collapsed;

        }

        private void editar_Click(object sender, RoutedEventArgs e)
        {
            EstabelecimentoController estC = new EstabelecimentoController();

            var estabelecimento = estC.BuscarPorId(_est.idEndereco);

            nomeFantasia.IsEnabled = true;
            cnpj.IsEnabled = true;
            categoria.IsEnabled = true;
            telefone.IsEnabled = true;
            website.IsEnabled = true;
            email.IsEnabled = true;
            senha.IsEnabled = true;

            btn_editarEst.Visibility = Visibility.Collapsed;
            btn_salvarEst.Visibility = Visibility.Visible;
        }

        private void salvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _est.nomeFantasia = nomeFantasia.Text;
                _est.cnpjEstabelecimento = cnpj.Text;
                _est.categoria = categoria.Text;
                _est.telefoneEstabelecimento = telefone.Text;
                _est.websiteEstabelecimento = website.Text;
                _est.emailEstabelecimento = email.Text;
                _est.senhaE = senha.Password;

                EstabelecimentoController estContr = new EstabelecimentoController();

                int resp = estContr.Editar(_est);

                if (resp == 1)
                {
                    MessageBox.Show("Dados alterados com sucesso!");
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

        private void alterarEnderecoEstab_Click(object sender, RoutedEventArgs e)
        {
            AlterarEnderecoEstabelecimento altEnd = new AlterarEnderecoEstabelecimento();
            altEnd.Show();
            this.Close();
        }
    }
}
