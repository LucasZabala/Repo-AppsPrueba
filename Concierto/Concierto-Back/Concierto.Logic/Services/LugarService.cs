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
    internal class LugarService: ILugarService
    {
        private readonly LugarRepository _lugarRepository;

        public LugarService(LugarRepository lugarRepository)
        {
            _lugarRepository = lugarRepository;
        }

        public async Task<IEnumerable<Lugar>> GetAllLugaresAsync()
        {
            return await _lugarRepository.GetAllLugaresAsync();
        }

        public async Task<Lugar> GetByIdLugarAsync(int id)
        {
            return await _lugarRepository.GetByIdLugarAsync(id);
        }

        public async Task AddLugarAsync(Lugar lugar)
        {
            await _lugarRepository.AddLugarAsync(lugar);
        }

        public async Task UpdateLugarAsync(Lugar lugar)
        {
            await _lugarRepository.UpdateLugarAsync(lugar);
        }

        public async Task DeleteLugarAsync(int id)
        {
            await _lugarRepository.DeleteLugarAsync(id);
        }
    }
}
