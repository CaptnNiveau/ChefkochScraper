using System.ComponentModel.DataAnnotations;

public class EntityBase
{
    [Key]
    public Guid LocalId { get; private set; }
    public DateTime LocalCreatedAt { get; private set; }
    public DateTime LocalModifiedAt { get; private set; }

    public EntityBase()
    {
        LocalId = Guid.NewGuid();
        LocalCreatedAt = DateTime.UtcNow;
        LocalModifiedAt = DateTime.UtcNow;
    }

    public void OnEntityModified() => LocalModifiedAt = DateTime.UtcNow;
}