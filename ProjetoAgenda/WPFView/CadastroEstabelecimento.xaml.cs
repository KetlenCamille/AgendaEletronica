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
        static string erro;
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
                estabelecimentoView.ativo = true;

                EstabelecimentoController estacionamentoController = new EstabelecimentoController();
                if(validar(estabelecimentoView))
                {
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

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                }  
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

        private bool validar(Estabelecimento estab)
        {
            if(estab.nomeFantasia.Length < 5)
            {
                erro = "Quantidade de caracteres inválida no nome.";
            }
            else if(estab.cnpjEstabelecimento.Length != 14 && !validaCnpj(estab.cnpjEstabelecimento))
            {
                erro = "CNJPJ inválido.";
            }
            else if(estab.telefoneEstabelecimento.Length != 10 && estab.telefoneEstabelecimento.Length != 11)
            {
                erro = " Telefone inválido";
            }
            else if(!estab.websiteEstabelecimento.Contains(".com"))
            {
                erro = " WebSite inválido.";
            }
            else if (!estab.emailEstabelecimento.Contains('@'))
            {
                erro = " E-mail inválido.";
            }
            else if(estab.senhaE.Length < 8)
            {
                erro = " Senha deve conter no mínimo 8 caracteres.";
            }

            EstabelecimentoController estabController = new EstabelecimentoController();
            

            foreach (Estabelecimento estabelecimento in estabController.ListarTodos())
            {
               if(estabelecimento.emailEstabelecimento == estab.emailEstabelecimento)
                {
                    erro = " E-mail já existente.";
                }
            }

            if(erro == null)
            {
                return true;
            }
            else
            {
                MessageBox.Show(erro);
                return false;
            }
        }

        private bool validaCnpj(string cnpjView)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            string cnpj = cnpjView;
            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "");
            if (cnpj.Length != 14)
                return false;

            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            int resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            if(digito == cnpjView)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
