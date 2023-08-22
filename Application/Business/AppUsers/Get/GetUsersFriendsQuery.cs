using Application.Business.AppUsers.Models;
using MediatR;

namespace Application.Business.AppUsers.Get;

public class GetUsersFriendsQuery : IRequest<IEnumerable<UserSummaryResponse>>
{
    public long UserId { get; set; }
}