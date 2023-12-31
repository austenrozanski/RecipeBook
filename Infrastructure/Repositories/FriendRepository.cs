using API.Data;
using Domain.Entities.Friend;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class FriendRepository : IFriendRepository
{
    private readonly DataContext _dataContext;

    public FriendRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public void Add(Friend friend)
    {
        _dataContext.Friends.Add(friend);
    }

    public void Remove(Friend friend)
    {
        _dataContext.Friends.Remove(friend);
    }

    public Task<Friend?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        return _dataContext.Friends.FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
    }

    public Task<List<Friend>?> GetPendingFriendsOfUserAsync(long userId, CancellationToken cancellationToken = default)
    {
        return _dataContext.Friends.Where(f => f.UserId == userId && f.IsPending).ToListAsync(cancellationToken);
    }

    public Task<List<Friend>?> GetFriendsOfUserAsync(long userId, CancellationToken cancellationToken = default)
    {
        return _dataContext.Friends.Where(f => f.UserId == userId && !f.IsPending).ToListAsync(cancellationToken);
    }
}