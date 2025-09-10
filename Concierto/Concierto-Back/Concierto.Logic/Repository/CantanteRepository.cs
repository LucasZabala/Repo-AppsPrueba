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
    public class CantanteRepository:ICantanteRepository
    {
        private readonly ConciertoDbContext _context;
        private readonly IDbConnection _dbConnection;

        public CantanteRepository(ConciertoDbContext context)
        {
            _context = context;
            _dbConnection = _context.Database.GetDbConnection();
        }

        public async Task<IEnumerable<Cantante>> GetAllCantantesAsync()
        {
            var sql = "SELECT * FROM Cantantes";
            var cantantes = await _dbConnection.QueryAsync<Cantante>(sql);
            return cantantes;
        }

        public async Task<Cantante> GetByIdCantanteAsync(int id)
        {
            var sql = "SELECT * FROM Cantantes";
            var cantante = await _dbConnection.QueryFirstOrDefaultAsync<Cantante>(sql, new { id });
            return cantante;
        }

        public async Task AddCantanteAsync(Cantante cantante)
        {
            await _context.Cantantes.AddAsync(cantante);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCantanteAsync(Cantante cantante)
        {
            _context.Cantantes.Update(cantante);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCantanteAsync(int id)
        {
            var cantante = await GetByIdCantanteAsync(id);
            _context.Cantantes.Remove(cantante);
            await _context.SaveChangesAsync();
        }

    }
}
