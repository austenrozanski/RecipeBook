namespace Domain.Exceptions;

public class UserNameAlreadyExistsException : Exception
{
    public UserNameAlreadyExistsException() 
        : base($"A user with this username already exists.")
    {
    }
}