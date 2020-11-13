using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenericGepositorySample.Traits
{
    public interface IDeleteCommand<TKey>
    {
        Task Delete(TKey id);
    }
}
