using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNova.Logic.Data;
using TechNova.Logic.Interfaces;
using TechNova.Logic.Models;

namespace TechNova.Logic.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly TechNovaDbContext _context;
        private readonly IDbConnection _dbConnection;

        public ProductoRepository(TechNovaDbContext context)
        {
            _context = context;
            _dbConnection = _context.Database.GetDbConnection();
        }

        public async Task<IEnumerable<Producto>> GetAllProductosAsync()
        {
            var sql = "SELECT * FROM Productos";
            var productos = await _dbConnection.QueryAsync<Producto>(sql);
            return productos;
        }

        public async Task<Producto> GetProductoByIdAsync(int id)
        {
            var sql = "SELECT * FROM Productos HWERE Id = @id";
            var producto = await _dbConnection.QueryFirstOrDefaultAsync<Producto>(sql, new { id });
            return producto;
        }

        public async Task AddProductoAsync(Producto producto)
        {
            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductoAsync(Producto producto)
        {
            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductoAsync(int id)
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
