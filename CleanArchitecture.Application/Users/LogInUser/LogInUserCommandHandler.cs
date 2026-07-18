using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Abstractions.Authentication;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.User;

namespace CleanArchitecture.Application.Users.LogInUser;

internal sealed class LogInUserCommandHandler(IJwtService jwtService, IUserRepository userRepository)
    : ICommandHandler<LogInUserCommand, AccessTokenResponse>
{
    public async Task<Result<AccessTokenResponse>> Handle(
        LogInUserCommand request ,
        CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByEmailAsync(request.Email, cancellationToken);
        
        if (user == null || !user.VerifyPassword(request.Password))
            return Result.Failure<AccessTokenResponse>(UserErrors.InvalidCredentials);
        
        var token = jwtService.GetAccessTokenAsync(user.Id);

        return new AccessTokenResponse(token.Value);
    }
}