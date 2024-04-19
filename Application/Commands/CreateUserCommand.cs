using Application.Presentation;
using Application.Shared.Commands;

namespace Application.Commands
{
    public class CreateUserCommand : CommandBase<BaseResponse<CustomerResponse>>
    {
        public string PhoneNumber { get; init; }
        public string Email { get; init; } 
        public string Username { get; init; }
        public string Password { get; init; }
        public string Firstname { get; init; }
        public string Lastname { get; init; }
    }
}
