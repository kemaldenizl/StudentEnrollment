using Business.Abstract.AuthServices;
using Entities.Dtos.LoginDtos;
using Entities.Dtos.RegisterDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdminsAuthManager : ControllerBase
	{
		private IAdminAuthService _adminAuthService;

		public AdminsAuthManager(IAdminAuthService adminAuthService)
		{
			_adminAuthService = adminAuthService;
		}

		[HttpPost("login")]
		public ActionResult Login([FromBody] AdminLoginDto adminLoginDto)
		{
			var userToLogin = _adminAuthService.Login(adminLoginDto);
			if (!userToLogin.Success)
			{
				return BadRequest(userToLogin.Message);
			}
			var result = _adminAuthService.CreateAccessToken(userToLogin.Data);

			if (result.Success)
			{
				return Ok(result.Data);
			}
			return BadRequest(result.Message);
		}

		[HttpPost("register")]
		public ActionResult Register([FromBody] AdminRegisterDto adminRegisterDto)
		{
			var userExists = _adminAuthService.UserExists(adminRegisterDto.Email);

			if (!userExists.Success)
			{
				return BadRequest(userExists.Message);
			}

			var registerResult = _adminAuthService.Register(adminRegisterDto);
			var result = _adminAuthService.CreateAccessToken(registerResult.Data);

			if (result.Success)
			{
				return Ok(result.Data);
			}

			return BadRequest(result.Message);
		}
	}
}
