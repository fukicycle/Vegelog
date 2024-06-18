using Vegelog.Server.Services.Interfaces;
using Vegelog.Shared.Dto.Response;
using Vegelog.Shared.Models;

namespace Vegelog.Server.Services
{
    public sealed class LogService : ILogService
    {
        private readonly DB _db;
        private readonly ILogger<LogService> _logger;
        private readonly IConfiguration _configuration;

        public LogService(DB db, ILogger<LogService> logger, IConfiguration configuration)
        {
            _db = db;
            _logger = logger;
            _configuration = configuration;
        }

        public bool AddLog(string title, string content, string? image, Guid vegetableId)
        {
            string? fileName = null;
            byte[]? bytes = null;
            if (image != null)
            {
                bytes = Convert.FromBase64String(image);
                string? saveDir = _configuration.GetValue<string>("ImageSavePath");
                if (saveDir == null)
                {
                    throw new ArgumentNullException(nameof(saveDir));
                }
                fileName = Guid.NewGuid().ToString() + ".png";
                string fullPath = Path.Combine(saveDir, fileName);
                File.WriteAllBytes(fullPath, bytes);
            }
            Log log = new Log
            {
                Id = Guid.NewGuid(),
                Title = title,
                Content = content,
                DateTime = DateTime.Now,
                ImagePath = fileName,
                VegetableId = vegetableId
            };
            _db.Logs.Add(log);
            int count = _db.SaveChanges();
            return count > 0;
        }

        public IEnumerable<VegetableLogResponseDto> GetLogs(Guid vegetableId)
        {
            List<Log> logs = _db.Logs.Where(a => a.VegetableId == vegetableId).ToList();
            foreach (Log log in logs)
            {
                yield return new VegetableLogResponseDto(log.ImagePath, log.Content, log.Title, log.DateTime);
            }
        }
    }
}
