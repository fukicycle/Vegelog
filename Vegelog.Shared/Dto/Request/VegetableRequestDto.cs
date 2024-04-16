namespace Vegelog.Shared.Dto.Request
{
    public sealed class VegetableRequestDto
    {
        public VegetableRequestDto(string name, string? description, Guid groupId)
        {
            Name = name;
            Description = description;
            GroupId = groupId;
        }

        public string Name { get; }
        public string? Description { get; }
        public Guid GroupId { get; }
    }
}
