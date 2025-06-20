﻿using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Produces("application/xml")]
	public class TeachersController : ControllerBase
	{
		public ITeacherService _teacherService;
		public TeachersController(ITeacherService teacherService)
		{
			_teacherService = teacherService;
		}

		[HttpGet()]
		[Authorize(Roles = "Teacher.GetAll")]
		public IActionResult GetAll()
		{
			var result = _teacherService.GetAll();
			if (result != null)
			{
				return Ok(result);
			}
			return NotFound(new ErrorResponse(Messages.DataNotFound));
		}
		[HttpGet("{id}")]
		[Authorize(Roles = "Teacher.GetById")]
		public IActionResult GetById(int id)
		{
			var result = _teacherService.Get(id);
			if (result != null)
			{
				return Ok(result);
			}
			return NotFound(new ErrorResponse(Messages.DataNotFound));
		}
		[HttpDelete("{id}")]
		[Authorize(Roles = "Teacher.Delete")]
		public IActionResult Delete(int id)
		{
			var result = _teacherService.Delete(id);
			return Ok(result);
		}
	}
}
