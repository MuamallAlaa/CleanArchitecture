namespace CleanArchitecture.Domain.User;

public interface IUserRepository
{
     Task<User?> GetByIdAsync(UserId id, CancellationToken cancellationToken = default);
     Task<User?> GetEmailAsync(Email email, CancellationToken cancellationToken = default);


    void Add(User user);
}