using Domain.Aggregate;

namespace Domain.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetByUserNameAsync(string userName);
        Task<User> GetByUserId(string id);

    }
}
