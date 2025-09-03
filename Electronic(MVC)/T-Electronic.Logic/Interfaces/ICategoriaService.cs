using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T_Electronic.Logic.Models;

namespace T_Electronic.Logic.Interfaces
{
    public interface ICategoriaService
    {

        Task<IEnumerable<Categoria>> GetAllCategoriasAsync();
        Task<Categoria> GetCategoriaByIdAsync(int id);
        Task AddCategoriaAsync(Categoria producto);
        Task UpdateCategoriaAsync(Categoria producto);
        Task DeleteCategoriaAsync(int id);

    }
}
