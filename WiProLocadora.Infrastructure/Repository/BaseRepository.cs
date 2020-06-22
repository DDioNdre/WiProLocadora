using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WiProLocadora.Domain.Entity;
using WiProLocadora.Domain.UseCases.Repository;
using WiProLocadora.Infrastructure.Data.SQLServer;

namespace WiProLocadora.Infrastructure.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly SQLServerDataContext sqlServerDataContext;

        public BaseRepository(SQLServerDataContext sqlServerDataContext)
        {
            this.sqlServerDataContext = sqlServerDataContext;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await sqlServerDataContext.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetByAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await sqlServerDataContext.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await sqlServerDataContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = await sqlServerDataContext.Set<TEntity>().AddAsync(entity);
            await sqlServerDataContext.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = sqlServerDataContext.Set<TEntity>().Update(entity);
            await sqlServerDataContext.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async Task<TEntity> Delete(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry =  sqlServerDataContext.Set<TEntity>().Remove(entity);
            await sqlServerDataContext.SaveChangesAsync();

            return entityEntry.Entity;
        }
    }
}
