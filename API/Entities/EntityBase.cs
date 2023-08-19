namespace API.Entities;

public class EntityBase
{
    public long Id { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public int CreatedBy { get; set; }
    public bool IsDeleted { get; set; }
    public int LastModifiedBy { get; set; }
}