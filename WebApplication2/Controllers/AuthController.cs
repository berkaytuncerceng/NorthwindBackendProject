using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Succeeded)
            {
                return BadRequest(userToLogin.Message);
            }
            var result = _authService.GetAccessToken(userToLogin.Data);
            if (result.Succeeded)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);

            if (userExists.Succeeded)
            {
                return BadRequest(userExists.Message);
            }
            else
            {
                var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
                var result = _authService.GetAccessToken(registerResult.Data);
                if (result.Succeeded)
                {
                    return Ok(result.Data);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
        }

    }
}
