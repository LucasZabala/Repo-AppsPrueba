using Dapper;
using Imagenes.Logic.Data;
using Imagenes.Logic.Interface;
using Imagenes.Logic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagenes.Logic.Repository
{
    public class ObjetoRepository : IObjetoRepository
    {
        private readonly ImagenDbContext _context;
        private readonly IDbConnection _dbConnection;

        public ObjetoRepository(ImagenDbContext context)
        {
            _context = context;
            _dbConnection = _context.Database.GetDbConnection();
        }

        public async Task<IEnumerable<Objeto>> GetAllObjetosAsync()
        {
            var sql = "SELECT * FROM Objetos";
            var objetos = await _dbConnection.QueryAsync<Objeto>(sql);
            return objetos;
        }

        public async Task<Objeto> GetByIdObjetoAsync(int id)
        {
            var sql = "SELECT * FROM Objetos WHERE Id = @id";
            var objeto = await _dbConnection.QueryFirstOrDefaultAsync<Objeto>(sql, new { id });
            return objeto;
        }

        public async Task AddObjetoAsync(Objeto objeto)
        {
            await _context.Objetos.AddAsync(objeto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateObjetoAsync(Objeto objeto)
        {

            _context.Objetos.Update(objeto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteObjetoAsync(int id)
        {
            var objeto = await GetByIdObjetoAsync(id);
            if (objeto != null)
            {
                _context.Objetos.Remove(objeto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
