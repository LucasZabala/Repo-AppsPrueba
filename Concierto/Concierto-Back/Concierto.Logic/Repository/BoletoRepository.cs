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
    public class BoletoRepository : IBoletoRepository
    {
        private readonly ConciertoDbContext _context;
        private readonly IDbConnection _dbConnection;

        public BoletoRepository(ConciertoDbContext context)
        {
            _context = context;
            _dbConnection = _context.Database.GetDbConnection();
        }

        public async Task<IEnumerable<Boleto>> GetAllBoletosAsync()
        {
            var sql = "SELECT * FROM Boletos";
            var boletos = await _dbConnection.QueryAsync<Boleto>(sql);
            return boletos;
        }

        public async Task<Boleto> GetByIdBoletoAsync(int id)
        {
            var sql = "SELECT * FROM Boletos";
            var boleto = await _dbConnection.QueryFirstOrDefaultAsync<Boleto>(sql, new { id });
            return boleto;
        }

        public async Task AddBoletoAsync(Boleto boleto)
        {
            await _context.Boletos.AddAsync(boleto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBoletoAsync(Boleto boleto)
        {
            _context.Boletos.Update(boleto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBoletoAsync(int id)
        {
            var boleto = await GetByIdBoletoAsync(id);
            _context.Boletos.Remove(boleto);
            await _context.SaveChangesAsync();
        }

    }
}
