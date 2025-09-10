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
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly ConciertoDbContext _context;
        private readonly IDbConnection _dbConnection;

        public EmpleadoRepository(ConciertoDbContext context)
        {
            _context = context;
            _dbConnection = _context.Database.GetDbConnection();
        }

        public async Task<IEnumerable<Empleado>> GetAllEmpleadosAsync()
        {
            var sql = "SELECT * FROM Empleados";
            var empleados = await _dbConnection.QueryAsync<Empleado>(sql);
            return empleados;
        }

        public async Task<Empleado> GetByIdEmpleadoAsync(int id)
        {
            var sql = "SELECT * FROM Empleados WHERE Id = @id";
            var empleado = await _dbConnection.QueryFirstOrDefaultAsync<Empleado>(sql, new { id });
            return empleado;
        }

        public async Task AddEmpleadoAsync(Empleado empleado)
        {
            await _context.Empleados.AddAsync(empleado);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmpleadoAsync(Empleado empleado)
        {
            _context.Empleados.Update(empleado);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmpleadoAsync(int id)
        {
            var empleado = await GetByIdEmpleadoAsync(id);
            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();
        }
    }
}
