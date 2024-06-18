namespace Vegelog.Shared.Models;

public partial class Log
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime DateTime { get; set; }

    public byte[]? Image { get; set; }
    public string? ImagePath { get; set; }

    public Guid VegetableId { get; set; }

    public virtual Vegetable Vegetable { get; set; } = null!;
}
