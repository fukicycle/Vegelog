using Vegelog.Server.Services.Interfaces;
using Vegelog.Shared.Models;

namespace Vegelog.Server.Services
{
    public sealed class VegetableService : IVegetableService
    {
        private readonly DB _db;
        private readonly ILogger<VegetableService> _logger;

        public VegetableService(DB db, ILogger<VegetableService> logger)
        {
            _db = db;
            _logger = logger;
        }

        public void AddVegetable(string name, string? description, string code)
        {
            Group? group = _db.Groups.FirstOrDefault(a => a.Code == code);
            if (group == null)
            {
                _logger.LogWarning($"No such group code:{code}");
                throw new Exception($"No such group code: {code}");
            }
            Vegetable vegetable = new Vegetable
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                RegisterDate = DateTime.Now,
                GroupId = group.Id
            };
            _db.SaveChanges();
            _logger.LogInformation($"Vegetable added.:{vegetable.Id}");
        }
    }
}
