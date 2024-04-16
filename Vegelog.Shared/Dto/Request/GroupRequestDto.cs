namespace Vegelog.Shared.Dto.Request
{
    public sealed class GroupRequestDto
    {
        public GroupRequestDto(string? name)
        {
            Name = name;
        }

        public string? Name { get; }
    }
}
