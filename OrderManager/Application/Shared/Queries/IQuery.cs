using MediatR;

namespace Application.Shared.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {

    }
}