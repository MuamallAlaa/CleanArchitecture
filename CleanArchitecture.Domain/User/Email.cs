namespace CleanArchitecture.Domain.User;

public sealed record Email(string Value)
{
    public static implicit operator Email(string value) => new(value);
    public static implicit operator string(Email email) => email.Value;
};