using KNet.API.Context;
using KNet.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNet.API.Repositories
{
    public class CategoryRepository : Repository, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<CategoryModel> GetCategoryByName(string name)
        {
            name = name.ToLower();

            return await _context.Categories
                .Where(x => x.Name == name)
                .FirstOrDefaultAsync();
        }
    }
}
