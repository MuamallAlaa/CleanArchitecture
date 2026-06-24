namespace CleanArchitecture.Domain.User;

public record LastName(string Value)
{
    public static implicit operator LastName(string value) => new(value);
    public static implicit operator string(LastName lastName) => lastName.Value;
}