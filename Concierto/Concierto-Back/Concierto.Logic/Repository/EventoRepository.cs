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
    public class EventoRepository : IEventoRepository
    {
        private readonly ConciertoDbContext _context;
        private readonly IDbConnection _dbConnection;

        public EventoRepository(ConciertoDbContext context)
        {
            _context = context;
            _dbConnection = _context.Database.GetDbConnection();
        }

        public async Task<IEnumerable<Evento>> GetAllEventosAsync()
        {
            var sql = "SELECT * FROM Eventos";
            var eventos = await _dbConnection.QueryAsync<Evento>(sql);

            return eventos;
        }

        public async Task<Evento> GetByIdEventoAsync(int id)
        {
            var sql = "SELECT * FROM Eventos WHERE Id = @id";
            var evento = await _dbConnection.QueryFirstOrDefaultAsync<Evento>(sql, new { id });
            return evento;
        }

        public async Task AddEventoAsync(Evento evento)
        {
            await _context.Eventos.AddAsync(evento);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEventoAsync(Evento evento)
        {
            _context.Eventos.Update(evento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEventoAsync(int id)
        {
            var evento = await GetByIdEventoAsync(id);
            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();
        }
    }
}
