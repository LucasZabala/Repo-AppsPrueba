using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNova.Logic.Data;
using TechNova.Logic.Interfaces;

namespace TechNova.Logic.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly TechNovaDbContext _context;
        private readonly IDbConnection _dbConnection;

        public ProductoRepository(TechNovaDbContext context)
        {
            this._context = context;
            this._dbConnection = _context.Database.GetDbConnection();
        }



    }
}
