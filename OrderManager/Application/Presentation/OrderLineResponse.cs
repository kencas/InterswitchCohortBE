namespace Application.Presentation
{
    public record OrderLineResponse
    {
        public string Code { get; init; }
        public string CategoryCode { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
        public Int32 Quantity { get; init; }

    }
}
