using Domain.Entities;

namespace Domain.Aggregate
{
    public class OrderLine : BaseEntity
    {
        public ICollection<OrderItem> OrderItems { get; set; }
        public AddressLine ShippingAddress { get; set; }
        public string OrderNumber { get; set; }
        public decimal Tax { get; set; } = 0;
        public decimal SubTotal { get; set; } = 0;
        public decimal Discount { get; set; } = 0;
        
    }
}
