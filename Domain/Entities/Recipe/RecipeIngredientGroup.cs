namespace Domain.Entities.Recipe;

public class RecipeIngredientGroup
{
    public List<RecipeIngredient> Ingredients { get; set; }
    public string? Name { get; set; }
}