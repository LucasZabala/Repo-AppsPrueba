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
    public class AdministradorService : IAdministradorService
    {
        private readonly IAdministradorRepository _administradorRepository;

        public AdministradorService(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
        }

        public async Task<IEnumerable<Administrador>> GetAllAdministradoresAsync()
        {
            return await _administradorRepository.GetAllAdministradoresAsync();
        }

        public async Task<Administrador> GetByIdAdministradorAsync(int id)
        {
            return await _administradorRepository.GetByIdAdministradorAsync(id);
        }

        public async Task AddAdministradorAsync(Administrador administrador)
        {
            await _administradorRepository.AddAdministradorAsync(administrador);
        }

        public async Task UpdateAdministradorAsync(Administrador administrador)
        {
            await _administradorRepository.UpdateAdministradorAsync(administrador);
        }

        public async Task DeleteAdministradorAsync(int id)
        {
            await _administradorRepository.DeleteAdministradorAsync(id);
        }
    }
}
