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
    public class AsientoService : IAsientoService
    {
        private readonly IAsientoRepository _asientoRepository;

        public AsientoService(IAsientoRepository asientoRepository)
        {
            _asientoRepository = asientoRepository;
        }

        public async Task<IEnumerable<Asiento>> GetAllAsientosAsync()
        {
            return await _asientoRepository.GetAllAsientosAsync();
        }

        public async Task<Asiento> GetByIdAsientoAsync(int id)
        {
            return await _asientoRepository.GetByIdAsientoAsync(id);
        }

        public async Task AddAsientoAsync(Asiento asiento)
        {
            await _asientoRepository.AddAsientoAsync(asiento);
        }

        public async Task UpdateAsientoAsync(Asiento asiento)
        {
            await _asientoRepository.UpdateAsientoAsync(asiento);
        }

        public async Task DeleteAsientoAsync(int id)
        {
            await _asientoRepository.DeleteAsientoAsync(id);
        }
    }
}
