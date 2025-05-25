using Business.Abstract.AuthServices;
using Entities.Dtos.LoginDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentsAuthController : ControllerBase
	{
		private IStudentAuthService _studentAuthService;
		public StudentsAuthController(IStudentAuthService studentAuthService)
		{
			_studentAuthService = studentAuthService;
		}

		[HttpPost("login")]
		public ActionResult Login([FromBody] StudentLoginDto studentLoginDto)
		{
			var userToLogin = _studentAuthService.Login(studentLoginDto); //Users form information send to login service.
			if (!userToLogin.Success) //if not success, return BadRequest with the message.
			{
				return BadRequest(userToLogin.Message);
			}
			var result = _studentAuthService.CreateAccessToken(userToLogin.Data); // if success, create access token for the user.

			if (result.Success) //if access token created successfully, return Ok with the access token.
			{
				return Ok(result.Data);
			}
			return BadRequest(result.Message); //if access token creation failed, return BadRequest with the message.
		}
	}
}
