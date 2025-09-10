using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concierto.Logic.Models
{
    [Table("Administradores")]
    public class Administrador : User
    {
        [Required]
        [MaxLength(100)]
        public string NroAdministrador { get; set; }

        public ICollection<Evento>? Eventos { get; set; } //Eventos que agrego
    }
}
