using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ClassBackendBotanica
{
    public class Encomenda
    {
        public int Id { get; set; }
        
        
        
        
        public int Quantidade { get; set; }
        public DateTime DataEncomenda { get; set; }
        public int? UtilizadorId { get; set; }
        public int? ArtigoId { get; set; }
        [ValidateNever]
        public Utilizador Utilizador { get; set; }
        [ValidateNever]
        public Artigo Artigo { get; set; }
        
    }
}
