using Domain.Aggregate;

namespace Domain.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<Product> GetByProductCode(string code);
        Task<Product> GetByProductId(Guid id);

    }
}
