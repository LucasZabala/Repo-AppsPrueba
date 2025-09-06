using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNova.Logic.Interfaces;
using TechNova.Logic.Models;

namespace TechNova.Logic.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<IEnumerable<Categoria>> GetAllCategoriasAsync()
        {
            return await _categoriaRepository.GetAllCategoriasAsync();
        }

        public async Task<Categoria> GetCategoriaByIdAsync(int id)
        {
            var categoria = await _categoriaRepository.GetCategoriaByIdAsync(id);
            if(categoria == null)
            {
                throw new InvalidOperationException("La categoria no existe");
            }
            return categoria;
        }

        public async Task AddCategoriaAsync(Categoria categoria)
        {
            if(categoria == null)
            {
                throw new ArgumentNullException("La categoria no puede ser nula");
            }
            await _categoriaRepository.AddCategoriaAsync(categoria);
        }

        public async Task UpdateCategoriaAsync(Categoria categoria)
        {
            if (categoria == null)
            {
                throw new ArgumentNullException("No se puede editar una categoria nula");
            }
            await _categoriaRepository.UpdateCategoriaAsync(categoria);
        }

        public async Task DeleteCategoriaAsync(int id)
        {
            await _categoriaRepository.DeleteCategoriaAsync(id);
        }


    }
}
