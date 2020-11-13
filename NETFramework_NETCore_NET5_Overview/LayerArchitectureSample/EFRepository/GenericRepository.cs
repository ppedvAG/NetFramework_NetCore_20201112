using GenericGepositorySample;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository
{
    public class GenericRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {

        DbContext _dbContext; //Ab hier ist das Repository EF Bezogen

        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<int> Count()
        {
            return await _dbContext.Set<TEntity>().CountAsync();
        }

        public async Task Delete(TKey id)
        {
            TEntity toRemove = await GetById(id);

            if (toRemove == null)
                throw new Exception("instance is null");

            _dbContext.Set<TEntity>().Remove(toRemove);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IList<TEntity>> FindByCondition(Expression<Func<TEntity, bool>> predicate)
        {
            IList<TEntity> resultList = null;

            try
            {
                resultList = await _dbContext.Set<TEntity>().Where(predicate).ToListAsync();
            }
            catch (Exception ex)
            {
                //ex.Message könnte man jetzt loggen
            }

            return resultList;
        }

        public async Task<IList<TEntity>> GetAll()
        {
            IList<TEntity> resultList = null;

            try
            {
                resultList = await _dbContext.Set<TEntity>().ToListAsync();
            }
            catch (Exception ex)
            {
                //ex.Message könnte man jetzt loggen
            }

            return resultList;
        }

        public async Task<TEntity> GetById(TKey id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task Insert(TEntity entity)
        {
            if (entity == null)
                throw new Exception($"GenericRepository.Insert->with Type { entity.ToString() } : instance is null. ");

            await _dbContext.Set<TEntity>().AddAsync(entity);

            await _dbContext.SaveChangesAsync();
            return;
        }

        public async Task InsertRange(TEntity[] entities)
        {
            foreach (TEntity entity in entities)
                await Insert(entity);
        }

        public async Task Update(TKey Id, TEntity modifiedEntity)
        {

            _dbContext.Set<TEntity>().Attach(modifiedEntity);
            _dbContext.Set<TEntity>().Update(modifiedEntity);

            await _dbContext.SaveChangesAsync();
        }
    }
}
