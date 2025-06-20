﻿using Business.Abstract.AuthServices;
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
	public class StudentsAuthController : ControllerBase
	{
		private IStudentAuthService _studentAuthService;
		public StudentsAuthController(IStudentAuthService studentAuthService)
		{
			_studentAuthService = studentAuthService;
		}

		[HttpPost("login")]
		[XsdValidation("Schemas/studentLogin.xsd")]
		public ActionResult Login([FromBody] StudentLoginDto studentLoginDto)
		{
			var userToLogin = _studentAuthService.Login(studentLoginDto); //Users information send to login service.
			if (userToLogin == null) //if not success, return BadRequest with the message.
			{
				return BadRequest(new ErrorResponse(Messages.UserNotLogin));
			}
			var result = _studentAuthService.CreateAccessToken(userToLogin); // if success, create access token for the user.

			if (result != null) //if access token created successfully, return Ok with the access token.
			{
				return Ok(result);
			}
			return BadRequest(new ErrorResponse(Messages.AccessTokenError)); //if access token creation failed, return BadRequest with the message.
		}

		[HttpPost("register")]
		[Authorize(Roles = "StudentAuth.Register")]
		[XsdValidation("Schemas/studentRegister.xsd")]
		public ActionResult Register([FromBody] StudentRegisterDto studentRegisterDto)
		{
			var userExists = _studentAuthService.UserExists(studentRegisterDto.Email); //check if user already exists.

			if (userExists) //if user already exists, return BadRequest with the message.
			{
				return BadRequest(new ErrorResponse(Messages.UserAlreadyExists));
			}

			var registerResult = _studentAuthService.Register(studentRegisterDto); //if user does not exist, register the user.

			if (registerResult == null) //if registration failed, return BadRequest with the message.
			{
				return BadRequest(new ErrorResponse(Messages.UserNotRegister));
			}

			return Ok(registerResult);
		}
	}
}