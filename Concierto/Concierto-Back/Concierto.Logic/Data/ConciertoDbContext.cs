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
        //Tables
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Empleado> Empleados {  get; set; }
        public DbSet<Lugar> Lugares { get; set; }
        public DbSet<Asiento> Asientos { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Cantante> Cantantes {  get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Boleto> Boletos { get; set; }
        //Tablas Union
        public DbSet<EventoCantante> EventoCantantes { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // IMPORTANTE: llamar al método de la clase base

            //Asiento: Tiene un Lugar
            modelBuilder.Entity<Asiento>()
                .HasOne(a => a.Lugar)
                .WithMany(l => l.Asientos)
                .HasForeignKey(a => a.LugarId);

            //Evento: Tiene un Lugar
            modelBuilder.Entity<Evento>()
                .HasOne(e => e.Lugar)
                .WithMany(l => l.Eventos)
                .HasForeignKey(e => e.LugarId);

            //Eventos: Tienen Muchos Cantantes
            modelBuilder.Entity<EventoCantante>()
                .HasKey(ec => new { ec.EventoId, ec.CantanteId });
            modelBuilder.Entity<EventoCantante>()
                .HasOne(ec => ec.Evento)
                .WithMany(e => e.EventoCantantes)
                .HasForeignKey(ec => ec.EventoId);
            modelBuilder.Entity<EventoCantante>()
                .HasOne(ec => ec.Cantante)
                .WithMany(c => c.EventosCantante)
                .HasForeignKey(ec => ec.CantanteId);
            

        }

    }
}
