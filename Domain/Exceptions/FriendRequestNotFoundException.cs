namespace Domain.Exceptions;

public class FriendRequestNotFoundException : Exception
{
    public FriendRequestNotFoundException(long id) 
        : base($"Friend request with id {id} was not found.")
    {
    }
}