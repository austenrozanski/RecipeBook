using Application.Business.AppUsers.Get;
using Application.Business.AppUsers.Models;
using Application.Business.Friends.Create;
using Application.Business.Friends.Delete;
using Application.Business.Friends.Models;
using Application.Business.Friends.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FriendsController : ControllerBase
{
    private readonly ISender _sender;

    protected FriendsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("friend-request")]
    public async Task<ActionResult> SendFriendRequest([FromBody] FriendRequest friendRequest)
    {
        var request = new CreateFriendRequestCommand()
        {
            friendRequest = friendRequest
        };
        await _sender.Send(request);
        return Ok();
    }
    
    [HttpPut("friend-request")]
    public async Task<ActionResult> UpdateFriendRequest(long friendRequestId, [FromBody] FriendRequest friendRequest)
    {
        var request = new UpdateFriendRequestCommand()
        {
            FriendRequestId = friendRequestId,
            FriendRequest = friendRequest
        };
        await _sender.Send(request);
        return Ok();
    }
    
    [HttpDelete("friend-request")]
    public async Task<ActionResult> DeleteFriendRequest(long friendRequestId)
    {
        var request = new DeleteFriendRequestCommand()
        {
            FriendRequestId = friendRequestId
        };
        await _sender.Send(request);
        return Ok();
    }
}