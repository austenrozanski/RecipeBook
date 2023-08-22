namespace Domain.Exceptions;

public class SavedRecipeNotFoundException : Exception
{
    public SavedRecipeNotFoundException(long recipeId) 
        : base($"Saved recipe for recipe id {recipeId} was not found.")
    {
    }
}