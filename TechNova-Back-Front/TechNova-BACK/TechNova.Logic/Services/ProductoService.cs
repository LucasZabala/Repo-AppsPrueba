using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNova.Logic.Interfaces;
using TechNova.Logic.Models;

namespace TechNova.Logic.Services
{
    public class ProductoService: IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<IEnumerable<Producto>> GetAllProductosAsync()
        {
            return await _productoRepository.GetAllProductosAsync();
        }
        
        public async Task<Producto> GetProductoByIdAsync(int id)
        {
            var prodcuto = await  _productoRepository.GetProductoByIdAsync(id);

            if(prodcuto == null)
            {
                throw new InvalidOperationException($"Producto con Id {id} no encontrado.");
            }
            return prodcuto;
        }

        public async Task AddProductoAsync(Producto producto)
        {
            if(producto == null)
            {
                throw new InvalidOperationException("El producto a agregar es nulo.");
            }
            await _productoRepository.AddProductoAsync(producto);
        }

        public async Task UpdateProductoAsync(Producto producto)
        {
            var prodcutoExistente = _productoRepository.GetProductoByIdAsync(producto.Id);
            if(prodcutoExistente == null)
            {
                throw new InvalidOperationException("El producto a actualizar no existe."); ;
            }
            await _productoRepository.UpdateProductoAsync(producto);
        }

        public async Task DeleteProductoAsync(int id)
        {
            await _productoRepository.DeleteProductoAsync(id);
        }
    }
}
