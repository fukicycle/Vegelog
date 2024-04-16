namespace Vegelog.Shared.Models;

public partial class Group
{
    public Guid Id { get; set; }

    public string Code { get; set; } = null!;

    public string? DisplayName { get; set; }

    public virtual ICollection<Vegetable> Vegetables { get; set; } = new List<Vegetable>();
}
