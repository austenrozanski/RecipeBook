using Domain.Entities.Recipe;

namespace Domain.Interfaces.Repositories;

public interface IRecipeRepository
{
    void Add(Recipe recipe);
    void Remove(Recipe recipe);
    Task<Recipe?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<List<Recipe>> GetByIdsAsync(List<long> ids, CancellationToken cancellationToken = default);
    Task<List<Recipe>> GetSummariesAsync(CancellationToken cancellationToken = default);
}