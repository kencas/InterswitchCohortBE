using System.Globalization;
using Application.Presentation;
using Application.Queries;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.Users;

public class GetProductsByCategoryCodeHandler: IRequestHandler<GetProductsByCategoryCodeQuery, BaseResponse<List<ProductResponse>>>
{
    private readonly IRepositoryWrapper _repository;
    private readonly IMapper _mapper;

    public GetProductsByCategoryCodeHandler(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<BaseResponse<List<ProductResponse>>> Handle(GetProductsByCategoryCodeQuery request, CancellationToken cancellationToken)
    {
        var productData = (await _repository.Product.FindByCondition(product => product.CategoryCode == request.Code)).ToList();
        if (productData == null)
            throw new Exception("User has not done Kyc");
        
        return new BaseResponse<List<ProductResponse>>
        {
            StatusCode = 200,
            Succeeded = true,
            Message = "Success",
            Data = _mapper.Map<List<ProductResponse>>(productData)
        };
    }
}