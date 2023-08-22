using Domain.Entities.AppUser;

namespace Application.Interfaces.Services;

public interface IJwtService
{
    string Generate(AppUser user);
}