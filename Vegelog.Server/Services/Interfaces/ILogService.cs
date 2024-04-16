namespace Vegelog.Server.Services.Interfaces
{
    public interface ILogService
    {
        bool AddLog(string title, string content, string image, Guid vegetableId);
    }
}
