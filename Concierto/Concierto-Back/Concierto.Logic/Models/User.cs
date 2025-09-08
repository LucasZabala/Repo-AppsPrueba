using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concierto.Logic.Models
{
    [Table("Users")]
    public class User: IdentityUser
    {
        [Required]
        [MaxLength(100)]
        public string NombreyApellido { get; set; }
        [Required]
        [MaxLength(100)]
        public string Identificacion { get; set; }
    }
}
