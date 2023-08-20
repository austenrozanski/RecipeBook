using Domain.Entities.Recipe;

namespace Domain.Repositories;

public interface IRecipeRepository
{
    void Add(Recipe recipe);
    void Remove(Recipe recipe);
    Task<Recipe?> GetByIdAsync(int id);
    Task<List<Recipe>> GetSummaries();
}