using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T_Electronic.Logic.Interfaces;
using T_Electronic.Logic.Models;

namespace T_Electronic.Logic.Services
{
    public class CategoriaService : ICategoriaService
    {
        // Declara una variable privada para el repositorio
        private readonly ICategoriaRepository _categoriaRepository;

        // Inyecta el repositorio a través del constructor
        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        // Ahora, implementa los métodos usando el repositorio
        public async Task<IEnumerable<Categoria>> GetAllCategoriasAsync()
        {
            return await _categoriaRepository.GetAllAsync();
        }

        public async Task<Categoria> GetCategoriaByIdAsync(int id)
        {
            return await _categoriaRepository.GetByIdAsync(id);
        }

        public async Task AddCategoriaAsync(Categoria categoria)
        {
            await _categoriaRepository.AddAsync(categoria);
        }

        public async Task UpdateCategoriaAsync(Categoria categoria)
        {
            await _categoriaRepository.UpdateAsync(categoria);
        }

        public async Task DeleteCategoriaAsync(int id)
        {
            await _categoriaRepository.DeleteAsync(id);
        }
    }
}
