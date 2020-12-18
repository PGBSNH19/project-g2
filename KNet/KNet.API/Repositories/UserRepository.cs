using KNet.API.Context;
using KNet.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNet.API.Repositories
{
    public class UserRepository : Repository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await _context.Users
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
