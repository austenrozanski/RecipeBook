namespace API.Entities.Recipe;

public class RecipeIngredient
{
    public string Name { get; set; }
    public int? Quantity { get; set; }
    public string QuantityType { get; set; }
}