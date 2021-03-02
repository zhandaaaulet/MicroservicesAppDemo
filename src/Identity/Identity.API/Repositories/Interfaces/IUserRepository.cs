using Identity.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> AddUser(User u);
        Task<IEnumerable<User>> GetUsers();
    }
}
