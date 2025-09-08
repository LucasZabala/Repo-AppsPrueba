using Microsoft.VisualBasic;
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
    [Table("Boletos")]
    public class Boleto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Code { get; set; }
        [Required]
        [StringLength(50)]
        public string Estado { get; set; }
        [Required]
        public DateTime FechaCompra { get; set; }
        public string ClienteId { get; set; }
        [JsonIgnore]
        public Cliente Cliente { get; set; }
        public string EmpleadoId { get; set; }
        [JsonIgnore]
        public Empleado Empleado { get; set; }
        public Asiento Asiento { get; set; }

    }
}
