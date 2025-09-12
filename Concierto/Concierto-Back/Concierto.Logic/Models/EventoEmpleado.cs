using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concierto.Logic.Models
{
    [Table("EventoEmpleado")]
    public class EventoEmpleado
    {
        public int EventoId {  get; set; }
        public int EmpleadoId { get; set; }
        public Evento? Evento { get; set; }
        public Empleado? Empleado { get; set; }
    }
}
