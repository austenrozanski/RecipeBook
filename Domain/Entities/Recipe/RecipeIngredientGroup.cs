namespace Domain.Entities.Recipe;

public class RecipeIngredientGroup
{
    public string? Name { get; set; }
    public List<RecipeIngredient> Ingredients { get; set; }
}