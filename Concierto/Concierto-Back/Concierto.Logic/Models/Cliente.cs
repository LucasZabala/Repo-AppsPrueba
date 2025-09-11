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
    [Table("Clientes")]
    public class Cliente : User
    {
        [Required]
        [MaxLength(50)]
        public string NombreUsuario { get; set; }
        public ICollection<Boleto>? Boletos { get; set; } //Boletos que Compro
    }
}
