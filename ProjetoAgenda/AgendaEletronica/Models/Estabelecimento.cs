using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Estabelecimento
    {
        public int idEstabelecimento { get; set; }
        public int idEndereco { get; set; }
        public string cnpjEstabelecimento { get; set; }
        public string nomeFantasia { get; set; }
        public string categoria { get; set; }
        public string telefoneEstabelecimento { get; set; }
        public string websiteEstabelecimento { get; set; }
        public string emailEstabelecimento { get; set; }
    }
}
