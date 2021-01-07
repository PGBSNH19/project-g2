using KNet.API.Context;
using KNet.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNet.API.Repositories
{
    public class UserRepository : Repository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<UserModel> GetUserById(Guid id)
        {
            return await _context.Users
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IList<UserModel>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
