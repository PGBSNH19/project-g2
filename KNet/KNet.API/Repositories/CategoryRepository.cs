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

        public async Task<CategoryModel> GetCategoryById(Guid id)
        {
            return await _context.Categories
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<CategoryModel> GetCategoryByName(string name)
        {
            name = name.ToLower();

            return await _context.Categories
                .Where(x => x.Name == name)
                .FirstOrDefaultAsync();
        }

        public async Task<IList<CategoryModel>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
