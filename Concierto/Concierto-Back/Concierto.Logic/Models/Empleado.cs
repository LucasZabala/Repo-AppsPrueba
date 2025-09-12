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
    public class Empleado:User
    {
        [Required]
        [MaxLength(100)]
        public string? NombreEmpleado { get; set; }
        [Required]
        public ICollection<EventoEmpleado>? EventosEmpleado { get; set; }
        
    }
}
