using Imagenes.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagenes.Logic.Interface
{
    public interface IObjetoRepository
    {
        Task<IEnumerable<Objeto>> GetAllObjetosAsync();
        Task<Objeto> GetByIdObjetoAsync(int id);
        Task AddObjetoAsync(Objeto objeto);
        Task UpdateObjetoAsync(Objeto objeto);
        Task DeleteObjetoAsync(int id);
    }
}
