using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TeachersController : ControllerBase
	{
		public ITeacherService _teacherService;
		public TeachersController(ITeacherService teacherService)
		{
			_teacherService = teacherService;
		}

		[HttpGet()]
		public IActionResult GetAll()
		{
			var result = _teacherService.GetAll();
			if (result != null)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var result = _teacherService.Get(id);
			if (result != null)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_teacherService.Delete(id);
			return Ok("Ok.");
		}
	}
}
