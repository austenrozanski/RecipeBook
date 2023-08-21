namespace Domain.Exceptions;

public class RecipeNotFoundException : Exception
{
    public RecipeNotFoundException(long recipeId)
    : base($"Recipe with id {recipeId} was not found.")
    {
    }
}