using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TechNova.Logic.Models
{

    public class Producto
    {
        [Key]
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column("Nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(200)]
        [Column("Descripcion")]
        public string? Descripcion { get; set; }
        [Required]
        [Range(0, 999999.99)]
        [Column("Precio", TypeName = "decimal(8,2)")]
        public decimal Precio {  get; set; }
        [FileExtensions(Extensions = "jpg,png")]
        [Column("UrlIMG")]
        public string ImagenProducto { get; set; }
        [Required]
        public int Categoria_Id { get; set; }
        [Required]
        public int Marca_Id { get; set; }
        [JsonIgnore]
        public Categoria? Categoria { get; set; }
        [JsonIgnore]
        public Marca? Marca { get; set; }
        
    }
}
