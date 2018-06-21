using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class EnderecoEstabelecimento
    {
        [Key]
        public int idEndereco { get; set; }

        [Required]
        public string logradouroEstabelecimento { get; set; }

        [Required]
        public int numero { get; set; }

        [Required]
        public string bairro { get; set; }

        [Required]
        public string cidade { get; set; }

        [Required]
        public string uf { get; set; }

    }
}
