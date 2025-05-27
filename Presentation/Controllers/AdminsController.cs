using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdminsController : ControllerBase
	{
		public IAdminService _adminService;
		public AdminsController(IAdminService adminService)
		{
			_adminService = adminService;
		}

		[HttpGet()]
		public IActionResult GetAll()
		{
			var result = _adminService.GetAll();
			if (result != null)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var result = _adminService.Get(id);
			if (result != null)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpDelete("delete")]
		public IActionResult Delete(Admin admin)
		{
			_adminService.Delete(admin); 
			return Ok("Ok.");
		}
	}
}
