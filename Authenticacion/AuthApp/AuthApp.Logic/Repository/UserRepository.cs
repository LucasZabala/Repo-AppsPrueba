using AuthApp.Logic.Data;
using AuthApp.Logic.Interfaces;
using AuthApp.Logic.Models;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Logic.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthAppDbContext _context;

        public UserRepository(AuthAppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

    }
}
