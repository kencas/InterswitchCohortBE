namespace Application.Presentation
{
    public record UpdateStockResponse
    {
        public Guid ProductId { get; init; }
        public int Quantity { get; init; }
    }
}
