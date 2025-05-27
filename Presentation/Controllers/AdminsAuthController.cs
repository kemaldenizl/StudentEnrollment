using Business.Abstract.AuthServices;
using Entities.Dtos.LoginDtos;
using Entities.Dtos.RegisterDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Produces("application/xml")]
	public class AdminsAuthController : ControllerBase
	{
		private IAdminAuthService _adminAuthService;

		public AdminsAuthController(IAdminAuthService adminAuthService)
		{
			_adminAuthService = adminAuthService;
		}

		[HttpPost("login")]
		public ActionResult Login([FromBody] AdminLoginDto adminLoginDto)
		{
			var userToLogin = _adminAuthService.Login(adminLoginDto);
			if (userToLogin == null)
			{
				return BadRequest("Error to login.");
			}
			var result = _adminAuthService.CreateAccessToken(userToLogin);

			if (result != null)
			{
				return Ok(result);
			}
			return BadRequest("Error to login.");
		}

		[HttpPost("register")]
		public ActionResult Register([FromBody] AdminRegisterDto adminRegisterDto)
		{
			var userExists = _adminAuthService.UserExists(adminRegisterDto.Email);

			if (!userExists)
			{
				return BadRequest("User not found!");
			}

			var registerResult = _adminAuthService.Register(adminRegisterDto);
			var result = _adminAuthService.CreateAccessToken(registerResult);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error to register.");
		}
	}
}
