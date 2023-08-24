using Domain.Entities.AppUser;
using Domain.Entities.Friend;

namespace Domain.Interfaces.Repositories;

public interface IFriendRepository
{
    void Add(Friend friend);
    void Remove(Friend friend);
    Task<Friend?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<List<Friend>?> GetPendingFriendsOfUserAsync(long userId, CancellationToken cancellationToken = default);
    Task<List<Friend>?> GetFriendsOfUserAsync(long userId, CancellationToken cancellationToken = default);
}