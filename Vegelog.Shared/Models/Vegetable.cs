namespace Vegelog.Shared.Models;

public partial class Vegetable
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime RegisterDate { get; set; }

    public Guid GroupId { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();
}
