using Domain.Aggregate;
using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Persistence.Repositories
{
    public class SetupRepository : RepositoryBase<Setup>, ISetupRepository
    {
        public SetupRepository(DatabaseContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}

