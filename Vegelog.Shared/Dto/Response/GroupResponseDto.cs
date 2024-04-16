namespace Vegelog.Shared.Dto.Response
{
    public sealed class GroupResponseDto
    {
        public GroupResponseDto(Guid id, string code, List<VegetableResponseDto> vegetables)
        {
            Id = id;
            Code = code;
            Vegetables = vegetables;
        }

        public Guid Id { get; }
        public string Code { get; }
        public List<VegetableResponseDto> Vegetables { get; }
    }
}
