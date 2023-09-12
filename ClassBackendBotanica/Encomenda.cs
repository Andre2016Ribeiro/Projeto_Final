using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBackendBotanica
{
    public class Encomenda
    {
        public int Id { get; set; }
        
        
        
        
        public int Quantidade { get; set; }
        public DateTime DataEncomenda { get; set; }
        public int? UtilizadorId { get; set; }
        public int? ArtigoId { get; set; }
        public Utilizador Utilizador { get; set; }
        public Artigo Artigo { get; set; }
        
    }
}
