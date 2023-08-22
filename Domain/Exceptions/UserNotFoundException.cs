namespace Domain.Exceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException(long userId) 
        : base($"User with id {userId} was not found.")
    {
    }
}