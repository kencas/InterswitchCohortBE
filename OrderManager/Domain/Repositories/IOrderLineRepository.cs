using Domain.Aggregate;

namespace Domain.Repositories
{
    public interface IOrderLineRepository : IRepositoryBase<OrderLine>
    {
        Task<OrderLine> GetByOrderNumber(string orderNumber);
        Task<OrderLine> GetByOrderId(Guid id);

    }
}
