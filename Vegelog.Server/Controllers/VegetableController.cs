using Microsoft.AspNetCore.Mvc;
using Vegelog.Server.Services.Interfaces;
using Vegelog.Shared.Dto.Request;

namespace Vegelog.Server.Controllers
{
    [Route("/api/v1/vegetables")]
    public sealed class VegetableController : ControllerBase
    {
        private readonly IVegetableService _vegetableService;

        public VegetableController(IVegetableService vegetableService)
        {
            _vegetableService = vegetableService;
        }

        [HttpPost]
        public IActionResult PostVegetable([FromBody] VegetableRequestDto vegetableRequestDto)
        {
            try
            {
                _vegetableService.AddVegetable(vegetableRequestDto.Name, vegetableRequestDto.Description, vegetableRequestDto.GroupId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
