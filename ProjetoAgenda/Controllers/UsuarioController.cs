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
            return contexto.Usuarios.Find(idUsuario);
        }

        public int Cadastrar(Usuario usuario)
        {
            if(usuario != null)
            {
                contexto.Usuarios.Add(usuario);
                contexto.SaveChanges();
                return 1;
            }
            return 0;
        }

        public void Editar(Usuario usuario)
        {
            contexto.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Excluir(int idUsuario)
        {
            Usuario usuarioExcluir = BuscarPorId(idUsuario);

            if (usuarioExcluir != null)
            {
                contexto.Entry(usuarioExcluir).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();
            }
        }

        public IList<Usuario> ListarTodos()
        {
            return contexto.Usuarios.ToList();
        }

    }
}
