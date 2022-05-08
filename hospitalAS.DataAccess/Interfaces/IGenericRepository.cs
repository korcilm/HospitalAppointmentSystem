using hospitalAS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.DataAccess.Interfaces
{
    public interface IGenericRepository<T> where T : class, IEntity, new()
    {
        Task<IList<T>> GetAllEntities();
        Task<T> GetEntityById(int id);
        Task<int> Add(T entity);
        Task<int> Update(T entity);
        Task<bool> IsExists(int id);
        Task Delete(int id);

    }
}
