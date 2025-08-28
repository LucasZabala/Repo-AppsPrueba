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

        [StringLength(500)]
        public string Descripcion {  get; set; }

        public decimal Precio { get; set; }
        public int Categoria_Id { get; set; }

        [ForeignKey("Categoria_Id")]
        public Categoria Categoria { get; set; }
    }
}
