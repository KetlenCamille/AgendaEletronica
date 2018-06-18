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
            //Apaga e recria a base de dados se houver a mudança nas modelos
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Contexto>());
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Estabelecimento> Estabelecimentos { get; set; }

        public DbSet<EnderecoEstabelecimento> EnderecoEstabelecimentos { get; set; }

        public DbSet<Produto> Produtos { get; set; }
    }
}
