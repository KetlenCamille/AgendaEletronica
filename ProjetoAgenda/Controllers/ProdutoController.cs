using Controllers.Base;
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
        public Produto BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Produto produto)
        {
            throw new NotImplementedException();
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
