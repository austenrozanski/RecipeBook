using Domain.Entities.SavedRecipe;

namespace Domain.Interfaces.Repositories;

public interface ISavedRecipeRepository
{
    void Add(SavedRecipe savedRecipe);
    void Remove(SavedRecipe savedRecipe);
    Task<SavedRecipe?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<SavedRecipe?> GetSavedRecipeForUserAsync(long userId, long recipeId, CancellationToken cancellationToken = default);
    Task<List<SavedRecipe>?> GetSavedRecipesForUserAsync(long userId, CancellationToken cancellationToken = default);
}