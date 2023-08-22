namespace Domain.Entities.Activity;

public class Activity : EntityBase
{
    public long RecipeId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<string> PhotoUrls { get; set; }
    public int Rating { get; set; }
    public DateTime StartTime { get; set; }
}