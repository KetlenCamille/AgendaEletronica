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
    public class ProdutoController : IBaseController<Produto>
    {
        Contexto contexto = new Contexto();

        public Produto BuscarPorId(int idProduto)
        {
            return contexto.Produtos.Find(idProduto);
        }

        public void Cadastrar(Produto produto)
        {
            if(produto == null)
            {
                contexto.Produtos.Add(produto);
                contexto.SaveChanges();
            }
        }
    
        public void Editar(Produto entity)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Produto> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
