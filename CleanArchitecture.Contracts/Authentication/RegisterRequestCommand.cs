using CleanArchitecture.Contracts.Messaging;

namespace CleanArchitecture.Contracts.Authentication;

public record RegisterRequestCommand(string FirstName , string LastName, string Email , string Password):ICommand<AuthenticationResponse>;