using Application.Business.Friends.Models;
using MediatR;

namespace Application.Business.Friends.Update;

public class UpdateFriendRequestCommand : IRequest
{
    public long FriendRequestId { get; set; }
    public FriendRequest FriendRequest { get; set; }
}