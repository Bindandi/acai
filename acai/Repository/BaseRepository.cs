using acai.Model;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace acai.Repository
{
    public abstract class BaseRepository<TEntity, TContext>
        where TEntity : BaseModel
        where TContext : DbContext
    {
        protected DbSet<TEntity> DbSet;
        protected TContext DbContext;

        protected BaseRepository(TContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<TEntity>();
        }

        public virtual async Task<List<TEntity>> Get
            (            
            Expression<Func<TEntity, object>> orderBy,
            bool asNoTracking = true,
            int take = 100
            )
        {
            
            
            if (asNoTracking)
                return await DbSet.AsNoTracking().OrderBy(orderBy).Take(take).ToListAsync().ConfigureAwait(false);


            return await DbSet.OrderBy(orderBy).Take(take).ToListAsync().ConfigureAwait(false);
          
        }


        public virtual async Task<List<TEntity>> Get
            (
            Expression<Func<TEntity, bool>> where,
            bool asNoTracking = true,
            int take = 100
            )
        {
            
            if (asNoTracking)
                return await DbSet.AsNoTracking().Where(where).Take(take).ToListAsync().ConfigureAwait(false);


            return await DbSet.Where(where).Take(take).ToListAsync().ConfigureAwait(false);

        }

       

        public virtual async Task<List<TEntity>> Get
        (
            Expression<Func<TEntity, object>> orderBy,
            Expression<Func<TEntity, bool>> where,
            bool asNoTracking = true,
            int take = 100
        )
        {
            if (asNoTracking)
                return await DbSet.AsNoTracking().OrderBy(orderBy).Where(where).Take(take).ToListAsync()
                    .ConfigureAwait(false);

            return await DbSet.OrderBy(orderBy).Where(where).Take(take).ToListAsync()
             .ConfigureAwait(false);
            
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity).ConfigureAwait(false);
        }

        public virtual Task UpdateAsync(TEntity entity)
        {
            DbSet.Update(entity);
            return Task.CompletedTask;
        }

        public virtual Task RemoveAsync(TEntity entity)
        {
            DbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public virtual async Task SaveChangesAsync()
        {
            await DbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
