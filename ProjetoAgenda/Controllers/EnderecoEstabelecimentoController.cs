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
    public class EnderecoEstabelecimentoController :IBaseController<EnderecoEstabelecimento>
    {
        Contexto contexto = new Contexto();

        public EnderecoEstabelecimento BuscarPorId(int idEndereco)
        {
            return contexto.EnderecoEstabelecimentos.Find(idEndereco);
        }

        public void Cadastrar(EnderecoEstabelecimento enderecoestabelecimento)
        {
            if(enderecoestabelecimento == null)
            {
                contexto.EnderecoEstabelecimentos.Add(enderecoestabelecimento);
                contexto.SaveChanges();
            }
        }

        public void Editar(EnderecoEstabelecimento enderecoestabelecimento)
        {
            contexto.Entry(enderecoestabelecimento).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Excluir(int idEndereco)
        {
            EnderecoEstabelecimento enderecoExcluir = BuscarPorId(idEndereco);

            if(enderecoExcluir != null)
            {
                contexto.Entry(enderecoExcluir).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();
            }
        }

        public IList<EnderecoEstabelecimento> ListarTodos()
        {
            return contexto.EnderecoEstabelecimentos.ToList();
        }

    }
}
