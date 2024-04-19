using Application.Presentation;
using Application.Shared.Commands;

namespace Application.Commands.Users
{
    public class LoginCommand : CommandBase<BaseResponse<AuthorizationResponse>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}