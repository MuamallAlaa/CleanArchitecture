using CleanArchitecture.Contracts.Models;
using MediatR;

namespace CleanArchitecture.Contracts.Messaging;

public interface ICommand : IRequest<Result>, IBaseCommand
{
}

public interface ICommand<TReponse> : IRequest<Result<TReponse>>, IBaseCommand
{
}

public interface IBaseCommand
{
}