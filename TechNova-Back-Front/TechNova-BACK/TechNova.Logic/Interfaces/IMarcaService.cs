using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNova.Logic.Models;

namespace TechNova.Logic.Interfaces
{
    public interface IMarcaService
    {
        Task<IEnumerable<Marca>> GetAllMarcasAsync();
        Task<Marca> GetMarcaByIdAsync(int id);
        Task AddMarcaAsync(Marca marca);
        Task UpdateMarcaAsync(Marca marca);
        Task DeleteMarcaAsync(int id);
    }
}
