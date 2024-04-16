namespace Vegelog.Shared.Dto.Response
{
    public sealed class GroupCheckResponseDto
    {
        public GroupCheckResponseDto(string? code, bool isExists)
        {
            Code = code;
            IsExists = isExists;
        }
        public string? Code { get; }
        public bool IsExists { get; }
    }
}
