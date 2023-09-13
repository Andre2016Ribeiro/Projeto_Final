﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBackendBotanica
{
    public class Artigo
    {
        public int Id { get; set; }
        
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int? CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public ICollection<Encomenda> Encomendas { get; set; }
    }
}
