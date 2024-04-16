using Amkodor.BusinessLogic.Interfaces;
using Amkodor.Common.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Amkodor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<bool> Auth([FromBody]UserDto userDto)
        {
            try
            {
                return _authService.Auth(userDto);
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
