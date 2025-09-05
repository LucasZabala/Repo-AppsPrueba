using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNova.Logic.Data;
using TechNova.Logic.Interfaces;
using TechNova.Logic.Models;

namespace TechNova.Logic.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly TechNovaDbContext _context;
        private readonly IDbConnection _dbConnection;

        public CategoriaRepository(TechNovaDbContext context)
        {
            _context = context;
            _dbConnection = _context.Database.GetDbConnection();
        }

        public async Task<IEnumerable<Categoria>> GetAllCategoriasAsync()
        {
            var sql = "SELECT * FROM Categorias";
            var categorias = await _dbConnection.QueryAsync<Categoria>(sql);
            return categorias;
        }

        public async Task<Categoria> GetCategoriaByIdAsync(int id)
        {
            var sql = "SELECT * FROM Categorias WHERE Id = @id";
            var categoria = await _dbConnection.QueryFirstOrDefaultAsync<Categoria>(sql, new { id });
            return categoria;
        }

        public async Task AddCategoriaAsync(Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategoriaAsync(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoriaAsync(int id)
        {
            var categoria = await this.GetCategoriaByIdAsync(id);
            if (categoria != null)
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
            }

        }

    }
}
