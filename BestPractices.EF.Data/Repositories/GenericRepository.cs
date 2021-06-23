using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;

namespace BestPractices.EF.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _appDbContext;
        internal DbSet<TEntity> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _appDbContext = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task Insert(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual void Update(TEntity entityToUpdate)
        {

            _dbSet.Attach(entityToUpdate);
            _appDbContext.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, StringValues includeProperties)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await (orderBy != null ? orderBy(query).ToListAsync() : query.ToListAsync());
        }
    }
}
