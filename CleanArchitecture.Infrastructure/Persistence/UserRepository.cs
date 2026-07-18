using CleanArchitecture.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Persistence;

internal sealed class UserRepository(ApplicationDbContext dbContext) : Repository<User, UserId>(dbContext), IUserRepository
{
    public async Task<User?> GetByEmailAsync(Email email, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<User>().FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }
}