using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        [Required, StringLength(70)]
        public string NomeUsuario { get; set; }

        public string  cpfUsuario { get; set; }

        public DateTime dataNascimentoUsuario { get; set; }

        public string telefoneUsuario { get; set; }

        [Required, StringLength(150)]
        public string emailUsuario { get; set; }

        [Required, StringLength(15)]
        public string senhaUsuario { get; set; }
    }
}
