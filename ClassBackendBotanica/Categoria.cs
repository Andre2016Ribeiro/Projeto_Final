﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ClassBackendBotanica
{
    public class Categoria
    {
        public int Id { get; set; }

        public string Nome { get; set; }


        [ValidateNever]
        public ICollection<Artigo>? Artigos { get; set; }
    }
}
