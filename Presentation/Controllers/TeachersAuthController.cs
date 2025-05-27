using Business.Abstract.AuthServices;
using Business.Constants;
using Core.Entities.Concrete;
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
				return BadRequest(new ErrorResponse(Messages.UserNotLogin));
			}
			var result = _teacherAuthService.CreateAccessToken(userToLogin);

			if (result != null)
			{
				return Ok(result);
			}
			return BadRequest(new ErrorResponse(Messages.AccessTokenError));
		}

		[HttpPost("register")]
		public ActionResult Register([FromBody] TeacherRegisterDto teacherRegisterDto)
		{
			var userExists = _teacherAuthService.UserExists(teacherRegisterDto.Email);

			if (userExists)
			{
				return BadRequest(new ErrorResponse(Messages.UserAlreadyExists));
			}

			var registerResult = _teacherAuthService.Register(teacherRegisterDto);

			if (registerResult == null)
			{
				return BadRequest(new ErrorResponse(Messages.UserNotRegister));
			}

			var result = _teacherAuthService.CreateAccessToken(registerResult);

			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest(new ErrorResponse(Messages.AccessTokenError));
		}
	}
}
