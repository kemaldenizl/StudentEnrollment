using Business.Abstract.AuthServices;
using Entities.Dtos.LoginDtos;
using Entities.Dtos.RegisterDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
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
			if (!userToLogin.Success)
			{
				return BadRequest(userToLogin.Message);
			}
			var result = _teacherAuthService.CreateAccessToken(userToLogin.Data);

			if (result.Success)
			{
				return Ok(result.Data);
			}
			return BadRequest(result.Message);
		}

		[HttpPost("register")]
		public ActionResult Register([FromBody] TeacherRegisterDto teacherRegisterDto)
		{
			var userExists = _teacherAuthService.UserExists(teacherRegisterDto.Email);

			if (!userExists.Success)
			{
				return BadRequest(userExists.Message);
			}

			var registerResult = _teacherAuthService.Register(teacherRegisterDto);
			var result = _teacherAuthService.CreateAccessToken(registerResult.Data);

			if (result.Success)
			{
				return Ok(result.Data);
			}

			return BadRequest(result.Message);
		}
	}
}
