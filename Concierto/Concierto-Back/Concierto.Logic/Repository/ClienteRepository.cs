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
    public class ClienteRepository:IClienteRepository
    {
        private readonly ConciertoDbContext _context;
        private readonly IDbConnection _dbConnection;

        public ClienteRepository(ConciertoDbContext contex)
        {
            _context = contex;
            _dbConnection = _context.Database.GetDbConnection();
        }

        public async Task<IEnumerable<Cliente>> GetAllClientesAsync()
        {
            var sql = "SELECT * FROM Clientes";
            var clientes = await _dbConnection.QueryAsync<Cliente>(sql);
            return clientes;
        }

        public async Task<Cliente> GetByIdClienteAsync(int id)
        {
            var sql = "SELECT * FROM Clientes";
            var cliente = await _dbConnection.QueryFirstOrDefaultAsync<Cliente>(sql, new { id });
            return cliente;
        }

        public async Task AddClienteAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClienteAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClienteAsync(int id)
        {
            var cliente = await GetByIdClienteAsync(id);
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }

    }
}
