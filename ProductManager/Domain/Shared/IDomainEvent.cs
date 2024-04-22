using MediatR;
using System;

namespace Domain.Shared
{
    public interface IDomainEvent : INotification
    {
        DateTime OccurredOn { get; }
    }
}