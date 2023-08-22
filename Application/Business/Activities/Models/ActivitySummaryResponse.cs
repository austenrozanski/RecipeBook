namespace Application.Business.Activities.Models;

public class ActivitySummaryResponse
{
    public long Id { get; set; }
    public long RecipeId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Rating { get; set; }
    public DateTime StartTime { get; set; }
}