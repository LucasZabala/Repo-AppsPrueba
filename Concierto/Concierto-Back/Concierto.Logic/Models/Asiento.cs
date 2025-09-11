using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
    [Table("Asiento")]
    public class Asiento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int NumAsiento { get; set; }
        [Required]
        public bool Estado { get; set; } //Libre(1) o Ocupado(0)
        [Required]
        public int LugarId { get; set; }
        public Lugar? Lugar { get; set; }
        public ICollection<Boleto>? Boletos { get; set; }
    }
}
