using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagenes.Logic.Models
{
    [Table("Objetos")]
    public class Objeto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Titulo { get; set; }
        [MaxLength(100)]
        public string Descripcion { get; set; }
        [Required]
        [MaxLength(50)]
        public string URLImg { get; set; }
    }
}
