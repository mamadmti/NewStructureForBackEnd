using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Domain.Contracts.Services
{
    public interface  IService<T,TId>
    {
        Task<T> AddNew(T item);
        Task<T> GetById(TId id);
        Task Remove(T item);
        Task Update(T item);
    }
}
