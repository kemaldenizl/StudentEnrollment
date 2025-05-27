using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
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
			return NotFound(new ErrorResponse(Messages.DataNotFound));
		}
		[HttpGet("getAllByTeacher/{teacherId}")]
		public IActionResult GetAllByTeacher(int teacherId)
		{
			var result = _courseService.GetAllByTeacher(teacherId);
			if (result != null)
			{
				return Ok(result);
			}
			return NotFound(new ErrorResponse(Messages.DataNotFound));
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var result = _courseService.GetById(id);
			if (result != null)
			{
				return Ok(result);
			}
			return NotFound(new ErrorResponse(Messages.DataNotFound));
		}

		[HttpPost("add")]
		public IActionResult Add(Course course)
		{
			var result = _courseService.Add(course);
			return Ok(result);
		}

		[HttpPut("update")]
		public IActionResult Update(Course course)
		{
			var result = _courseService.Update(course);
			return Ok(result);
		}

		[HttpDelete("delete")]
		public IActionResult Delete(Course course)
		{
			var result = _courseService.Delete(course);
			return Ok(result);
		}
	}
}
