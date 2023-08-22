using Domain.Entities.Friend;

namespace Application.Business.Friends.Models;

public class FriendRequest
{
    public long UserId { get; set; }
    public long FriendId { get; set; }
    public bool IsPending { get; set; }
    public DateTime SentDate { get; set; }
    public DateTime AcceptedDate { get; set; }
    public bool IsDeleted { get; set; }

    public Friend ToFriendEntity()
    {
        var friend = new Friend()
        {
            UserId = this.UserId,
            FriendId = this.FriendId,
            IsPending = this.IsPending,
            SentDate = this.SentDate,
            AcceptedDate = this.AcceptedDate,
            IsDeleted = this.IsDeleted
        };
        return friend;
    }
}