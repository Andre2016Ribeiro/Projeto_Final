using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace ClassBackendBotanica
{
    public class Utilizador
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Morada { get; set; }

        public string UserName { get; set; }
        public string Pass { get; set; }
        [ValidateNever]
        public ICollection<Encomenda> Encomendas { get; set; }


    }
}