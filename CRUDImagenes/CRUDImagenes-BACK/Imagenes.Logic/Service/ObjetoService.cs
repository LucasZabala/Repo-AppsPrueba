using Imagenes.Logic.Interface;
using Imagenes.Logic.Models;
using Imagenes.Logic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagenes.Logic.Service
{
    public class ObjetoService : IObjetoService
    {
        private readonly IObjetoRepository _objetoRepository;

        public ObjetoService(IObjetoRepository objetoRepository)
        {
            _objetoRepository = objetoRepository;
        }

        public async Task<IEnumerable<Objeto>> GetAllObjetosAsync()
        {
            var objetos = await _objetoRepository.GetAllObjetosAsync();
            return objetos;
        }

        public async Task<Objeto> GetByIdObjetoAsync(int id)
        {
            var objeto = await _objetoRepository.GetByIdObjetoAsync(id);
            return objeto;
        }

        public async Task AddObjetoAsync(Objeto objeto)
        {
            await _objetoRepository.AddObjetoAsync(objeto);
        }

        public async Task UpdateObjetoAsync(Objeto objeto)
        {
            await _objetoRepository.UpdateObjetoAsync(objeto);
        }

        public async Task DeleteObjetoAsync(int id)
        {
            await _objetoRepository.DeleteObjetoAsync(id);
        }


    }
}
