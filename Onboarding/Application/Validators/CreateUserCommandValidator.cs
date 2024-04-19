using Application.Commands;
using FluentValidation;

namespace Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(model => model.PhoneNumber).NotNull().NotEmpty().WithMessage("Phone Number cannot be empty");
            
        }
    }
}
