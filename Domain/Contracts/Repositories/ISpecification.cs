using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NewStructureForBackEnd.Domain.Contracts.Repositories
{
    public interface ISpecification<T>
    {
        Expression<Func<T,bool>>Criteria { get; }
    }
}
