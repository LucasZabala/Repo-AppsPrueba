using Imagenes.Logic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagenes.Logic.Data
{
    public class ImagenDbContext : DbContext
    {
        public ImagenDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Objeto> Objetos {  get; set; }
    }
}
