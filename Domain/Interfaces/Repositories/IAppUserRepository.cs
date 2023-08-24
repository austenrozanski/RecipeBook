using Domain.Entities.AppUser;
using Domain.Entities.Friend;

namespace Domain.Interfaces.Repositories;

public interface IAppUserRepository
{
    void Add(AppUser user);
    void Remove(AppUser user);
    Task<AppUser?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<List<AppUser>> GetByIdsAsync(List<long> ids, CancellationToken cancellationToken = default);
    Task<AppUser?> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default);
    Task<bool> IsUserNameUniqueAsync(string userName, CancellationToken cancellationToken = default);
}