using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Base
{
    interface IBaseController<T> where T : class
    {
        int Cadastrar(T entity);

        IList<T> ListarTodos();

        T BuscarPorId(int id);

        int Editar(T entity);

        void Excluir(int id);
    }
}
