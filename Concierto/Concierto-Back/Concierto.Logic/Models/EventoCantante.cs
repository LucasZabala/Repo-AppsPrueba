using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concierto.Logic.Models
{
    [Table("EventoCantante")]
    public class EventoCantante
    {
        public int CantanteId { get; set; }
        public int EventoId { get; set; }
        public Cantante? Cantante { get; set; }
        public Evento? Evento { get; set; }
    }
}
