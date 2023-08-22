using Domain.Entities.Activity;

namespace Application.Business.Activities.Models;

public class ActivityRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public List<string> PhotoUrls { get; set; }
    public int Rating { get; set; }
    public DateTime StartTime { get; set; }

    public Activity ToActivityEntity()
    {
        var activity = new Activity()
        {
            Title = this.Title,
            Description = this.Description,
            PhotoUrls = this.PhotoUrls,
            Rating = this.Rating,
            StartTime = this.StartTime
        };

        return activity;
    }
}