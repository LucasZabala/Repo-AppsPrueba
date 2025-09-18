using AuthApp.Logic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Logic.Data
{

    public class AuthAppDbContext : IdentityDbContext<User, Role, string>
    {
        public AuthAppDbContext(DbContextOptions<AuthAppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // 1. Seeding de roles: Agregamos los datos iniciales.
            builder.Entity<Role>().HasData(
                new Role { Id = "6a40a232-0947-4959-b1ff-97a151044454", Name = "Administrador", NormalizedName = "ADMINISTRADOR" },
                new Role { Id = "1e8df1d6-8b2b-47e1-8f55-1b4e05b9c054", Name = "Empleado", NormalizedName = "EMPLEADO" },
                new Role { Id = "5c5240e1-7e87-410a-8d76-d98c25732152", Name = "Cliente", NormalizedName = "CLIENTE" }
            );
            
        }
    }
}







/*
// 2. Seeding de usuarios: Creamos un usuario de ejemplo.
            var user = new User
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "Luky22",
                NormalizedUserName = "LUKY22",
                Email = "Luky22@gmail.com",
                NormalizedEmail = "LUKY22@GMAIL.COM",
                EmailConfirmed = true,
                FirstName = "Lucas",
                LastName = "Zabala",
                // requiere que todos los valores sean estáticos y constantes para que el modelo de la base de datos no cambie 
                //SecurityStamp = Guid.NewGuid().ToString("D")
                // GUID estático para el sello de seguridad.
                SecurityStamp = "f60f6456-f56f-4424-8b01-a75d5f2a1a8c",
                // Hash estático para la contraseña
                PasswordHash = "AQAAAAIAAYagAAAAEPJ6gA0m+dG5L5N6j8Zp5q/l0E/J8gX3bS3/hK7Jq7/k2jNl9YnJgU6L6h8f2Jp2Q=="
            };

            // Creamos un hasher para la contraseña.
            var hasher = new PasswordHasher<User>();
            user.PasswordHash = hasher.HashPassword(user, "Admin123!");

            // Agregamos el usuario a la base de datos.
            builder.Entity<User>().HasData(user);

            // 3. Asignación de roles al usuario: Agregamos el rol 'Admin'.
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "6a40a232-0947-4959-b1ff-97a151044454",
                    UserId = user.Id
                }
            );
 */