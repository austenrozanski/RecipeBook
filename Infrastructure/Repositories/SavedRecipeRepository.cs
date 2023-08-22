using API.Data;
using Domain.Entities.SavedRecipe;
using Domain.Repositories;
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

    public Task<SavedRecipe?> GetByIdAsync(long id)
    {
        return _dataContext.SavedRecipes.FirstOrDefaultAsync(i => i.Id == id);
    }
    public Task<SavedRecipe?> GetSavedRecipeForUserAsync(long userId, long recipeId)
    {
        return _dataContext.SavedRecipes.FirstOrDefaultAsync(f => f.UserId == userId && f.RecipeId == recipeId);
    }
    public Task<List<SavedRecipe>?> GetSavedRecipesForUserAsync(long userId)
    {
        return _dataContext.SavedRecipes.Where(f => f.UserId == userId).ToListAsync();
    }
}