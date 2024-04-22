using System.Linq.Expressions;

namespace Domain.Repositories
{
    public interface IRepositoryBase<T>
    {
        Task<IQueryable<T>> FindAll();
        Task<IQueryable<T>> FindByCondition(Expression<Func<T, bool>> expression);
        Task<T> Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
