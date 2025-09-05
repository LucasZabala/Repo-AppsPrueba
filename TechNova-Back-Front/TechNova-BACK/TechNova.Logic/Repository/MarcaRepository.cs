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
    public class MarcaRepository:IMarcaRepository
    {
        private readonly TechNovaDbContext _context;
        private readonly IDbConnection _dbConnection;

        public MarcaRepository(TechNovaDbContext context)
        {
            _context = context;
            _dbConnection = _context.Database.GetDbConnection();
        }

        public async Task<IEnumerable<Marca>> GetAllMarcasAsync()
        {
            var sql = "SELECT * FROM Marcas";
            var marcas = await _dbConnection.QueryAsync<Marca>(sql);
            return marcas;
        }

        public async Task<Marca> GetMarcaByIdAsync(int id)
        {
            var sql = "SELECT * FROM Marcas WHERE Id = @id";
            var marca = await _dbConnection.QueryFirstOrDefaultAsync<Marca>(sql, new { id });
            return marca;
        }

        public async Task AddMarcaAsync(Marca marca)
        {
            await _context.Marcas.AddAsync(marca);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMarcaAsync(Marca marca)
        {
            _context.Marcas.Update(marca);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMarcaAsync(int id)
        {
            var marca = await this.GetMarcaByIdAsync(id);
            if (marca != null) {
                _context.Marcas.Remove(marca);
                await _context.SaveChangesAsync();
            }
        }

    }
}
