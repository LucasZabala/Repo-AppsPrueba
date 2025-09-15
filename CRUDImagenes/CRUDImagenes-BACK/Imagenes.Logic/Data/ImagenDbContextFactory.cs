using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagenes.Logic.Data
{
    public class ImagenDbContextFactory : IDesignTimeDbContextFactory<ImagenDbContext>
    {
        public ImagenDbContext CreateDbContext(string[] args)
        {
            var basePath = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "..",
                        "Imagenes.Api");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ImagenDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ImagenDbContext(optionsBuilder.Options);
        }
    }
}
