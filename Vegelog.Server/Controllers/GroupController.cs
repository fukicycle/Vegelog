using Microsoft.AspNetCore.Mvc;
using Vegelog.Server.Services.Interfaces;
using Vegelog.Shared.Dto.Request;

namespace Vegelog.Server.Controllers
{
    [Route("/api/v1/groups")]
    public sealed class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        public IActionResult GetGroup(string code)
        {
            try
            {
                return Ok(_groupService.GetGroup(code));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("check")]
        [HttpGet]
        public IActionResult IsExists(string code)
        {
            try
            {
                return Ok(_groupService.IsExists(code));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult PostGroup([FromBody] GroupRequestDto groupRequestDto)
        {
            try
            {
                return Ok(_groupService.RegisterGroup(groupRequestDto.Name));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
