using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KNet.API.Repositories
{
    public interface IRepository
    {
        Task<T> Add<T>(T entity) where T : class;
        Task<T> Delete<T>(T entity) where T : class;
        Task<bool> Save();
        Task<T> Update<T>(T entity) where T : class;
        Task<T> GetEntityById<T>(Guid id) where T : class;
        Task<IList<T>> GetAllEntities<T>() where T : class;
    }
}
