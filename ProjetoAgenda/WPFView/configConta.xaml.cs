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
    /// Interaction logic for configConta.xaml
    /// </summary>
    public partial class configConta : Window
    {
        public configConta()
        {
            InitializeComponent();
            var usuario = Application.Current.Properties["_user"] as Usuario;

            nomeUsuario.Text = usuario.NomeUsuario;
            cpfUsuario.Text = usuario.cpfUsuario;
            datanascUsuario.SelectedDate = usuario.dataNascimentoUsuario;
            telefone.Text = usuario.telefoneUsuario;
            emailUsuario.Text = usuario.emailUsuario;
            senhaUsuario.Password = usuario.senhaUsuario;


        }

        public void dadosUser(Usuario _user)
        {
            
        }

    }
}
