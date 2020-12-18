using KNet.API.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace KNet.API.Repositories
{
    public class Repository : IRepository
    {
        protected readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<T> Add<T>(T entity) where T : class
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<T> Delete<T>(Guid id) where T : class
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            _context.Set<T>().Remove(entity);
            await Save();
            return entity;
        }

        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<T> Update<T>(T entity) where T : class
        {
            _context.Entry(entity).State = EntityState.Modified;
            await Save();
            return entity;
        }
    }
}