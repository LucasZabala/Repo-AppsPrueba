using Microsoft.EntityFrameworkCore;
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
        [MaxLength(50)]
        public string Tipo { get; set; }
        [Required]
        [Column(TypeName = "Decimal")]
        [Precision(18, 2)]
        public decimal Precio { get; set; }
        [Required]
        [StringLength(50)]
        public string Estado { get; set; }
        
        public Boleto Boleto { get; set; }
    }
}
