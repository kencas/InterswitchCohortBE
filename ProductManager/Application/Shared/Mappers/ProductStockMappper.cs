using Application.Commands;
using Application.Presentation;
using AutoMapper;
using Domain.Aggregate;

namespace Application.Shared.Mappers
{
    public sealed class ProductStockMappper : Profile
    {
        public ProductStockMappper()
        {
            CreateMap<ProductResponse, Product>();
            CreateMap<Product, ProductResponse>();
            CreateMap<List<ProductResponse>, List<Product>>();
            CreateMap<List<Product>, List<ProductResponse>>();
            //CreateMap<UpdateStockCommand, User>();
        }
    }
}
