using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concierto.Logic.Models
{
    [Table("Cantantes")]
    public class Cantante
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? NombreArtistico { get; set; }

        public ICollection<EventoCantante>? EventosCantante { get; set; }


    }
}
