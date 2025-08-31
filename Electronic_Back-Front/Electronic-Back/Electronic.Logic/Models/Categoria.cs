using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization; //Romber bucle serializacion de objetos
using System.Threading.Tasks;

namespace Electronic.Logic.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nombre {  get; set; }

        [JsonIgnore] //Romber bucle serializacion de objetos
        public ICollection<Producto> Productos { get; set; }
    }
}
