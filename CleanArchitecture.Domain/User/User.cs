using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.User;

public sealed class User : Entity
{
    private User(Guid id, FirstName firstName, LastName lastName, Email email , Password password)
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
        var user = new User(Guid.NewGuid(), firstName, lastName, email,password);
        
        return user;
    }
}