using Domain.Entities.AppUser;

namespace Application.Business.AppUsers.Models;

public class UserRequest
{
    public string UserName { get; set; }

    public AppUser ToUserEntity()
    {
        return new AppUser()
        {
            UserName = this.UserName
        };
    }
}