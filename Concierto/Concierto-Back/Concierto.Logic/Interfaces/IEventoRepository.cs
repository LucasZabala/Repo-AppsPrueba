using Concierto.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concierto.Logic.Interfaces
{
    public interface IEventoRepository
    {
        Task<IEnumerable<Evento>> GetAllEventosAsync();
        Task<Evento> GetByIdEventoAsync(int id);
        Task AddEventoAsync(Evento evento);
        Task UpdateEventoAsync(Evento evento);
        Task DeleteEventoAsync(int id);
    }
}
