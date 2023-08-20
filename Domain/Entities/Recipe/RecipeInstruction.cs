namespace Domain.Entities.Recipe;

public class RecipeInstruction
{
    public string Description { get; set; }
    public List<RecipeTimer> Timers { get; set; }
}