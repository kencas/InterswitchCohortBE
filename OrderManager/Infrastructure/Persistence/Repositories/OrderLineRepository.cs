using Domain.Aggregate;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class OrderLineRepository : RepositoryBase<OrderLine>, IOrderLineRepository
    {
        public OrderLineRepository(DatabaseContext repositoryContext) : base(repositoryContext)
        {
            
        }
        
        public async Task<OrderLine> GetByOrderNumber(string orderNumber)
        {
            var user = await FindByCondition(u => u.OrderNumber == orderNumber);

            return user.FirstOrDefault()!;
        }

        public async Task<OrderLine> GetByOrderId(Guid id)
        {
            var user = await FindByCondition(x => x.Id == id);
            return user.FirstOrDefault()!;
        }
    }
}
