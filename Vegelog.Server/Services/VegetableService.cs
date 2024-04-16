﻿using Vegelog.Server.Services.Interfaces;
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

        public void AddVegetable(string name, string? description, Guid groupId)
        {
            if (!_db.Groups.Any(a => a.Id == groupId))
            {
                _logger.LogWarning($"No such group:{groupId}");
                throw new Exception($"No such group:{groupId}");
            }
            Vegetable vegetable = new Vegetable
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                RegisterDate = DateTime.Now,
                GroupId = groupId
            };
            _db.SaveChanges();
            _logger.LogInformation($"Vegetable added.:{vegetable.Id}");
        }
    }
}
