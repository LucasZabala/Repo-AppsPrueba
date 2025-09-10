using Concierto.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concierto.Logic.Interfaces
{
    public interface ILugarRepository
    {
        Task<IEnumerable<Lugar>> GetAllLugaresAsync();
        Task<Lugar> GetByIdLugarAsync(int id);
        Task AddLugarAsync(Lugar lugar);
        Task UpdateLugarAsync(Lugar lugar);
        Task DeleteLugarAsync(int id);
    }
}
