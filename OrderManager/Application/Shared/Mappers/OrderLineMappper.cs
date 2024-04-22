using Application.Commands;
using Application.Presentation;
using AutoMapper;
using Domain.Aggregate;

namespace Application.Shared.Mappers
{
    public sealed class OrderLineMappper : Profile
    {
        public OrderLineMappper()
        {
            //CreateMap<OrderLineResponse, Product>();
            //CreateMap<Product, OrderLineResponse>();
            //CreateMap<List<OrderLineResponse>, List<Product>>();
            //CreateMap<List<Product>, List<OrderLineResponse>>();
            //CreateMap<UpdateStockCommand, User>();
        }
    }
}
