using Controllers.Base;
using Controllers.DAO;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class EstabelecimentoController : IBaseController<Estabelecimento>
    {
        Contexto contexto = new Contexto();

        public Estabelecimento BuscarPorId(int idEstabelecimento)
        {
            return contexto.Estabelecimentos.Find(idEstabelecimento);
        }

        public int Cadastrar(Estabelecimento estabelecimento)
        {
            if(estabelecimento == null)
            {
                contexto.Estabelecimentos.Add(estabelecimento);
                contexto.SaveChanges();
                return 1;
            }
            return 0;
        }

        public void Editar(Estabelecimento estabelecimento)
        {
            contexto.Entry(estabelecimento).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Excluir(int idEstabelecimento)
        {
            Estabelecimento estabelecimentoExcluir = BuscarPorId(idEstabelecimento);

            if(estabelecimentoExcluir != null)
            {
                contexto.Entry(estabelecimentoExcluir).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();
            }
        }

        public IList<Estabelecimento> ListarTodos()
        {
            return contexto.Estabelecimentos.ToList();
        }

        public IList<Estabelecimento> ListarPorNome(string nomeEstabelecimento)
        {
            return contexto.Estabelecimentos.Where(a => a.nomeFantasia.ToLower() == nomeEstabelecimento.ToLower()).ToList();
        }

        public IList<Estabelecimento> ListarPorCategoria(string categoriaE)
        {
            return contexto.Estabelecimentos.Where(a => a.categoria.ToLower() == categoriaE.ToLower()).ToList();
        }
    }
}
