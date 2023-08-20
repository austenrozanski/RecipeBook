namespace Domain.Entities.Recipe;

public class RecipeInstructionGroup
{
    public List<RecipeInstruction> Instructions { get; set; }
    public string? Name { get; set; }
}