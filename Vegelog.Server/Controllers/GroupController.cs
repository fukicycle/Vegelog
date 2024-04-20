using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using Vegelog.Server.Services;
using Vegelog.Server.Services.Interfaces;
using Vegelog.Shared.Dto.Request;
using Vegelog.Shared.Dto.Response;
using Vegelog.Shared.Models;

namespace Vegelog.Server.Controllers
{
    [Route("/api/v1/groups")]
    public sealed class GroupController : ControllerBase
    {
        private static string _tmpCode = Guid.NewGuid().ToString();
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        [Route("login")]
        [Authorize]
        [AllowAnonymous]
        public async Task<IActionResult> Get(string code)
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                code = User.Identity?.Name ?? "";
            }
            GroupCheckResponseDto checkResult = _groupService.IsExists(code);
            if (checkResult.IsExists)
            {
                ClaimsIdentity ci = new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, code),
                    new Claim(ClaimTypes.Name,code),
                    new Claim(ClaimTypes.Role,"User")
                }, "Cookie");
                ClaimsPrincipal cp = new ClaimsPrincipal(ci);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, cp);
                return Ok(code);
            }
            else
            {
                ClaimsIdentity ci = new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,_tmpCode),
                    new Claim(ClaimTypes.Name,_tmpCode),
                    new Claim(ClaimTypes.Role,"Guest")
                }, "Cookie");
                ClaimsPrincipal cp = new ClaimsPrincipal(ci);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, cp);
                return Ok("NaN");
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetGroup()
        {
            try
            {
                string code = User.Claims.Single(a => a.Type == ClaimTypes.NameIdentifier).Value;
                return Ok(_groupService.GetGroup(code));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize]
        [Route("check")]
        [HttpGet]
        public async Task<IActionResult> IsExists(string code)
        {
            try
            {
                GroupCheckResponseDto result = _groupService.IsExists(code);
                if (result.IsExists)
                {
                    ClaimsIdentity ci = new ClaimsIdentity(new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, code),
                        new Claim(ClaimTypes.Name,code),
                        new Claim(ClaimTypes.Role,"User")
                    }, "Cookie");
                    ClaimsPrincipal cp = new ClaimsPrincipal(ci);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, cp);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostGroup([FromBody] GroupRequestDto groupRequestDto)
        {
            try
            {
                string tmpCode = User.Claims.Single(a => a.Type == ClaimTypes.NameIdentifier).Value;
                if (tmpCode != _tmpCode)
                {
                    return StatusCode(403);
                }
                RegisteredGroupResponseDto registeredGroupResponseDto = _groupService.RegisterGroup(groupRequestDto.Name);
                ClaimsIdentity ci = new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, registeredGroupResponseDto.Code),
                    new Claim(ClaimTypes.Name,registeredGroupResponseDto.Code),
                    new Claim(ClaimTypes.Role,"User")
                }, "Cookie");
                ClaimsPrincipal cp = new ClaimsPrincipal(ci);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, cp);
                _tmpCode = Guid.NewGuid().ToString();
                return Ok(registeredGroupResponseDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
