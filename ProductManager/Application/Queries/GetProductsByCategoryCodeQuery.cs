using Application.Presentation;
using MediatR;

namespace Application.Queries;

public record GetProductsByCategoryCodeQuery(string Code) : IRequest<BaseResponse<List<ProductResponse>>>;