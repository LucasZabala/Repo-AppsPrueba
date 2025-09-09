using Concierto.Logic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concierto.Logic.Data
{
    public class ConciertoDbContext : DbContext
    {
        public ConciertoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Boleto> Boletos { get; set; }
        public DbSet<Asiento> Asientos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                .HasMany(e => e.Boletos)
                .WithOne(b=>b.Evento)
                .HasForeignKey(b=>b.EventoId)
                .IsRequired();
        }

    }
}
