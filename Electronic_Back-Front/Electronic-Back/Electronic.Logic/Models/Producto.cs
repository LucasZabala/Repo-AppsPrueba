using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Electronic.Logic.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }
        [MaxLength(200)]
        [JsonPropertyName("descripcion")]
        public string? Descripcion { get; set; }
        [Required]
        [JsonPropertyName("precio")]
        [Range(0, 999999.99)]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Precio { get; set; }
        [Required]
        [JsonPropertyName("categoria_Id")]
        public int Categoria_Id { get; set; }

        [JsonIgnore]
        public Categoria? Categoria { get; set; }
    }
}
