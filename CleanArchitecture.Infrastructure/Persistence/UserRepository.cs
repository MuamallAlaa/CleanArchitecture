using CleanArchitecture.Domain.User;

namespace CleanArchitecture.Infrastructure.Persistence;

internal sealed class UserRepository(ApplicationDbContext dbContext) : Repository<User>(dbContext), IUserRepository;