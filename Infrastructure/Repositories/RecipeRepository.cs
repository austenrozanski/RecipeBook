using API.Data;
using Domain.Entities.Recipe;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class RecipeRepository : IRecipeRepository
{
    private readonly DataContext _dataContext;

    public RecipeRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public void Add(Recipe recipe)
    {
        _dataContext.Recipes.Add(recipe);
    }

    public void Remove(Recipe recipe)
    {
        _dataContext.Recipes.Remove(recipe);
    }

    public Task<Recipe?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        return _dataContext.Recipes.FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
    }

    public Task<List<Recipe>> GetByIdsAsync(List<long> ids, CancellationToken cancellationToken = default)
    {
        return _dataContext.Recipes
            .Where(f => ids.Contains(f.Id))
            .ToListAsync(cancellationToken);
    }

    public Task<List<Recipe>> GetSummariesAsync(CancellationToken cancellationToken = default)
    {
        // TODO: Only return summary data
        // TODO: Add filtering and ordering
        return _dataContext.Recipes.ToListAsync(cancellationToken);
    }
}