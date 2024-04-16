using Vegelog.Shared.Dto.Response;

namespace Vegelog.Server.Services.Interfaces
{
    public interface IGroupService
    {
        GroupResponseDto GetGroup(string code);
        string RegisterGroup(string? name);
    }
}
