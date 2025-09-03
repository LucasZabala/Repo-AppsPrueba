using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNova.Logic.Models;

namespace TechNova.Logic.Data
{
    public class TechNovaDbContext : DbContext
    {
        public TechNovaDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Marca> Marcas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Establecer relaciones FK
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.Categoria_Id);

            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Marca)
                .WithMany(m => m.Productos)
                .HasForeignKey(p => p.Marca_Id);

            //Agregar datos por ahora no es necesario
            /*
            modelBuilder.Entity<Marca>().HasData(
                new Marca
                {
                    //Se debe poner Id para los Seeders
                    Id = 1,
                    Nombre = "Samsung",
                }
                );             
             */

        }

    }
}
