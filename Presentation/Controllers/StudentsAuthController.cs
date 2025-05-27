using Business.Abstract.AuthServices;
using Entities.Dtos.LoginDtos;
using Entities.Dtos.RegisterDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Produces("application/xml")]
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
			var userToLogin = _studentAuthService.Login(studentLoginDto); //Users information send to login service.
			if (userToLogin == null) //if not success, return BadRequest with the message.
			{
				return BadRequest("Error to login.");
			}
			var result = _studentAuthService.CreateAccessToken(userToLogin); // if success, create access token for the user.

			if (result != null) //if access token created successfully, return Ok with the access token.
			{
				return Ok(result);
			}
			return BadRequest("Error to login."); //if access token creation failed, return BadRequest with the message.
		}

		[HttpPost("register")]
		public ActionResult Register([FromBody] StudentRegisterDto studentRegisterDto)
		{
			var userExists = _studentAuthService.UserExists(studentRegisterDto.Email); //check if user already exists.

			if (!userExists) //if user already exists, return BadRequest with the message.
			{
				return BadRequest("User not found!");
			}

			var registerResult = _studentAuthService.Register(studentRegisterDto); //if user does not exist, register the user.
			var result = _studentAuthService.CreateAccessToken(registerResult); //create access token for the user. 

			if (result != null)
			{
				return Ok(result); //if access token created successfully, return Ok with the access token.
			}

			return BadRequest("Error to register.");
		}
	}
}