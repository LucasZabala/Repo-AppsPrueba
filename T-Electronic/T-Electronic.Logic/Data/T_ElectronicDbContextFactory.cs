using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T_Electronic.Logic.Data
{
    public class T_ElectronicDbContextFactory : IDesignTimeDbContextFactory<T_ElectronicDbContext>
    {
        public T_ElectronicDbContext CreateDbContext(string[] args)
        {
            // La ruta correcta al directorio raíz de la aplicación web
            var basePath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "..",
                "T-Electronic.Web");

            // Construir la configuración desde appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();

            // Obtener la cadena de conexión de la configuración
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<T_ElectronicDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new T_ElectronicDbContext(optionsBuilder.Options);
        }
    }
}
