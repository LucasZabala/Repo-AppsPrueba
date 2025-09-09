using Concierto.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concierto.Logic.Interfaces
{
    public interface IBoletoRepository
    {
        Task<IEnumerable<Boleto>> GetAllBoletosAsync();
        Task<Boleto> GetByIdBoletoAsync(int id);
        Task AddBoletoAsync(Boleto boleto);
        Task UpdateBoletoAsync(Boleto boleto);
        Task DeleteBoletoAsync(int id);
    }
}
