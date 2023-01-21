using Application.Features.Auth.Commands.Login;
using Application.Features.Auth.Commands.Register;
using Core.Security.Dtos;
using Core.Security.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]  UserForRegisterDto userForRegisterDto)
        {
            RegisterCommand registerCommand = new()
            {
                UserForRegisterDto = userForRegisterDto,
                IpAdress = GetIpAdress()
            };
            var result = await Mediator.Send(registerCommand);
            SetRefreshTokenToCookie(result.RefreshToken);
            return Created("", result.AccessToken);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            LoginCommand loginCommand = new()
            {
                IpAdress = GetIpAdress(),
                UserForLoginDto = userForLoginDto
            };
            var result = await Mediator.Send(loginCommand);
            return Created("", result.AccessToken);
        }


        private void SetRefreshTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.Now.AddDays(7) }; //cookie ayarı yapmak için.
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions); // refresh token isminde, valuesi token olan ve cookie ayaları şu şekilde bunu cookielere ekle demektir.
        }
    }
}
