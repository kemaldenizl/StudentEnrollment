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
	public class AdminsController : ControllerBase
	{
		public IAdminService _adminService;
		public AdminsController(IAdminService adminService)
		{
			_adminService = adminService;
		}

		[HttpGet()]
		[Authorize(Roles = "Admin.GetAll")]
		public IActionResult GetAll()
		{
			var result = _adminService.GetAll();
			if (result != null)
			{
				return Ok(result);
			}
			return NotFound(new ErrorResponse(Messages.DataNotFound));
		}

		[HttpGet("{id}")]
		[Authorize(Roles = "Admin.GetById")]
		public IActionResult GetById(int id)
		{
			var result = _adminService.Get(id);
			if (result != null)
			{
				return Ok(result);
			}
			return NotFound(new ErrorResponse(Messages.DataNotFound));
		}

		[HttpDelete("{id}")]
		[Authorize(Roles = "Admin.Delete")]
		public IActionResult Delete(int id)
		{
			var result = _adminService.Delete(id); 
			return Ok(result);
		}
	}
}
