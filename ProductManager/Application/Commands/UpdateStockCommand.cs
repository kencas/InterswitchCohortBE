using Application.Presentation;
using Application.Shared.Commands;

namespace Application.Commands
{
    public class UpdateStockCommand : CommandBase<BaseResponse<UpdateStockResponse>>
    {
        public Guid ProductId { get; init; }
        public int Quantity { get; init; } 
        public string OP { get; init; }
    }
}
