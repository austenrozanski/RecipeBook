using Domain.Entities.Recipe;

namespace Domain.Repositories;

public interface IRecipeRepository
{
    void Add(Recipe recipe);
    void Remove(Recipe recipe);
    Task<Recipe?> GetByIdAsync(long id);
    Task<List<Recipe>> GetByIdsAsync(List<long> ids);
    Task<List<Recipe>> GetSummariesAsync();
}