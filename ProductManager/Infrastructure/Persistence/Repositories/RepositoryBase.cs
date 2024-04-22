using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DatabaseContext RepositoryContext { get; set; }
        public RepositoryBase(DatabaseContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        public Task<IQueryable<T>> FindAll()
        {
            return Task.FromResult(RepositoryContext.Set<T>().AsNoTracking());
        }

        public Task<IQueryable<T>> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return Task.FromResult(RepositoryContext.Set<T>().Where(expression).AsNoTracking());
        }

        public Task<T> Create(T entity)
        {
            var result = RepositoryContext.Set<T>().Add(entity);

            return Task.FromResult(result.Entity);
        }

        public Task Update(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
            return Task.CompletedTask;
        }

        public Task Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }
    }
}
