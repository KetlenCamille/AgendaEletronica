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
    /// Interaction logic for CadastroEnderecoEstabelecimento.xaml
    /// </summary>
    public partial class CadastroEnderecoEstabelecimento : Window
    {
        public CadastroEnderecoEstabelecimento()
        {
            InitializeComponent();
        }

        private void Cadastrar_Click(object sender, RoutedEventArgs e)
        {
            CadastroEstabelecimento cadEstab = new CadastroEstabelecimento();
            this.Close();
            try
            {
                EnderecoEstabelecimento enderecoEstView = new EnderecoEstabelecimento();

                enderecoEstView.logradouroEstabelecimento = logradouro.Text;
                enderecoEstView.numero = numero.Text;
                enderecoEstView.bairro = bairro.Text;
                enderecoEstView.cidade = cidade.Text;
                enderecoEstView.uf = uf.Text;

                EnderecoEstabelecimentoController enderecoEstController = new EnderecoEstabelecimentoController();
                int resp = enderecoEstController.Cadastrar(enderecoEstView);

                if(resp == 1)
                {
                    MessageBox.Show("Cadastrado com sucesso!");
                }
                else if(resp == 0)
                {
                    MessageBox.Show("Houston, temos um problema!");
                }

                this.Close();

                CadastroEstabelecimento cadEst = new CadastroEstabelecimento();
                cadEst.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ligue para o suporte: " + ex);
            }
        }
    }
}
