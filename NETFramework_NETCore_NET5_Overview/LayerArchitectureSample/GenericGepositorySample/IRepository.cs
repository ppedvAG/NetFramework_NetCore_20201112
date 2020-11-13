using GenericGepositorySample.Traits;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenericGepositorySample
{
    public interface IRepository<TEntity, TKey> :
        IReadonlyRepository<TEntity, TKey>,
        IWriteCommand<TEntity>,
        IUpdateCommand<TEntity, TKey>,
        IDeleteCommand<TKey> where TEntity : class
    {
        Task<int> Count();
    }
}
