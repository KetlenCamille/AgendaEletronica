using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        public string NomeUsuario { get; set; }

        public string  cpfUsuario { get; set; }

        public DateTime dataNascimentoUsuario { get; set; }

        public string telefoneUsuario { get; set; }

        public string emailUsuario { get; set; }

        public string senhaUsuario { get; set; }
    }
}
