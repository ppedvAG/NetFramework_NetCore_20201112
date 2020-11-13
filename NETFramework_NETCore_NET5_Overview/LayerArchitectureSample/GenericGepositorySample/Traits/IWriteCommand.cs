using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenericGepositorySample.Traits
{
    public interface IWriteCommand<TEntity> where TEntity : class
    {
        Task Insert(TEntity entity);

        Task InsertRange(TEntity[] entities);
    }
}
