using CleanArchitecture.Application.Abstractions.Messaging;
namespace CleanArchitecture.Application.Users.RegisterUser;

public sealed record RegisterUserCommand(
        string Email,
        string FirstName,
        string LastName,
        string Password) : ICommand<Guid>;