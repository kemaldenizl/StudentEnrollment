using Business.Abstract.AuthServices;
using Business.Constants;
using Core.Entities.Concrete;
using Entities.Dtos.LoginDtos;
using Entities.Dtos.RegisterDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Middlewares;

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
		[XsdValidation("Schemas/adminLogin.xsd")]
		public ActionResult Login([FromBody] AdminLoginDto adminLoginDto)
		{
			var userToLogin = _adminAuthService.Login(adminLoginDto);
			if (userToLogin == null)
			{
				return BadRequest(new ErrorResponse(Messages.UserNotLogin));
			}
			var result = _adminAuthService.CreateAccessToken(userToLogin);

			if (result != null)
			{
				return Ok(result);
			}
			return BadRequest(new ErrorResponse(Messages.AccessTokenError));
		}

		[HttpPost("register")]
		[Authorize(Roles = "AdminAuth.Register")]
		[XsdValidation("Schemas/adminRegister.xsd")]
		public ActionResult Register([FromBody] AdminRegisterDto adminRegisterDto)
		{
			var userExists = _adminAuthService.UserExists(adminRegisterDto.Email);

			if (userExists)
			{
				return BadRequest(new ErrorResponse(Messages.UserAlreadyExists));
			}

			var registerResult = _adminAuthService.Register(adminRegisterDto);

			if (registerResult == null)
			{
				return BadRequest(new ErrorResponse(Messages.UserNotRegister));
			}

			return Ok(registerResult);
		}
	}
}
