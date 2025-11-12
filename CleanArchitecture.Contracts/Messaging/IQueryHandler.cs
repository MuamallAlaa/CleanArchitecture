using CleanArchitecture.Contracts.Models;
using MediatR;

namespace CleanArchitecture.Contracts.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}