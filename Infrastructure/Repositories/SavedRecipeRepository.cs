using API.Data;
using Domain.Entities.SavedRecipe;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class SavedRecipeRepository : ISavedRecipeRepository
{
    private readonly DataContext _dataContext;

    public SavedRecipeRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public void Add(SavedRecipe savedRecipe)
    {
        _dataContext.SavedRecipes.Add(savedRecipe);
    }

    public void Remove(SavedRecipe savedRecipe)
    {
        _dataContext.SavedRecipes.Remove(savedRecipe);
    }

    public Task<SavedRecipe?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        return _dataContext.SavedRecipes.FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
    }
    public Task<SavedRecipe?> GetSavedRecipeForUserAsync(long userId, long recipeId, CancellationToken cancellationToken = default)
    {
        return _dataContext.SavedRecipes.FirstOrDefaultAsync(f => f.UserId == userId && f.RecipeId == recipeId, cancellationToken);
    }
    public Task<List<SavedRecipe>?> GetSavedRecipesForUserAsync(long userId, CancellationToken cancellationToken = default)
    {
        return _dataContext.SavedRecipes.Where(f => f.UserId == userId).ToListAsync(cancellationToken);
    }
}