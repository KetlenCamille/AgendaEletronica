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
using Controllers;
using Models;

namespace WPFView
{
    /// <summary>
    /// Lógica interna para AlterarUsuario.xaml
    /// </summary>
    public partial class AlterarUsuario : Window
    {
        public AlterarUsuario()
        {
            InitializeComponent();
            UsuarioController usuC = new UsuarioController();

            var usu = Application.Current.Properties["_user"] as Usuario;

            var usuario = usuC.BuscarPorId(usu.IdUsuario);

            nomeUsuario.Text = usuario.NomeUsuario;
            cpfUsuario.Text = usuario.cpfUsuario;
            datanascUsuario.SelectedDate = usuario.dataNascimentoUsuario;
            telefone.Text = usuario.telefoneUsuario;
            emailUsuario.Text = usuario.emailUsuario;
            senhaUsuario.Password = usuario.senhaUsuario;

            btn_salvar.Visibility = Visibility.Collapsed;
        }

        private void editar_Click(object sender, RoutedEventArgs e)
        {
            UsuarioController usuC = new UsuarioController();

            var usu = Application.Current.Properties["_user"] as Usuario;

            var usuario = usuC.BuscarPorId(usu.IdUsuario);

            nomeUsuario.IsEnabled = true;
            cpfUsuario.IsEnabled = true;
            datanascUsuario.IsEnabled = true;
            telefone.IsEnabled = true;
            emailUsuario.IsEnabled = true;
            senhaUsuario.IsEnabled = true;

            btn_editar.Visibility = Visibility.Collapsed;
            btn_salvar.Visibility = Visibility.Visible;
        }

        private void salvar_Click(object sender, RoutedEventArgs e)
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
                int resp = usuContr.Editar(usuarioView);

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
    }
}

