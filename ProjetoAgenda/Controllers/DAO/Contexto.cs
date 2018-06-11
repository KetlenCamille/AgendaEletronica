using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using Models;

namespace Controllers.DAO
{
    class Contexto : DbContext
    {
        public Contexto() : base("strConn")
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Estabelecimento> Estabelecimentos { get; set; }

        public DbSet<EnderecoEstabelecimento> EnderecoEstabelecimentos { get; set; }

        public DbSet<Produto> Produtos { get; set; }
    }
}
