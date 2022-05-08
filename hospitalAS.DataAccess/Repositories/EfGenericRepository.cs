using hospitalAS.DataAccess.Data;
using hospitalAS.DataAccess.Interfaces;
using hospitalAS.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalAS.DataAccess.Repositories
{
    public class EfGenericRepository<T> : IGenericRepository<T> where T : class, IEntity, new()
    {
        private readonly hospitalASDbContext _context;
        public EfGenericRepository(hospitalASDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Delete(int id)
        {

            var temp =await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(temp);
            _context.SaveChanges();
        }

        public async Task<IList<T>> GetAllEntities()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetEntityById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<bool> IsExists(int id)
        {
            return await _context.Set<T>().AnyAsync(t => t.Id == id);
        }

        public async Task<int> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return await _context.SaveChangesAsync();
        }
    }
}
