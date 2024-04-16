namespace Vegelog.Shared.Dto.Response
{
    public sealed class RegisteredGroupResponseDto
    {
        public RegisteredGroupResponseDto(string code)
        {
            Code = code;
        }

        public string Code { get; }
    }
}
