﻿using Microsoft.Identity.Client;
using System.Text;
using Vegelog.Server.Services.Interfaces;
using Vegelog.Shared;
using Vegelog.Shared.Dto.Response;
using Vegelog.Shared.Models;

namespace Vegelog.Server.Services
{
    public sealed class GroupService : IGroupService
    {
        private readonly DB _db;
        private readonly ILogger<GroupService> _logger;

        public GroupService(DB db, ILogger<GroupService> logger)
        {
            _db = db;
            _logger = logger;
        }

        public GroupResponseDto GetGroup(string code)
        {
            Group? group = _db.Groups.FirstOrDefault(a => a.Code == code);
            if (group == default)
            {
                _logger.LogWarning($"No such code:{code}");
                throw new Exception($"No such code:{code}");
            }
            List<Vegetable> vegetables = _db.Vegetables.Where(a => a.GroupId == group.Id).ToList();
            List<VegetableResponseDto> vegetableResponseDtos = new List<VegetableResponseDto>();
            foreach (var vegetable in vegetables)
            {
                Log? log = _db.Logs.OrderByDescending(a => a.DateTime).FirstOrDefault(a => a.VegetableId == vegetable.Id);
                VegetableResponseDto vegetableResponseDto = new VegetableResponseDto(vegetable.Id, vegetable.Name, vegetable.Description, log?.ImagePath);
                vegetableResponseDtos.Add(vegetableResponseDto);
            }
            return new GroupResponseDto(group.Id, group.Code, vegetableResponseDtos);
        }

        public GroupCheckResponseDto IsExists(string code)
        {
            Group? group = _db.Groups.FirstOrDefault(a => a.Code == code);
            return new GroupCheckResponseDto(group?.Code, group != null);
        }

        public RegisteredGroupResponseDto RegisterGroup(string? name)
        {
            Group group = new Group
            {
                Id = Guid.NewGuid(),
                DisplayName = name,
                Code = CodeGenerator.Run()
            };
            _db.Groups.Add(group);
            _db.SaveChanges();
            return new RegisteredGroupResponseDto(group.Code);
        }
    }
}
