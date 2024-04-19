using Domain.Aggregate;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DatabaseContext repositoryContext) : base(repositoryContext)
        {
            
        }
        
        public async Task<User> GetByUserNameAsync(string userName)
        {
            var user = await FindByCondition(u => u.UserName == userName);

            return user.FirstOrDefault()!;
        }

        public async Task<User> GetByUserId(string id)
        {
            var user = await FindByCondition(x => x.Id == id);
            return user.FirstOrDefault()!;
        }
    }
}
