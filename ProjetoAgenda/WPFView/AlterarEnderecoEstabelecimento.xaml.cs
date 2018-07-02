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
    /// Lógica interna para AlterarEnderecoEstabelecimento.xaml
    /// </summary>
    public partial class AlterarEnderecoEstabelecimento : Window
    {
        private Estabelecimento _est;
        private EnderecoEstabelecimento _endEst;

        public AlterarEnderecoEstabelecimento()
        {
            InitializeComponent();

            EstabelecimentoController estCtr = new EstabelecimentoController();
            EnderecoEstabelecimentoController endEstCtr = new EnderecoEstabelecimentoController();

            _est = Application.Current.Properties["_user"] as Estabelecimento;
            //_endEst = Application.Current.Properties["_user"] as EnderecoEstabelecimento;


            int idEnd = _est.idEndereco;

            _endEst = endEstCtr.BuscarPorId(idEnd);

            logradouro.Text = _endEst.logradouroEstabelecimento;
            numero.Text = _endEst.numero;
            bairro.Text = _endEst.bairro;
            cidade.Text = _endEst.cidade;
            uf.Text = _endEst.uf;

            btn_salvarEnd.Visibility = Visibility.Collapsed;
            btn_editarEnd.Visibility = Visibility.Visible;

        }

        private void editar_Click(object sender, RoutedEventArgs e)
        {
            EnderecoEstabelecimentoController endEstC = new EnderecoEstabelecimentoController();

            var endEstabelecimento = endEstC.BuscarPorId(_est.idEndereco);

            logradouro.IsEnabled = true;
            numero.IsEnabled = true;
            bairro.IsEnabled = true;
            cidade.IsEnabled = true;
            uf.IsEnabled = true;

            btn_editarEnd.Visibility = Visibility.Collapsed;
            btn_salvarEnd.Visibility = Visibility.Visible;
        }

        private void salvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _endEst.logradouroEstabelecimento = logradouro.Text;
                _endEst.numero = numero.Text;
                _endEst.bairro = bairro.Text;
                _endEst.cidade = cidade.Text;
                _endEst.uf = uf.Text;

                EnderecoEstabelecimentoController endEstContr = new EnderecoEstabelecimentoController();

                int resp = endEstContr.Editar(_endEst);

                if (resp == 1)
                {
                    MessageBox.Show("Dados alterados com sucesso!");
                }
                else if (resp == 0)
                {
                    MessageBox.Show("Houston, temos um problema!");
                }

                this.Close();

                this.Close();

                AlterarEstabelecimento altEst = new AlterarEstabelecimento();
                altEst.btn_desativar.Visibility = Visibility.Collapsed;
                altEst.btn_ativar.Visibility = Visibility.Collapsed;
                altEst.btn_editarEst.Visibility = Visibility.Visible;
                altEst.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ligue para o suporte: " + ex);

            }
        }

    }
}
