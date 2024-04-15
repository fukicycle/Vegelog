namespace Vegelog.Shared.Dto.Response
{
    public sealed class Vegetable
    {
        public Vegetable(Guid id, string name, string? description, string? thumbnail)
        {
            Id = id;
            Name = name;
            Description = description;
            Thumbnail = thumbnail;
        }
        public Guid Id { get; }
        public string Name { get; }
        public string? Description { get; set; }
        public string? Thumbnail { get; }
    }
}
