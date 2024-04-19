using Application.Commands.Users;
using Application.Presentation;
using Application.Shared.Commands;
using Application.Shared.Exceptions;
using AutoMapper;
using Domain.Aggregate;
using Domain.Repositories;
using Domain.Shared;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Application.Handlers.Users
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand, BaseResponse<AuthorizationResponse>>
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;

        public LoginCommandHandler(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IMapper mapper,
            IAuthManager authManager,
            IRepositoryWrapper repository
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _authManager = authManager;
            _repository = repository;
        }

        public async Task<BaseResponse<AuthorizationResponse>> Handle(LoginCommand command, CancellationToken cancellationToken)
        {

            var user = await _userManager.FindByEmailAsync(command.Email);
            if (user == null)
            {
                throw new NotFoundException("User does not exist");

            }

            if (await _userManager.CheckPasswordAsync(user, command.Password) == false)
            {
                throw new BadRequestException("Invalid credentials");
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, command.Password, isPersistent: true, lockoutOnFailure: false);
            if (result.Succeeded == false)
            {
                throw new BadRequestException("Login failed");
            }


            var token = await _authManager.CreateTokenAsync(user);

            return BaseResponse<AuthorizationResponse>.Success($"User logged In successfully",
                 new AuthorizationResponse()
                 {
                     Id = user.Id,
                     Token = token,
                     FirstName = user.Firstname,
                     LastName = user.Lastname,
                     EmailAdress = user.Email,
                     PhoneNumber = user.PhoneNumber,
                     UserId = user.Id
                 }, statusCode: 200);

        }
    }
}
