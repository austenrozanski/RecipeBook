namespace Domain.Entities.Friend;

public class Friend
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long FriendId { get; set; }
    public bool IsPending { get; set; }
    public DateTime SentDate { get; set; }
    public DateTime AcceptedDate { get; set; }
    public bool IsDeleted { get; set; }
}