using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concierto.Logic.Models
{
    [Table("Direcciones")]
    public class Lugar
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Unicode]
        [MaxLength(100)]
        public string Nombre { get; set; }
        [Required]
        [Unicode]
        [MaxLength(500)]
        public string Direccion { get; set; }

        public ICollection<Evento>? Eventos { get; set; } //cantodad de Eventos que hay 
    }
}
