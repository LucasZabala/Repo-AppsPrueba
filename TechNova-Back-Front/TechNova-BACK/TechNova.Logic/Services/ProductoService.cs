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
            this._productoRepository = productoRepository;
        }

        public async Task<IEnumerable<Producto>> GetAllProductosAsync()
        {
            return await _productoRepository.GetAllAsync();
        }
        
        public async Task<Producto> GetProductoByIdAsync()
        {
            return await _productoRepository.GetByIdAsync();
        }
    }
}
