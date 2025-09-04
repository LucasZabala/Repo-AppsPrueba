using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNova.Logic.Models;

namespace TechNova.Logic.Interfaces
{
    public interface IMarcaRepository
    {
        Task<IEnumerable<Marca>> GetAllAsync();
        Task<Marca> GetByIdAsync();
        Task AddAsync(Marca marca);
        Task UpdateAsync(Marca marca);
        Task DeleteAsync(int id);
    }
}
