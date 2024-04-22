using System.Globalization;
using Application.Presentation;
using Application.Queries;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.Users;

public class GetOrderLineByNumberHandler: IRequestHandler<GetOrderLineByNumberQuery, BaseResponse<List<OrderLineResponse>>>
{
    private readonly IRepositoryWrapper _repository;
    private readonly IMapper _mapper;

    public GetOrderLineByNumberHandler(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<BaseResponse<List<OrderLineResponse>>> Handle(GetOrderLineByNumberQuery request, CancellationToken cancellationToken)
    {
        var productData = (await _repository.OrderLine.FindByCondition(orderLine => orderLine.OrderNumber == request.OrderNumber)).ToList();
        if (productData == null)
            throw new Exception("Order does not exist");
        
        return new BaseResponse<List<OrderLineResponse>>
        {
            StatusCode = 200,
            Succeeded = true,
            Message = "Success",
            Data = _mapper.Map<List<OrderLineResponse>>(productData)
        };
    }
}