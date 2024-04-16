using Microsoft.AspNetCore.Mvc;
using Vegelog.Server.Services.Interfaces;
using Vegelog.Shared.Dto.Request;

namespace Vegelog.Server.Controllers
{
    [Route("/api/v1/logs")]
    public sealed class LogController : ControllerBase
    {
        private readonly ILogService _logService;

        public LogController(ILogService logService)
        {
            _logService = logService;
        }

        [HttpPost]
        public IActionResult PostLog([FromBody] LogRequestDto logRequestDto)
        {
            try
            {
                bool result = _logService.AddLog(logRequestDto.Title, logRequestDto.Content, logRequestDto.Image, logRequestDto.VegetableId);
                if (result)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
