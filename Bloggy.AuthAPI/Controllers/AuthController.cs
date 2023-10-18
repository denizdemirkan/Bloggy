using Bloggy.Core.DTOs;
using Bloggy.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bloggy.AuthAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : CustomBaseController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        // Working
        public async Task<IActionResult> CreateTokenAsync(LoginDto loginDto)
        {
            var results = await _authenticationService.CreateTokenAsync(loginDto);
            return ActionResultInstance(results);
        }

        [HttpPost]
        // IDK
        public IActionResult CreateTokenByNonUser(NonUserLoginDto nonUserLoginDto)
        {
            var results = _authenticationService.CreateTokenByNonUser(nonUserLoginDto);
            return ActionResultInstance(results);
        }


        [HttpPost]
        // Not Working
        public async Task<IActionResult> CreateTokenByRefreshTokenAsync(RefreshTokenDto refreshToken)
        {
            var results = await _authenticationService.CreateTokenByRefreshTokenAsync(refreshToken.Token);
            return ActionResultInstance(results);
        }


        [HttpPost]
        public async Task<IActionResult> RevokeRefreshTokenAsync(RefreshTokenDto refreshToken)
        {
            var results = await _authenticationService.RevokeRefreshTokenAsync(refreshToken.Token);
            return ActionResultInstance(results);
        }
    }
}
