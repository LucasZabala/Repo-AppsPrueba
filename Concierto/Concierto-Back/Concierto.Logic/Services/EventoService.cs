using Concierto.Logic.Data;
using Concierto.Logic.Interfaces;
using Concierto.Logic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concierto.Logic.Services
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _eventoRepository;

        public EventoService(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        public async Task<IEnumerable<Evento>> GetAllEventosAsync()
        {
            return await _eventoRepository.GetAllEventosAsync();
        }

        public async Task<Evento> GetByIdEventoAsync(int id)
        {
            return await _eventoRepository.GetByIdEventoAsync(id);

        }

        public async Task AddEventoAsync(Evento evento)
        {
            await _eventoRepository.AddEventoAsync(evento);
        }

        public async Task UpdateEventoAsync(Evento evento)
        {
            await _eventoRepository.UpdateEventoAsync(evento);
        }

        public async Task DeleteEventoAsync(int id)
        {
            await _eventoRepository.DeleteEventoAsync(id);
        }
    }
}
