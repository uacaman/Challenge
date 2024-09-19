using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    /// <summary>
    /// Basic CRUD operations for any IEntity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Crud<T> : ICrud<T> where T : class, IEntity, new()
    {
        protected ChallengeDbContext dbContext;

        public Crud(ChallengeDbContext context)
        {
            dbContext = context;
        }

        public async Task<List<T>> AllNoTrakingAsync()
        {
            return await dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<List<T>> AllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T?> ByIdAsync(int id)
        {
            var entity = await dbContext.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task AddAsync(T entity)
        {
           await dbContext.Set<T>().AddAsync(entity);
        }

        public void Remove(T entity)
        {
            dbContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            dbContext.Set<T>().Update(entity);
        }
    }
}
