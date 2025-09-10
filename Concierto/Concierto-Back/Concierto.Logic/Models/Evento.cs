using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Concierto.Logic.Models
{
    [Table("Eventos")]
    public class Evento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string TituloEvento { get; set; }
        [Required]
        [Column(TypeName = "Data")]
        public DateOnly Fecha { get; set; } // 9/12/2025
        [Required]
        public TimeOnly HoraInicio {  get; set; }
        [Required]
        public TimeOnly HoraFin { get; set; }
        public int Capacidad { get; set; } //Cantidad de boletos y cantidad de asientos
        [Required]
        public int LugarId { get; set; }
        [Required]
        public int AdministradorId { get; set; } // Quiern crea el Evento

        public ICollection<Cantante>? Cantantes { get; set; }//Cantantes que cantan
        public Lugar? Lugar { get; set; }
        public ICollection<Asiento>? Asientos { get; set; } //Todos los Asientos
        public Administrador? Administrador { get; set; } // Quien agrego el evento
        public ICollection<Cliente>? Clientes { get; set; }


    }
}
