using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Base
{
    interface IBaseController<T> where T : class
    {
        void Cadastrar(T entity);

        IList<T> ListarTodos();

        T BuscarPorId(int id);

        void Editar(T entity);

        void Excluir(int id);
    }
}
