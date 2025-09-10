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
    public class LugarRepository:ILugarRepository
    {
        private readonly ConciertoDbContext _context;
        private readonly IDbConnection _dbConnection;

        public LugarRepository(ConciertoDbContext context)
        {
            _context = context;
            _dbConnection = _context.Database.GetDbConnection();
        }

        public async Task<IEnumerable<Lugar>> GetAllLugaresAsync()
        {
            var sql = "SELECT * FROM Lugares";
            var lugares = await _dbConnection.QueryAsync<Lugar>(sql);
            return lugares;
        }

        public async Task<Lugar> GetByIdLugarAsync(int id)
        {
            var sql = "SELECT * FROM Lugares WHERE Id = @id";
            var lugar = await _dbConnection.QueryFirstOrDefaultAsync<Lugar>(sql, new { id });
            return lugar;
        }

        public async Task AddLugarAsync(Lugar lugar)
        {
            await _context.Lugares.AddAsync(lugar);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLugarAsync(Lugar lugar)
        {
            _context.Lugares.Update(lugar);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLugarAsync(int id)
        {
            var lugar = await GetByIdLugarAsync(id);
            _context.Lugares.Remove(lugar);
            await _context.SaveChangesAsync();
        }
    }
}
