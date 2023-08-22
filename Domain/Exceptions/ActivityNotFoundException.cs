namespace Domain.Exceptions;

public class ActivityNotFoundException : Exception
{
    public ActivityNotFoundException(long activityId)
    : base($"Activity with id {activityId} was not found.")
    {
    }
}