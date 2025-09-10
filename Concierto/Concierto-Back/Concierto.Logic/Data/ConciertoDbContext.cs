using Concierto.Logic.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concierto.Logic.Data
{
    public class ConciertoDbContext : IdentityDbContext<User>
    {
        public ConciertoDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Empleado> Empleados {  get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Lugar> Lugares { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Cantante> Cantantes {  get; set; }
        public DbSet<Boleto> Boletos { get; set; }
        public DbSet<Asiento> Asientos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // IMPORTANTE: llamar al método de la clase base
            //Administrador: Administra, Crea, Elimina, Modifica,
            modelBuilder.Entity<Administrador>()
                .HasMany(a => a.Eventos)
                .WithOne(e => e.Administrador)
                .IsRequired();

            //Cliente: Tiene Eventos
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Eventos)
                .WithMany(e => e.Clientes);

            //Cliente tiene varios boletos
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Boletos)
                .WithOne(b => b.Cliente)
                .IsRequired();
            
            //Evento: 
            
        }

    }
}


/*
 // Relación uno a muchos: un administrador puede crear muchos eventos
            modelBuilder.Entity<Administrador>()
                .HasMany(a => a.Eventos)
                .WithOne(e => e.Administrador)
                .IsRequired(false); // Un evento puede no tener un administrador asociado si se borra

            // Relación uno a muchos: un cliente puede tener muchos boletos
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Boletos)
                .WithOne(b => b.Cliente)
                .HasForeignKey(b => b.ClienteId)
                .IsRequired();

            // Relación uno a muchos: un empleado puede vender muchos boletos
            modelBuilder.Entity<Empleado>()
                .HasMany(e => e.Boletos)
                .WithOne(b => b.Empleado)
                .HasForeignKey(b => b.EmpleadoId)
                .IsRequired(false); // Un boleto puede no tener un empleado asociado

            // Relación uno a uno: un boleto tiene un asiento específico
            modelBuilder.Entity<Boleto>()
                .HasOne(b => b.Asiento)
                .WithOne(a => a.Boleto)
                .HasForeignKey<Boleto>(b => b.AsientoId);

            // Relación uno a muchos: un evento tiene muchos boletos
            modelBuilder.Entity<Evento>()
                .HasMany(e => e.BoletosVendidos)
                .WithOne(b=>b.Evento)
                .HasForeignKey(b=>b.EventoId)
                .IsRequired();
 
 */