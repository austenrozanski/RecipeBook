using Domain.Entities.AppUser;

namespace Application.Business.AppUsers.Models;

public class UserResponse
{
    public int Id { get; set; }
    public string UserName { get; set; }

    public UserResponse(AppUser user)
    {
        Id = user.Id;
        UserName = user.UserName;
    }
}