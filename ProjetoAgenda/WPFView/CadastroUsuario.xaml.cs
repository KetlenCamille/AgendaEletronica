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
    }
}
