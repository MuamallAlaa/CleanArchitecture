
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.User;

namespace CleanArchitecture.Application.Abstractions.Authentication;

public interface IJwtService
{
    Result<string> GetAccessTokenAsync(UserId id);
}