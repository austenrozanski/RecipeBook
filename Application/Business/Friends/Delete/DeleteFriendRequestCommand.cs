using MediatR;

namespace Application.Business.Friends.Delete;

public class DeleteFriendRequestCommand : IRequest
{
    public long FriendRequestId { get; set; }
}