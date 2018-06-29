using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Estabelecimento
    {
        [Key]
        public int idEstabelecimento { get; set; }

        public int idEndereco { get; set; }

        [Required, StringLength(15)]
        public string cnpjEstabelecimento { get; set; }

        [Required, StringLength(50)]
        public string nomeFantasia { get; set; }

        [Required]
        public string categoria { get; set; }

        [Required, StringLength(15)]
        public string telefoneEstabelecimento { get; set; }

        public string websiteEstabelecimento { get; set; }
        public string emailEstabelecimento { get; set; }

        [Required, MinLength(7)]
        public string senhaE { get; set; }

        public ICollection<Produto> ProdutosPorEstabelecimento { get; set; }
    }
}
