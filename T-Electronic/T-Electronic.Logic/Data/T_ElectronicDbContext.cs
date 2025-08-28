using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T_Electronic.Logic.Models;

namespace T_Electronic.Logic.Data
{
    public class T_ElectronicDbContext : DbContext
    {
        public T_ElectronicDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.Categoria_Id);           

        }
    }
}


/*
 modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nombre = "Computadoras" },
                new Categoria { Id = 2, Nombre = "Telefonos" },
                new Categoria { Id = 3, Nombre = "Televisor" }
            );

            modelBuilder.Entity<Producto>().HasData(
                new Producto
                {
                    Id = 1,
                    Nombre = "Notebook ASUS TUF Gaming",
                    Descripcion = "La notebook Asus TUF Gaming F15 ofrece una experiencia visual excepcional con su pantalla de 15,6 pulgadas y resolución FHD (1920 x 1080), que proporciona imágenes nítidas y colores vibrantes.",
                    Precio = 200000,
                    Categoria_Id = 1
                },
                new Producto
                {
                    Id = 2,
                    Nombre = "Apple iPhone 16 128GB Teal",
                    Descripcion = "Chip A18 potencia funcionalidades de foto y video, lo hace todo con una eficiencia energética excepcional para extender la duración de la batería. Botón control de cámara, toma la foto perfecta con sólo levantar un dedo. Nueva cámara ultra gran angular.",
                    Precio = 623000,
                    Categoria_Id = 2
                },
                new Producto
                {
                    Id = 3,
                    Nombre = "Lenovo LOQ Gen 9 (15\" Intel) GeForce RTX™ 2050 ",
                    Descripcion = "Mediante sus entradas HDMI, con la TV Samsung Smart 55 pulgadas podés conectar reproductores de audio y video; consolas de juegos y notebooks",

                    Precio = 10000,
                    Categoria_Id = 3
                }
            );
 */
