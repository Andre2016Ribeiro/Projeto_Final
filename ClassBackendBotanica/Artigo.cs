using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ClassBackendBotanica
{
    public class Artigo
    {
        public int Id { get; set; }
        
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int? CategoriaId { get; set; }
        
        [ValidateNever]
        public Categoria Categoria { get; set; }

        [ValidateNever]
        public ICollection<Encomenda> Encomendas { get; set; }
    }
}
