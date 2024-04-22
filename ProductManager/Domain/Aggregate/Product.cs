using Domain.Entities;

namespace Domain.Aggregate
{
    public class Product : BaseEntity
    {
        public string Code { get; set; }
        public string CategoryCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Int32 Quantity { get; set; }
        
    }
}
