using Vegelog.Shared.Dto.Response;

namespace Vegelog.Server.Services.Interfaces
{
    public interface IGroupService
    {
        GroupResponseDto GetGroup(string code);
        RegisteredGroupResponseDto RegisterGroup(string? name);
        GroupCheckResponseDto IsExists(string code);
    }
}
