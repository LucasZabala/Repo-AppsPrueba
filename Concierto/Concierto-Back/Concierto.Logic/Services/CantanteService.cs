using Concierto.Logic.Interfaces;
using Concierto.Logic.Models;
using Concierto.Logic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concierto.Logic.Services
{
    public class CantanteService : ICantanteService
    {
        private readonly ICantanteRepository _cantanteRepository;

        public CantanteService(ICantanteRepository cantanteRepository)
        {
            _cantanteRepository = cantanteRepository;
        }

        public async Task<IEnumerable<Cantante>> GetAllCantantesAsync()
        {
            return await _cantanteRepository.GetAllCantantesAsync();
        }

        public async Task<Cantante> GetByIdCantanteAsync(int id)
        {
            return await _cantanteRepository.GetByIdCantanteAsync(id);
        }

        public async Task AddCantanteAsync(Cantante asiento)
        {
            await _cantanteRepository.AddCantanteAsync(asiento);
        }

        public async Task UpdateCantanteAsync(Cantante asiento)
        {
            await _cantanteRepository.UpdateCantanteAsync(asiento);
        }

        public async Task DeleteCantanteAsync(int id)
        {
            await _cantanteRepository.DeleteCantanteAsync(id);
        }
    }
}
