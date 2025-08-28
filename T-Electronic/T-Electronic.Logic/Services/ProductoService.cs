using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T_Electronic.Logic.Interfaces;
using T_Electronic.Logic.Models;

namespace T_Electronic.Logic.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        // Inyecta el repositorio a través del constructor
        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        // Implementa los métodos usando el repositorio
        public async Task<IEnumerable<Producto>> GetAllProductosAsync()
        {
            return await _productoRepository.GetAllAsync();
        }

        public async Task<Producto> GetProductoByIdAsync(int id)
        {
            return await _productoRepository.GetByIdAsync(id);
        }

        public async Task AddProductoAsync(Producto producto)
        {
            await _productoRepository.AddAsync(producto);
        }

        public async Task UpdateProductoAsync(Producto producto)
        {
            await _productoRepository.UpdateAsync(producto);
        }

        public async Task DeleteProductoAsync(int id)
        {
            await _productoRepository.DeleteAsync(id);
        }
    }
}
