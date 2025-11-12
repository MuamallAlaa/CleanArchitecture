namespace CleanArchitecture.Domain.User;

public sealed record Password
{
    public string Value { get; }

    private Password(string value) // ← Private!
    {
        Value = value;
    }

    public static Password Hash(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Password cannot be null or empty", nameof(value));
        }
        
        var hashedValue = BCrypt.Net.BCrypt.HashPassword(value);
        return new Password(hashedValue);
    }
    public static Password FromHash(string value) => new Password(value);

    public bool Verify(string value)
    {
        return BCrypt.Net.BCrypt.Verify(value, Value);
    }
}