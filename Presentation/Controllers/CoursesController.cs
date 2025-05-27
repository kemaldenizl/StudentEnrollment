using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Produces("application/xml")]
	public class CoursesController : ControllerBase
	{
		private ICourseService _courseService;
		public CoursesController(ICourseService courseService)
		{
			_courseService = courseService;
		}

		[HttpGet()]
		public IActionResult GetAll()
		{
			var result = _courseService.GetAll();
			if (result != null)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpGet("getAllByTeacher/{teacherId}")]
		public IActionResult GetAllByTeacher(int teacherId)
		{
			var result = _courseService.GetAllByTeacher(teacherId);
			if (result != null)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var result = _courseService.GetById(id);
			if (result != null)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("add")]
		public IActionResult Add(Course course)
		{
			_courseService.Add(course);
			return Ok("Ok.");
		}

		[HttpPut("update")]
		public IActionResult Update(Course course)
		{
			_courseService.Update(course);
			return Ok("Ok.");
		}

		[HttpDelete("delete")]
		public IActionResult Delete(Course course)
		{
			_courseService.Delete(course);
			return Ok("Ok.");
		}
	}
}
