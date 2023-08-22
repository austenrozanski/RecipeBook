using Domain.Entities.AppUser;

namespace Application.Business.AppUsers.Models;

public class UserSummaryResponse
{
    public int Id { get; set; }
    public string UserName { get; set; }

    public UserSummaryResponse(AppUser user)
    {
        Id = user.Id;
        UserName = user.UserName;
    }
}