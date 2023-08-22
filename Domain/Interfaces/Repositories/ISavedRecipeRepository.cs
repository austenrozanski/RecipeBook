using Domain.Entities.SavedRecipe;

namespace Domain.Interfaces.Repositories;

public interface ISavedRecipeRepository
{
    void Add(SavedRecipe savedRecipe);
    void Remove(SavedRecipe savedRecipe);
    Task<SavedRecipe?> GetByIdAsync(long id);
    Task<SavedRecipe?> GetSavedRecipeForUserAsync(long userId, long recipeId);
    Task<List<SavedRecipe>?> GetSavedRecipesForUserAsync(long userId);
}