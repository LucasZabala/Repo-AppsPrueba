using Microsoft.EntityFrameworkCore;
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
        [MaxLength(100)]
        public string NombreyApellido { get; set; }
        [Required]
        [Unicode]
        [StringLength(50)]
        public string Code { get; set; }
        [Required]
        public bool Estado { get; set; }
        [Required]
        [Column(TypeName = "Decimal")]
        [Precision(18, 2)]
        public decimal Precio { get; set; }
        [Required]
        public DateTime FechaHoraCompra { get; set; }
        [Required]
        public int ClienteId { get; set; }
        [Required]
        public int EventoId { get; set; }
        [Required]
        public int AsientoId { get; set; }
        public Cliente? Cliente { get; set; }
        public Evento? Evento { get; set; }        
        public Asiento? Asiento { get; set; }

    }
}
