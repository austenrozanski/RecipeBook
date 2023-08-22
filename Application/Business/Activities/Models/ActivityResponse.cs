using Domain.Entities.Activity;

namespace Application.Business.Activities.Models;

public class ActivityResponse
{
    public long Id { get; set; }
    public long RecipeId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<string> PhotoUrls { get; set; }
    public int Rating { get; set; }
    public DateTime StartTime { get; set; }

    public ActivityResponse(Activity activity)
    {
        Id = activity.Id;
        RecipeId = activity.RecipeId;
        Title = activity.Title;
        Description = activity.Description;
        PhotoUrls = activity.PhotoUrls;
        Rating = activity.Rating;
        StartTime = activity.StartTime;
    }
}