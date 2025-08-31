using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronic.Logic.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [MaxLength(200)]
        public string Descripcion { get; set; }
        [Required]
        [Range(0,01)]
        public decimal Precio { get; set; }
        [Required]
        public int Categoria_Id { get; set; }
        [Required]
        public Categoria Categoria { get; set; }
    }
}
