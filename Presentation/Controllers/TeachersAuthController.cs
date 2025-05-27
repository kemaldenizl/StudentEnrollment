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
	public class TeachersAuthController : ControllerBase
	{
		private ITeacherAuthService _teacherAuthService;
		public TeachersAuthController(ITeacherAuthService teacherAuthService)
		{
			_teacherAuthService = teacherAuthService;
		}

		[HttpPost("login")]
		public ActionResult Login([FromBody] TeacherLoginDto teacherLoginDto)
		{
			var userToLogin = _teacherAuthService.Login(teacherLoginDto);
			if (userToLogin == null)
			{
				return BadRequest("Error to login.");
			}
			var result = _teacherAuthService.CreateAccessToken(userToLogin);

			if (result != null)
			{
				return Ok(result);
			}
			return BadRequest("Error to login.");
		}

		[HttpPost("register")]
		public ActionResult Register([FromBody] TeacherRegisterDto teacherRegisterDto)
		{
			var userExists = _teacherAuthService.UserExists(teacherRegisterDto.Email);

			if (!userExists)
			{
				return BadRequest("User not found!");
			}

			var registerResult = _teacherAuthService.Register(teacherRegisterDto);
			var result = _teacherAuthService.CreateAccessToken(registerResult);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest("Error to register.");
		}
	}
}
