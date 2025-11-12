using CleanArchitecture.Contracts.Models;
using MediatR;

namespace CleanArchitecture.Contracts.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}