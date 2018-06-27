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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Controllers;

namespace WPFView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

       public MainWindow()
        {
            InitializeComponent();
        }

        private void Listar_Click(object sender, RoutedEventArgs e)
        {
            Listar list = new Listar();
            list.Show();
      }

        private void cadastraUsuario(object sender, RoutedEventArgs e)
        {
            CadastroUsuario cadastroUsuario = new CadastroUsuario();
            cadastroUsuario.Show();
        }

        private void cadastraEstabelecimento_Click(object sender, RoutedEventArgs e)
        {
            CadastroEstabelecimento cadastroEstacionamento = new CadastroEstabelecimento();
            cadastroEstacionamento.Show();
            
        }

        private void login(object sender, RoutedEventArgs e)
        {
            try
            {
                string emailView = email.Text;
                string senhaView = senha.Password;

                if((bool)usuario.IsChecked)
                {
                    UsuarioController usuController = new UsuarioController();

                    if (usuController.Autenticar(emailView, senhaView))
                    {
                        Home home = new Home();
                        home.Show();
                    }
                    else
                    {
                        MessageBox.Show("E-mail e/ou senha inválidos!");
                    }
                }

                else if((bool)estabelecimento.IsChecked)
                {
                    EstabelecimentoController estController = new EstabelecimentoController();

                    if (estController.Autenticar(emailView, senhaView))
                    {
                        Home home = new Home();
                        home.Show();
                    }
                    else
                    {
                        MessageBox.Show("E-mail e/ou senha inválidos!");
                    }
                }
                else
                {
                    MessageBox.Show("Selecione uma das opções de login!");
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex);
            }
        }
    }
}
