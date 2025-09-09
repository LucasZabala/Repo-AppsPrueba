using Concierto.Logic.Data;
using Concierto.Logic.Interfaces;
using Concierto.Logic.Models;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concierto.Logic.Repository
{
    public class AsientoRepository : IAsientoRepository
    {
        private readonly ConciertoDbContext _context;
        private readonly IDbConnection _dbConnection;

        public AsientoRepository(ConciertoDbContext context)
        {
            _context = context;
            _dbConnection = _context.Database.GetDbConnection();
        }

        public async Task<IEnumerable<Asiento>> GetAllAsientosAsync()
        {
            var sql = "SELECT * FROM Asientos";
            var asientos = await _dbConnection.QueryAsync<Asiento>(sql);
            return asientos;
        }

        public async Task<Asiento> GetByIdAsientoAsync(int id)
        {
            var sql = "SELECT * FROM Asientos WHERE Id = @id";
            var asiento = await _dbConnection.QueryFirstOrDefaultAsync<Asiento>(sql, new { id });
            return asiento;
        }

        public async Task AddAsientoAsync(Asiento asiento)
        {
            await _context.Asientos.AddAsync(asiento);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsientoAsync(Asiento asiento)
        {
            _context.Asientos.Update(asiento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsientoAsync(int id)
        {
            var asiento = await GetByIdAsientoAsync(id);
            _context.Asientos.Remove(asiento);
            await _context.SaveChangesAsync();
        }
    }
}
