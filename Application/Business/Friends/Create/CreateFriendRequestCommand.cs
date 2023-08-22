using Application.Business.Friends.Models;
using MediatR;

namespace Application.Business.Friends.Create;

public class CreateFriendRequestCommand : IRequest
{
    public FriendRequest friendRequest { get; set; }
}