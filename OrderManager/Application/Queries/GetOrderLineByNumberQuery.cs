using Application.Presentation;
using MediatR;

namespace Application.Queries;

public record GetOrderLineByNumberQuery(string OrderNumber) : IRequest<BaseResponse<List<OrderLineResponse>>>;