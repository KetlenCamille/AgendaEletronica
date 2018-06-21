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
            Usuario usuarioView = new Usuario();

            usuarioView.NomeUsuario = nomeUsuario.Text;
            usuarioView.cpfUsuario = cpfUsuario.Text;
            usuarioView.dataNascimentoUsuario = datanascUsuario.SelectedDate.Value;
            usuarioView.emailUsuario = emailUsuario.Text;
            usuarioView.senhaUsuario = senhaUsuario.Text;

            UsuarioController usuContr = new UsuarioController();
            int resp = usuContr.Cadastrar(usuarioView);

            if(resp == 1)
            {
                MessageBox.Show("Cadastrado com Sucesso!");
            }
            else if (resp == 0)
            {
                MessageBox.Show("Houston, temos um problema");
            }

            this.Close();
        }
    }
}
