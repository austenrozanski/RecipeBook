namespace Domain.Entities.SavedRecipe;

public class SavedRecipe
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long RecipeId { get; set; }
    public bool IsHearted { get; set; }
}