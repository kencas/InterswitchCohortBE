using Application.Commands;
using Application.Presentation;
using AutoMapper;
using Domain.Aggregate;

namespace Application.Shared.Mappers
{
    public sealed class CustomerMappper : Profile
    {
        public CustomerMappper()
        {
            CreateMap<CustomerResponse, User>();
            CreateMap<User, CustomerResponse>();
            CreateMap<CreateUserCommand, User>();
        }
    }
}
