using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenericGepositorySample.Traits
{
    public interface IUpdateCommand<TEntity, TKey> where TEntity : class
    {
        Task Update(TKey Id, TEntity modifiedEntity);
    }
}
