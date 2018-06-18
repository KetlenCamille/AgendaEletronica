using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }

        public int idEstabelecimento { get; set; }

        [StringLength(70)]
        public string descricaoProduto { get; set; }

        public bool ativoProduto { get; set; }
    }
}
