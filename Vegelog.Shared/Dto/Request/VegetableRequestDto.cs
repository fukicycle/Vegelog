namespace Vegelog.Shared.Dto.Request
{
    public sealed class VegetableRequestDto
    {
        public VegetableRequestDto(string name, string? description, string code)
        {
            Name = name;
            Description = description;
            Code = code;
        }

        public string Name { get; }
        public string? Description { get; }
        public string Code { get; }
    }
}
