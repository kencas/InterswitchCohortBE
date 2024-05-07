using Application.Commands;
using Application.Presentation;
using AutoMapper;
using Domain.Aggregate;
using Domain.Entities;

namespace Application.Shared.Mappers
{
    public sealed class CustomerMappper : Profile
    {
        public CustomerMappper()
        {
            CreateMap<CustomerResponse, User>();
            CreateMap<User, CustomerResponse>();
            CreateMap<CreateUserCommand, User>();
            CreateMap<List<SetupResponse>, List<Setup>>();
            CreateMap<List<Setup>, List<SetupResponse>>();
        }
    }
}
