using Domain.Aggregate;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(DatabaseContext repositoryContext) : base(repositoryContext)
        {
            
        }
        
        public async Task<Product> GetByProductCode(string code)
        {
            var user = await FindByCondition(u => u.Code == code);

            return user.FirstOrDefault()!;
        }

        public async Task<Product> GetByProductId(Guid id)
        {
            var user = await FindByCondition(x => x.Id == id);
            return user.FirstOrDefault()!;
        }
    }
}
