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

        public void Cadastrar(Usuario usuario)
        {
            if(usuario != null)
            {
                contexto.Usuarios.Add(usuario);
                contexto.SaveChanges();
            }
        }

        public void Editar(Usuario usuario)
        {
            contexto.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
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
