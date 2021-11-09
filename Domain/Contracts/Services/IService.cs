using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewStructureForBackEnd.Domain.Contracts.Repositories;

namespace MyProject.Domain.Contracts.Services
{
    public interface  IService<T,TId>
    {
        Task<T> AddNew(T item);
        Task<T> GetById(TId id);
        Task Remove(T item);
        Task Update(T item);
        Task<IEnumerable<T>> GetALL(ISpecification<T> spec = null);
    }
}
