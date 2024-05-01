using Vegelog.Shared.Dto.Response;

namespace Vegelog.Server.Services.Interfaces
{
    public interface ILogService
    {
        bool AddLog(string title, string content, string? image, Guid vegetableId);
        IEnumerable<VegetableLogResponseDto> GetLogs(Guid vegetableId);
    }
}
