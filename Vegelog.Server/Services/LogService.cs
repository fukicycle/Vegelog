using Vegelog.Server.Services.Interfaces;
using Vegelog.Shared.Models;

namespace Vegelog.Server.Services
{
    public sealed class LogService : ILogService
    {
        private readonly DB _db;
        private readonly ILogger<LogService> _logger;

        public LogService(DB db, ILogger<LogService> logger)
        {
            _db = db;
            _logger = logger;
        }

        public bool AddLog(string title, string content, string? image, Guid vegetableId)
        {
            byte[]? bytes = null;
            if (image != null)
            {
                bytes = Convert.FromBase64String(image);
            }
            Log log = new Log
            {
                Id = Guid.NewGuid(),
                Title = title,
                Content = content,
                DateTime = DateTime.Now,
                Image = bytes,
                VegetableId = vegetableId
            };
            _db.Logs.Add(log);
            int count = _db.SaveChanges();
            return count > 0;
        }
    }
}
