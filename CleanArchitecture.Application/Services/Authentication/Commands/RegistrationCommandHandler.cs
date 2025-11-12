using CleanArchitecture.Contracts.Authentication;
using CleanArchitecture.Contracts.Messaging;
using CleanArchitecture.Contracts.Models;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.User;

namespace CleanArchitecture.Application.Services.Authentication.Commands;

public record RegistrationCommandHandler(IUserRepository UserRepository , IUnitOfWork UnitOfWork):ICommandHandler<RegisterRequestCommand , AuthenticationResponse>
{
    public async Task<Result<AuthenticationResponse>> Handle(RegisterRequestCommand request, CancellationToken cancellationToken)
    {
        var hashedPassword = Password.Hash(request.Password);

        var newUser = User.Create(new FirstName(request.FirstName), new LastName(request.LastName), new Email(request.Email), hashedPassword);
        
        UserRepository.Add(newUser);
        await UnitOfWork.SaveChangesAsync(cancellationToken);
        
        var response = new AuthenticationResponse(
            newUser.Id, 
            newUser.FirstName.Value, 
            newUser.LastName.Value, 
            newUser.Email.Value, 
            "token");

        return response;
    }
}
