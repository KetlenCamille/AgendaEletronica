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
    /// Lógica interna para DetalhesEstabelecimento.xaml
    /// </summary>
    public partial class DetalhesEstabelecimento : Window
    {
        public DetalhesEstabelecimento(Estabelecimento estab)
        {
            EnderecoEstabelecimento endEstabelecimento = new EnderecoEstabelecimento();
            EnderecoEstabelecimentoController endEstabController = new EnderecoEstabelecimentoController();
            
            InitializeComponent();

            endEstabelecimento = endEstabController.BuscarPorId(estab.idEndereco);

            logradouro.Text = endEstabelecimento.logradouroEstabelecimento;
            bairro.Text = endEstabelecimento.bairro;
            cidade.Text = endEstabelecimento.cidade;
            uf.Text = endEstabelecimento.uf;

        }

        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
