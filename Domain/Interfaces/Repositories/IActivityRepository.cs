using Domain.Entities.Activity;

namespace Domain.Interfaces.Repositories;

public interface IActivityRepository
{
    void Add(Activity activity);
    void Remove(Activity activity);
    Task<Activity?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<List<Activity>?> GetActivitiesOfUserAsync(long userId, CancellationToken cancellationToken = default);
    
}