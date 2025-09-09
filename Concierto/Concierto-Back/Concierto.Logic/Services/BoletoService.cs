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
    public class BoletoService : IBoletoService
    {
        private readonly IBoletoRepository _boletoRepository;

        public BoletoService(IBoletoRepository boletoRepository)
        {
            _boletoRepository = boletoRepository;
        }

        public async Task<IEnumerable<Boleto>> GetAllBoletosAsync()
        {
           return await _boletoRepository.GetAllBoletosAsync();
        }

        public async Task<Boleto> GetByIdBoletoAsync(int id)
        {
            return await _boletoRepository.GetByIdBoletoAsync(id);
        }

        public async Task AddBoletoAsync(Boleto boleto)
        {
            await _boletoRepository.AddBoletoAsync(boleto);
        }

        public async Task UpdateBoletoAsync(Boleto boleto)
        {
           await _boletoRepository.UpdateBoletoAsync(boleto);
        }

        public async Task DeleteBoletoAsync(int id)
        {
            await _boletoRepository.DeleteBoletoAsync(id);
        }

    }
}
