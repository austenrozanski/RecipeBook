using API.Data;
using Domain.Entities.Activity;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ActivityRepository : IActivityRepository
{
    private readonly DataContext _dataContext;

    public ActivityRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public void Add(Activity activity)
    {
        _dataContext.Activities.Add(activity);
    }

    public void Remove(Activity activity)
    {
        _dataContext.Activities.Remove(activity);
    }

    public Task<Activity?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        return _dataContext.Activities.FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
    }

    public Task<List<Activity>> GetActivitiesOfUserAsync(long userId, CancellationToken cancellationToken = default)
    {
        return _dataContext.Activities.Where(f => f.CreatedBy == userId).ToListAsync(cancellationToken);
    }
}