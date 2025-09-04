using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNova.Logic.Models;

namespace TechNova.Logic.Interfaces
{
    public interface IProductoService
    {
        Task<IEnumerable<Producto>> GetAllProductosAsync();
        Task<Producto> GetProductoByIdAsync(int id);
        Task AddProductoAsync(Producto producto);
        Task UpdateProductoAsync(Producto producto);
        Task DeleteProductoAsync(int id);

    }
}
