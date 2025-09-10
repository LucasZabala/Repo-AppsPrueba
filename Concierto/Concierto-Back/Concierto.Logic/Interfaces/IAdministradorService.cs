using Concierto.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concierto.Logic.Interfaces
{
    public interface IAdministradorService
    {
        Task<IEnumerable<Administrador>> GetAllAdministradoresAsync();
        Task<Administrador> GetByIdAdministradorAsync(int id);
        Task AddAdministradorAsync(Administrador boleto);
        Task UpdateAdministradorAsync(Administrador boleto);
        Task DeleteAdministradorAsync(int id);
    }
}
