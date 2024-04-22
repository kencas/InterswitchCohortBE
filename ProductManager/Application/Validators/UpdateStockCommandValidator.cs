using Application.Commands;
using FluentValidation;

namespace Application.Validators
{
    public class UpdateStockCommandValidator : AbstractValidator<UpdateStockCommand>
    {
        public UpdateStockCommandValidator()
        {
            RuleFor(model => model.ProductId).NotNull().NotEmpty().WithMessage("Phone Number cannot be empty");
            
        }
    }
}
