using KNet.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KNet.API.Repositories
{
    public interface IUserRepository : IRepository
    {
        Task<User> GetUserById(Guid id);
        Task<IList<User>> GetAllUsers();
    }
}