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
	public class EnrollmentsController : ControllerBase
	{
		private IEnrollmentService _enrollmentService;

		public EnrollmentsController(IEnrollmentService enrollmentService)
		{
			_enrollmentService = enrollmentService;
		}

		[HttpGet()]
		public IActionResult GetAll()
		{
			var result = _enrollmentService.GetAll();
			if (result != null)
			{
				return Ok(result);
			}
			return NotFound(new ErrorResponse(Messages.DataNotFound));
		}
		[HttpGet("getAllByStudent/{studentId}")]
		public IActionResult GetEnrollmentsByStudent(int studentId)
		{
			var result = _enrollmentService.GetAllByStudent(studentId);
			if (result != null)
			{
				return Ok(result);
			}
			return NotFound(new ErrorResponse(Messages.DataNotFound));
		}
		[HttpGet("getAllByCourse/{courseId}")]
		public IActionResult GetEnrollmentsByCourse(int courseId)
		{
			var result = _enrollmentService.GetAllByCourse(courseId);
			if (result != null)
			{
				return Ok(result);
			}
			return NotFound(new ErrorResponse(Messages.DataNotFound));
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var result = _enrollmentService.GetById(id);
			if (result != null)
			{
				return Ok(result);
			}
			return NotFound(new ErrorResponse(Messages.DataNotFound));
		}

		[HttpPost("add")]
		public IActionResult Add(Enrollment enrollment)
		{
			var result = _enrollmentService.Add(enrollment);
			return Ok(result);
		}

		[HttpPut("update")]
		public IActionResult Update(Enrollment enrollment)
		{
			var result = _enrollmentService.Update(enrollment);
			return Ok(result);
		}

		[HttpDelete("delete")]
		public IActionResult Delete(Enrollment enrollment)
		{
			var result = _enrollmentService.Delete(enrollment);
			return Ok(result);
		}
	}
}
