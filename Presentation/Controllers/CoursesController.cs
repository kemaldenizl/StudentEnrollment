using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Middlewares;

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
		[Authorize(Roles = "Course.GetAll")]
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
		[Authorize(Roles = "Course.GetAllByTeacher")]
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
		[Authorize(Roles = "Course.GetById")]
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
		[Authorize(Roles = "Course.Add")]
		[XsdValidation("Schemas/course.xsd")]
		public IActionResult Add(Course course)
		{
			var result = _courseService.Add(course);
			return Ok(result);
		}

		[HttpPut("update")]
		[Authorize(Roles = "Course.Update")]
		[XsdValidation("Schemas/course.xsd")]
		public IActionResult Update(Course course)
		{
			var result = _courseService.Update(course);
			return Ok(result);
		}

		[HttpDelete("delete")]
		[Authorize(Roles = "Course.Delete")]
		[XsdValidation("Schemas/course.xsd")]
		public IActionResult Delete(Course course)
		{
			var result = _courseService.Delete(course);
			return Ok(result);
		}
	}
}
