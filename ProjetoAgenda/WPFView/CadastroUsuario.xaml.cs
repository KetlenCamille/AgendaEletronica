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
    /// Interaction logic for CadastroUsuario.xaml
    /// </summary>
    public partial class CadastroUsuario : Window
    {
        static string erro;
        public CadastroUsuario()
        {
            InitializeComponent();
        }

        private void buttonCadastrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Usuario usuarioView = new Usuario();

                usuarioView.NomeUsuario = nomeUsuario.Text;
                usuarioView.cpfUsuario = cpfUsuario.Text;
                usuarioView.dataNascimentoUsuario = datanascUsuario.SelectedDate.Value;
                usuarioView.telefoneUsuario = telefone.Text;
                usuarioView.emailUsuario = emailUsuario.Text;
                usuarioView.senhaUsuario = senhaUsuario.Password;

                if(validacoes(usuarioView))
                {
                    UsuarioController usuContr = new UsuarioController();
                    int resp = usuContr.Cadastrar(usuarioView);

                    if (resp == 1)
                    {
                        MessageBox.Show("Cadastrado com Sucesso!");
                    }
                    else if (resp == 0)
                    {
                        MessageBox.Show("Houston, temos um problema!");
                    }

                    this.Close();
                   /* MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();*/
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Não pode ter campos nulos");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ligue para o suporte: " + ex);
            }
           
        }

        private void LimparNome (object sender, RoutedEventArgs e)
        {
            string campo = nomeUsuario.Text;

            if (campo.Equals("Digite seu nome"))
            {
                nomeUsuario.Clear();
            }
        }

        private void LimparCpf(object sender, MouseEventArgs e)
        {
            string campo = cpfUsuario.Text;

            if (campo.Equals("Digite seu CPF"))
            {
                cpfUsuario.Clear();
            }
        }

        private void LimparTelefone(object sender, MouseEventArgs e)
        {
            string campo = telefone.Text;

            if (campo.Equals("(xx) xxxx-xxxx"))
            {
                telefone.Clear();
            }
        }

        private void LimparEmail(object sender, MouseEventArgs e)
        {
            string campo = emailUsuario.Text;

            if(campo.Equals("Digite seu e-mail"))
            {
                emailUsuario.Clear();
            }
        }

        private bool validacoes(Usuario usuario)
        {
            if(usuario.NomeUsuario == "" || usuario.dataNascimentoUsuario == null || usuario.telefoneUsuario == "" || usuario.emailUsuario == ""|| usuario.senhaUsuario == "")
            {
                erro = "Não pode conter campos em branco.";
            }
            else if(usuario.NomeUsuario.Length < 5)
            {
                erro = " Quantidade de caracteres inválida no Nome.";
            }
            /*else if(usuario.telefoneUsuario.Length != 10 || usuario.telefoneUsuario.Length != 11)
            {
                erro = " Telefone inválido."; 
            }*/
            else if(!usuario.emailUsuario.Contains('@'))
            {
                erro = " E-mail inválido.";
            }
            else if(usuario.senhaUsuario.Length < 8)
            {
                erro = " Senha deve conter no mínimo 8 caracteres.";
            }
            else if(usuario.cpfUsuario.Length != 11 && !validaCpf(usuario.cpfUsuario))
            {
                erro = " CPF inválido.";
            }

            UsuarioController usuController = new UsuarioController();
            foreach (Usuario usu in usuController.ListarTodos())
            {
                if(usu.emailUsuario ==  usuario.emailUsuario)
                {
                    erro = " E-mail já existente!";
                }
            }

            if (erro == null)
            {
                return true;
            }
            else
            {
                MessageBox.Show(erro);
                return false;
            }
        }

        private bool validaCpf(string cpfView)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2, };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string cpf = cpfView;
            string auxCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim(); // Remoção de espaços
            cpf = cpf.Replace(".", "").Replace("-", ""); //Remoção de . e -

            auxCpf = cpf.Substring(0, 9); //Pega os primeiros 9 numeros digitados
            soma = 0;

            for (int i = 0; i < 9; i++)
            {
                //Multiplicando e somando com o vetor
                soma += int.Parse(auxCpf[i].ToString()) * multiplicador1[i];
            }

            resto = soma % 11; //Calculando resto da divisão

            if(resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = resto.ToString(); //Guarda o primeiro digito
            auxCpf = auxCpf + digito; //Passa o valor para a string auxiliar

            soma = 0;

            for (int i = 0; i < 10; i++) //Possui mais um digito
            {
                //Multiplica e soma o valor no segundo vetor
                soma += int.Parse(auxCpf[i].ToString()) * multiplicador2[i];
            }

            resto = soma % 11; //Calculando o reto da divisao
            if(resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            auxCpf = auxCpf + resto; //Passa o último digito

            if(cpf == auxCpf)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
;}
