using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Base;
using Controllers.DAO;
using Models;

namespace Controllers
{
    public class UsuarioController : IBaseController<Usuario>
    {
        Contexto contexto = new Contexto();

        public Usuario BuscarPorId(int idUsuario)
        {
            return contexto.Produtos.Find(idUsuario);
        }

        public void Cadastrar(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public void Editar(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Usuario> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
