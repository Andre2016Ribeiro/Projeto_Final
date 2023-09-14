using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClassBackendBotanica;

namespace WebApplicationBackendBotanica.Data
{
    public class WebApplicationBackendBotanicaContext : DbContext
    {
        public WebApplicationBackendBotanicaContext(DbContextOptions<WebApplicationBackendBotanicaContext> options)
           : base(options)
        {
        }

        public DbSet<ClassBackendBotanica.Utilizador> Utilizador { get; set; }

        public DbSet<ClassBackendBotanica.Artigo> Artigo { get; set; }

        public DbSet<ClassBackendBotanica.Categoria> Categorias { get; set; }

        public DbSet<ClassBackendBotanica.Encomenda> Encomenda { get; set; }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Utilizador>().HasData(
               new Utilizador() { Id = 1, Nome = "ze Pintas", Morada=" Rua 11", UserName = "zepin", Pass="a" },
               new Utilizador() { Id = 2, Nome = "Maria Calas Pintas", Morada = " Rua 12", UserName = "macalas", Pass = "a" },
               new Utilizador() { Id = 3, Nome = "Jose oliveira", Morada = " Rua 31", UserName = "zeo", Pass = "a" },
               new Utilizador() { Id = 4, Nome = "jonana souzas", Morada = " Rua 14", UserName = "jasou", Pass = "a" }
               );
            
            modelBuilder.Entity<Artigo>().HasData(
                new Artigo() { Id = 1, Nome = "Orquidias", Preco=0.5, CategoriaId = 1 },
                new Artigo() { Id = 2, Nome = "Margaridas", Preco = 2.5, CategoriaId = 1 },
                new Artigo() { Id = 3, Nome = "Terra do Bosque", Preco = 2.5, CategoriaId = 2 },
                new Artigo() { Id = 4, Nome = "Terra do campo", Preco = 3.5, CategoriaId = 2 }
                );
            
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria() { Id = 1, Nome = "Plantas" },
                new Categoria() { Id = 2, Nome = "Solo" }
                );
           
            modelBuilder.Entity<Encomenda>().HasData(
               new Encomenda() { Id = 1, Quantidade = 50, DataEncomenda= DateTime.Now, UtilizadorId = 1,  ArtigoId = 4 },
               new Encomenda() { Id = 2, Quantidade = 40, DataEncomenda = DateTime.Now, UtilizadorId = 1,  ArtigoId = 1},
               new Encomenda() { Id = 3, Quantidade = 50, DataEncomenda = DateTime.Now, UtilizadorId = 3,  ArtigoId = 2 },
               new Encomenda() { Id = 4, Quantidade = 30, DataEncomenda = DateTime.Now, UtilizadorId = 2,  ArtigoId = 3 }
               );
            
            

            base.OnModelCreating(modelBuilder);
        }





    }
}
