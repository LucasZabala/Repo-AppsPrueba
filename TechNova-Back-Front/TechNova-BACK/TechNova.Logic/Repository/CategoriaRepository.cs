using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNova.Logic.Data;
using TechNova.Logic.Interfaces;

namespace TechNova.Logic.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly TechNovaDbContext _context;
        private readonly IDbConnection _dbConnection;

        public CategoriaRepository(TechNovaDbContext context)
        {
            _context = context;
            _dbConnection = _context.Database.GetDbConnection();
        }
    }
}
