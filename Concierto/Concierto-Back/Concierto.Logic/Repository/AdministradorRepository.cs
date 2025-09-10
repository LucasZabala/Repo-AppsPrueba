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
    public class AdministradorRepository: IAdministradorRepository
    {
        private readonly ConciertoDbContext _context;
        private readonly IDbConnection _dbConnection;

        public AdministradorRepository(ConciertoDbContext context)
        {
            _context = context;
            _dbConnection = _context.Database.GetDbConnection();
        }

        public async Task<IEnumerable<Administrador>> GetAllAdministradoresAsync()
        {
            var sql = "SELECT * FROM Administradores";
            var administradores = await _dbConnection.QueryAsync<Administrador>(sql);
            return administradores;
        }

        public async Task<Administrador> GetByIdAdministradorAsync(int id)
        {
            var sql = "SELECT * FROM Administradores WHERE Id = @id";
            var administrador = await _dbConnection.QueryFirstOrDefaultAsync<Administrador>(sql, new { id });
            return administrador;
        }

        public async Task AddAdministradorAsync(Administrador administrador)
        {
            await _context.Administradores.AddAsync(administrador);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAdministradorAsync(Administrador administrador)
        {
            _context.Administradores.Update(administrador);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAdministradorAsync(int id)
        {
            var administrador = await GetByIdAdministradorAsync(id);
            _context.Administradores.Remove(administrador);
            await _context.SaveChangesAsync();
        }
    }
}
