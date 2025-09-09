using Concierto.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concierto.Logic.Interfaces
{
    public interface IAsientoRepository
    {
        Task<IEnumerable<Asiento>> GetAllAsientosAsync();
        Task<Asiento> GetByIdAsientoAsync(int id);
        Task AddAsientoAsync(Asiento asiento);
        Task UpdateAsientoAsync(Asiento asiento);
        Task DeleteAsientoAsync(int id);
    }
}
