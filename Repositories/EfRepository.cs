using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyProject.Domain.Contexts;
using MyProject.Domain.Contracts.Repositories;
using MyProject.Domain.Entities;

namespace MyProject.Repositories
{
    public class EfRepository : IRepository
    {
        private readonly CustomerContext _dbContext ;

        public EfRepository(CustomerContext dbContext )
        {
            _dbContext = dbContext;
        }
        public async Task<T> Add<T>(T entity) where T : BaseEntity
        {
          await  _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task Delete<T>(T entity) where T : BaseEntity
        {
             _dbContext.Set<T>().Remove(entity);
        }

        public async Task<T> GetById<T>(long id) where T : BaseEntity
        {
            return await _dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
        }

        public Task<T> GetById<T>(long id, string include) where T : BaseEntity
        {
            throw new NotImplementedException();
        }

        public async Task SaveChange()
        {
            await _dbContext.SaveChangesAsync();
            
        }

        public async Task Update<T>(T entity) where T : BaseEntity
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

        }
    }
}
