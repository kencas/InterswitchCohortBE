using Application.Commands;
using Application.Presentation;
using Application.Shared;
using Application.Shared.Commands;
using Application.Shared.Exceptions;
using AutoMapper;
using Domain.Aggregate;
using Domain.Repositories;
using Domain.Shared;
using Microsoft.AspNetCore.Identity;
using System.Text;

namespace Application.Handlers
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, BaseResponse<CustomerResponse>>
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthManager _authManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public CreateUserCommandHandler(
            UserManager<User> userManager,
            IUnitOfWork unitOfWork,
            IRepositoryWrapper repository,
            IMapper mapper,
            IAuthManager authManager
            )
        {
            _userManager = userManager;
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _authManager = authManager;
        }

        public async Task<BaseResponse<CustomerResponse>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {

            var user = (await _repository.User.FindByCondition(user => user.PhoneNumber == command.PhoneNumber || user.Email == command.Email)).FirstOrDefault();

            if (user != null) throw new UserAlreadyExistException("User already exist, check your email or phone number");

            user = _mapper.Map<User>(command);


            if (string.IsNullOrEmpty(command.Username)) user.UserName = $"{command.Firstname}{command.Lastname}";

            var result = await _userManager.CreateAsync(user, command.Password);

            if (!result.Succeeded)
            {
                StringBuilder builder = new StringBuilder();

                foreach (var error in result.Errors)
                {
                    builder.AppendLine(error.Description);
                }

                throw new BadRequestException(builder.ToString());
            }

            return BaseResponse<CustomerResponse>.Success("User created Successful", _mapper.Map<CustomerResponse>(user), statusCode: 200);
        }
    }
}
