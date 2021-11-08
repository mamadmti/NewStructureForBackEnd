using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Domain.Entities;

namespace MyProject.Domain.Contracts.Repositories
{
    public interface IRepository
    {
        Task<T> GetById<T>(long id) where T : BaseEntity;
        Task<T> GetById<T>(long id,string include) where T : BaseEntity;
        //Task<List<T>> list<T>(Ispecification<T> spec = null) where T : BaseEntity;

        Task<T> Add<T>(T entity) where T : BaseEntity;
        Task Update<T>(T entity) where T : BaseEntity;

        Task Delete<T>(T entity) where T : BaseEntity;

        Task SaveChange();

    }
}
