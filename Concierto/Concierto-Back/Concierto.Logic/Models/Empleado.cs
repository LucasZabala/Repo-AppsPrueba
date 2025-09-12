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
    [Table("Empleados")]
    public class Empleado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Nombre { get; set; }
        [Required]
        [Length(4, 10)]
        public string Pass { get; set; }
        [Required]
        public ICollection<EventoEmpleado>? EventosEmpleado { get; set; }
        
    }
}
