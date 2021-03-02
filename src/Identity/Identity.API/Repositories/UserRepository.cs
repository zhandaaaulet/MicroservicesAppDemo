using Identity.API.Data;
using Identity.API.Entities;
using Identity.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AddUser(User u)
        {
            _context.UserList.Add(u);
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.UserList.Include(x => x.Group).ToListAsync();
        }

    }
}
