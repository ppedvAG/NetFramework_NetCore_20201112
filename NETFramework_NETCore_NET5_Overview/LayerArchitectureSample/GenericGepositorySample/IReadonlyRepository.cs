using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GenericGepositorySample
{
    public interface IReadonlyRepository<TEntity, TKey> where TEntity : class
    {
        Task<IList<TEntity>> FindByCondition(Expression<Func<TEntity, bool>> predicate);

        Task<IList<TEntity>> GetAll();

        Task<TEntity> GetById(TKey id);
    }
}
