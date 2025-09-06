using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNova.Logic.Interfaces;
using TechNova.Logic.Models;

namespace TechNova.Logic.Services
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaService(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        public async Task<IEnumerable<Marca>> GetAllMarcasAsync()
        {
            return await _marcaRepository.GetAllMarcasAsync();
        }

        public async Task<Marca> GetMarcaByIdAsync(int id)
        {
            var marca = await _marcaRepository.GetMarcaByIdAsync(id);
            if (marca == null) { 
                throw new ArgumentNullException("No existe marca con ese Id");
            }
            return marca;
        }

        public async Task AddMarcaAsync(Marca marca)
        {
            if(marca == null)
            {
                throw new ArgumentNullException("La marca no puede ser nula");
            }
            await _marcaRepository.AddMarcaAsync(marca);
        }

        public async Task UpdateMarcaAsync(Marca marca)
        {
            if (marca == null)
            {
                throw new ArgumentNullException("La marca no puede ser nula");
            }
            await _marcaRepository.UpdateMarcaAsync(marca);
        }

        public async Task DeleteMarcaAsync(int id)
        {
            await _marcaRepository.DeleteMarcaAsync(id);
        }

    }
}
