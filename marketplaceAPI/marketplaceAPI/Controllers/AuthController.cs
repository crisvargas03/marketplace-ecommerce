using marketplaceAPI.BLL.DTOs.AuthModels;
using marketplaceAPI.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace marketplaceAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> LoginAction([FromBody] UserLoginWithCredsDto userLogin)
        {
            var servicesResult = await _userService.Login(userLogin);
            return servicesResult switch
            {
                { IsSuccess: true } => Ok(servicesResult),
                _ => BadRequest(servicesResult)
            };
        }

        [HttpPost("register")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RegisterAction([FromBody] UserRegisterWithCredsDto userRegister)
        {
            var servicesResult = await _userService.Register(userRegister);
            return servicesResult switch
            {
                { IsSuccess: true } => Ok(servicesResult),
                _ => BadRequest(servicesResult)
            };
        }
    }
}
