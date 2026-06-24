using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.User;

public sealed class User : Entity<UserId>
{
    private User(UserId id, FirstName firstName, LastName lastName, Email email , Password password)
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email; 
        Password = password;
    }

    private User()
    {
    }

    public FirstName FirstName { get; private set; }

    public LastName LastName { get; private set; }

    public Email Email { get; private set; }
    public Password Password { get; private set; }

    public static User Create(FirstName firstName, LastName lastName, Email email,Password password)
    {
        var user = new User(UserId.New(), firstName, lastName, email,password);
        
        return user;
    }
    public bool VerifyPassword(string plainTextPassword)
    {
        return Password.Verify(plainTextPassword);
    }
}