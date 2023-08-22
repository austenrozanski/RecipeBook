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

    public Task<AppUser?> GetByIdAsync(long id)
    {
        return _dataContext.Users.FirstOrDefaultAsync(i => i.Id == id);
    }

    public Task<List<AppUser>> GetByIdsAsync(List<long> ids)
    {
        return _dataContext.Users
            .Where(f => ids.Contains(f.Id))
            .ToListAsync();
    }

    public Task<AppUser?> GetByUserNameAsync(string userName)
    {
        return _dataContext.Users
            .FirstOrDefaultAsync(f => f.UserName == userName);
    }
}