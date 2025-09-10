using Concierto.Logic.Interfaces;
using Concierto.Logic.Models;
using Concierto.Logic.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concierto.Logic.Services
{
    public class EmpleadoService: IEmpleadoService
    {
        private readonly EmpleadoRepository _empleadoRepository;

        public EmpleadoService(EmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;   
        }

        public async Task<IEnumerable<Empleado>> GetAllEmpleadosAsync()
        {
            return await _empleadoRepository.GetAllEmpleadosAsync();
        }

        public async Task<Empleado> GetByIdEmpleadoAsync(int id)
        {
            return await _empleadoRepository.GetByIdEmpleadoAsync(id);
        }

        public async Task AddEmpleadoAsync(Empleado empleado)
        {
            await _empleadoRepository.AddEmpleadoAsync(empleado);
        }

        public async Task UpdateEmpleadoAsync(Empleado empleado)
        {
            await _empleadoRepository.UpdateEmpleadoAsync(empleado);
        }

        public async Task DeleteEmpleadoAsync(int id)
        {
            await _empleadoRepository.DeleteEmpleadoAsync(id);
        }
    }
}
