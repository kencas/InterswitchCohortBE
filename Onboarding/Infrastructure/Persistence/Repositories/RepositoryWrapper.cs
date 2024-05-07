using Domain.Repositories;

namespace Infrastructure.Persistence.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DatabaseContext _repoContext;
        private IUserRepository _user;

        public RepositoryWrapper(DatabaseContext repoContext)
        {
            _repoContext = repoContext;
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }

                return _user;
            }
        }

        public ISetupRepository Setup => throw new NotImplementedException();

        public async Task Save()
        {
            await _repoContext.SaveChangesAsync();
        }

    }
}
