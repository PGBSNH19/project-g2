using KNet.API.Context;
using KNet.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNet.API.Repositories
{
    public class AdvertRepository : Repository, IAdvertRepository
    {
        public AdvertRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<AdvertModel> GetAdvertById(Guid id)
        {
            return await _context.Adverts
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IList<AdvertModel>> GetAllAdverts()
        {
            return await _context.Adverts.ToListAsync();
        }

        public async Task<IList<AdvertModel>> GetAdvertsByUserId(Guid id)
        {
            return await _context.Adverts
                .Where(x => x.UserId == id)
                .ToListAsync();
        }
    }
}
