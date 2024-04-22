using Domain.Repositories;

namespace Infrastructure.Persistence.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DatabaseContext _repoContext;
        private IProductRepository _product;

        public RepositoryWrapper(DatabaseContext repoContext)
        {
            _repoContext = repoContext;
        }

        public IProductRepository Product
        {
            get
            {
                if (_product == null)
                {
                    _product = new ProductRepository(_repoContext);
                }

                return _product;
            }
        }

        public async Task Save()
        {
            await _repoContext.SaveChangesAsync();
        }

    }
}
