using API.Data;
using Domain.Entities.AppUser;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AppUserRepository : IAppUserRepository
{
    private readonly DataContext _dataContext;

    public AppUserRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public void Add(AppUser user)
    {
        _dataContext.Users.Add(user);
    }

    public void Remove(AppUser user)
    {
        _dataContext.Users.Remove(user);
    }

    public Task<AppUser?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        return _dataContext.Users.FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
    }

    public Task<List<AppUser>> GetByIdsAsync(List<long> ids, CancellationToken cancellationToken = default)
    {
        return _dataContext.Users
            .Where(f => ids.Contains(f.Id))
            .ToListAsync(cancellationToken);
    }

    public Task<AppUser?> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default)
    {
        return _dataContext.Users
            .FirstOrDefaultAsync(f => f.UserName == userName, cancellationToken);
    }

    public Task<bool> IsUserNameUniqueAsync(string userName, CancellationToken cancellationToken = default)
    {
        return _dataContext.Users.AnyAsync(f => f.UserName == userName, cancellationToken);
    }
}