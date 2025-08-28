using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T_Electronic.Logic.Data;
using T_Electronic.Logic.Interfaces;
using T_Electronic.Logic.Models;

namespace T_Electronic.Logic.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly T_ElectronicDbContext _context;

        public ProductoRepository(T_ElectronicDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> GetAllAsync()
        {
            // Incluye la categoría para evitar errores de referencia nula
            return await _context.Productos.Include(p => p.Categoria).ToListAsync();
        }

        public async Task<Producto> GetByIdAsync(int id)
        {
            // Busca un producto por ID y también incluye la categoría
            return await _context.Productos.Include(p => p.Categoria).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Producto producto)
        {
            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Producto producto)
        {
            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }
        }

    }
}
