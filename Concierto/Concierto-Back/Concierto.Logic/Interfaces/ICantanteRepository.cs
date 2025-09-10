using Concierto.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concierto.Logic.Interfaces
{
    public interface ICantanteRepository
    {
        Task<IEnumerable<Cantante>> GetAllCantantesAsync();
        Task<Cantante> GetByIdCantanteAsync(int id);
        Task AddCantanteAsync(Cantante cantante);
        Task UpdateCantanteAsync(Cantante cantante);
        Task DeleteCantanteAsync(int id);
    }
}
