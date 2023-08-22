using Domain.Entities.AppUser;
using Domain.Entities.Friend;

namespace Domain.Interfaces.Repositories;

public interface IAppUserRepository
{
    void Add(AppUser user);
    void Remove(AppUser user);
    Task<AppUser?> GetByIdAsync(long id);
    Task<List<AppUser>> GetByIdsAsync(List<long> ids);
    Task<AppUser?> GetByUserNameAsync(string userName);
}