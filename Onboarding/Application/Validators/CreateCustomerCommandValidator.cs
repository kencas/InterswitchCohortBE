using Application.Commands;
using FluentValidation;

namespace Application.Validators
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(model => model.PhoneNumber).NotNull().NotEmpty().WithMessage("Phone Number cannot be empty");
            
        }
    }
}
