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
        //Tables
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Lugar> Lugares { get; set; }
        public DbSet<Asiento> Asientos { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Cantante> Cantantes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Boleto> Boletos { get; set; }
        //Tablas Union
        public DbSet<EventoCantante> EventosCantantes { get; set; }
        public DbSet<EventoEmpleado> EventosEmpleados { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // IMPORTANTE: llamar al método de la clase base            

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

            //Eventos: Tienen muchos empleados
            modelBuilder.Entity<EventoEmpleado>()
                .HasKey(ee => new { ee.EventoId, ee.EmpleadoId });

            modelBuilder.Entity<EventoEmpleado>()
                .HasOne(ee => ee.Evento)
                .WithMany(e => e.EventoEmpleados)
                .HasForeignKey(ee => ee.EventoId);

            modelBuilder.Entity<EventoEmpleado>()
                .HasOne(ee => ee.Empleado)
                .WithMany(e => e.EventosEmpleado)
                .HasForeignKey(ee => ee.EmpleadoId);

            //Boleto: Tiene un Evento
            modelBuilder.Entity<Boleto>()
                .HasOne(b => b.Evento)
                .WithMany(e => e.Boletos)
                .HasForeignKey(b => b.EventoId);
            
            //Boleto: Tiene un Asiento
            modelBuilder.Entity<Boleto>()
                .HasOne(b => b.Asiento)
                .WithMany(a => a.Boletos)
                .HasForeignKey(b => b.AsientoId)
                .OnDelete(DeleteBehavior.NoAction);

            //Boleto: Tiene un Cliente
            modelBuilder.Entity<Boleto>()
                .HasOne(b => b.Cliente)
                .WithMany(c => c.Boletos)
                .HasForeignKey(b => b.ClienteId);


            //Asiento: Tiene un Lugar
            modelBuilder.Entity<Asiento>()
                .HasOne(a => a.Lugar)
                .WithMany(l => l.Asientos)
                .HasForeignKey(a => a.LugarId);

        }
    }
}
