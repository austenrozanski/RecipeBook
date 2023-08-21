namespace Domain.Entities.Recipe;

public class RecipeInstructionGroup
{
    public string? Name { get; set; }
    public List<RecipeInstruction> Instructions { get; set; }
}