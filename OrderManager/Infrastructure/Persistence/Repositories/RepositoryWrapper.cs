using Domain.Repositories;

namespace Infrastructure.Persistence.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DatabaseContext _repoContext;
        private IOrderLineRepository _OrderLine;

        public RepositoryWrapper(DatabaseContext repoContext)
        {
            _repoContext = repoContext;
        }

        public IOrderLineRepository OrderLine
        {
            get
            {
                if (_OrderLine == null)
                {
                    _OrderLine = new OrderLineRepository(_repoContext);
                }

                return _OrderLine;
            }
        }

        public async Task Save()
        {
            await _repoContext.SaveChangesAsync();
        }

    }
}
