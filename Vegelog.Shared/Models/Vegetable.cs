namespace Vegelog.Shared.Models
{
    public sealed class Vegetable
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Thumbnail { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
