using EWApp.Presentation.ActionFilters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DTOs;

namespace EWApp.Presentation.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IServiceManager _services;

        public TokenController(IServiceManager services) => _services = services;

        [HttpPost("refresh")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Refresh([FromBody] TokenDto tokens)
        {
            var tokenToReturn = await _services.AuthenticationService.RefreshToken(tokens);

            HttpContext.Response.Cookies.Append("access-token", tokenToReturn.AccessToken, new CookieOptions
            {
                SameSite = SameSiteMode.None
            });
            HttpContext.Response.Cookies.Append("refresh-token", tokenToReturn.RefreshToken, new CookieOptions
            {
                SameSite = SameSiteMode.None
            });

            return Ok(tokenToReturn);
        }
    }
}
