namespace CleanArchitecture.Domain.User;

public record UserId(Guid Value)
{
    public static UserId New() => new(Guid.NewGuid());
}