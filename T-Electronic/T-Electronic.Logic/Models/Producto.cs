using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T_Electronic.Logic.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(200)]
        public string Descripcion {  get; set; }
        [Range(0, 5000000)]
        public decimal Precio { get; set; }
        public int Categoria_ID { get; set; }

        [ForeignKey("Categoria_Id")]
        public Categoria Categoria { get; set; }
    }
}
