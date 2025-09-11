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
        public DateOnly Fecha { get; set; } // 2025/12/9
        [Required]
        public TimeOnly HoraInicio { get; set; }
        [Required]
        public TimeOnly HoraFin { get; set; }
        [Required]
        public int LugarId { get; set; }
        public Lugar? Lugar { get; set; }
        public ICollection<EventoCantante>? EventoCantantes { get; set; }
        public ICollection<Empleado>? Empleados { get; set; }
        public ICollection<Boleto>? Boletos { get; set; }
    }
}
