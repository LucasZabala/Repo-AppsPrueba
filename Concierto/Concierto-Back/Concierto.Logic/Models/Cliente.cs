using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Concierto.Logic.Models
{
    public class Cliente : User
    {
        [JsonIgnore]
        public ICollection<Boleto>? Boletos { get; set; }
    }
}
