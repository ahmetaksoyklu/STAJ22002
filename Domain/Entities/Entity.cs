namespace Domain.Entities;

public abstract class Entity<TId> : IEntityTimeStamp
{
    public TId Id { get; set; } = default!;
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
