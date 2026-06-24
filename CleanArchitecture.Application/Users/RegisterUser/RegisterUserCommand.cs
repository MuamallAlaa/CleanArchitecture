using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Abstractions;

namespace CleanArchitecture.Application.Users.RegisterUser;

public sealed record RegisterUserCommand(
        string Email,
        string FirstName,
        string LastName,
        string Password) : ICommand<Guid>;