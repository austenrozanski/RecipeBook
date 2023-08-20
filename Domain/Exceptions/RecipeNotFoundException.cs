namespace Domain.Exceptions;

public class RecipeNotFoundException : Exception
{
    public RecipeNotFoundException(int recipeId)
    : base($"Recipe with id {recipeId} was not found.")
    {
    }
}