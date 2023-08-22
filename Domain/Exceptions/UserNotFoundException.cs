namespace Domain.Exceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException(long userId) 
        : base($"User with id {userId} was not found.")
    {
    }
    
    public UserNotFoundException(string userName) 
        : base($"User {userName} was not found.")
    {
    }
}