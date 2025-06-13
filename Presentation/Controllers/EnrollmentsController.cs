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
	public class EnrollmentsController : ControllerBase
	{
		private IEnrollmentService _enrollmentService;

		public EnrollmentsController(IEnrollmentService enrollmentService)
		{
			_enrollmentService = enrollmentService;
		}

		[HttpGet()]
		[Authorize(Roles = "Enrollment.GetAll")]
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
		[Authorize(Roles = "Enrollment.GetAllByStudent")]
		public IActionResult GetAllByStudent(int studentId)
		{
			var result = _enrollmentService.GetAllByStudent(studentId);
			if (result != null)
			{
				return Ok(result);
			}
			return NotFound(new ErrorResponse(Messages.DataNotFound));
		}
		[HttpGet("getAllByCourse/{courseId}")]
		[Authorize(Roles = "Enrollment.GetAllByCourse")]
		public IActionResult GetAllByCourse(int courseId)
		{
			var result = _enrollmentService.GetAllByCourse(courseId);
			if (result != null)
			{
				return Ok(result);
			}
			return NotFound(new ErrorResponse(Messages.DataNotFound));
		}

		[HttpGet("{id}")]
		[Authorize(Roles = "Enrollment.GetById")]
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
		[Authorize(Roles = "Enrollment.Add")]
		[XsdValidation("Schemas/enrollment.xsd")]
		public IActionResult Add(Enrollment enrollment)
		{
			var result = _enrollmentService.Add(enrollment);
			return Ok(result);
		}

		[HttpPut("update")]
		[Authorize(Roles = "Enrollment.Update")]
		[XsdValidation("Schemas/enrollment.xsd")]
		public IActionResult Update(Enrollment enrollment)
		{
			var result = _enrollmentService.Update(enrollment);
			return Ok(result);
		}

		[HttpDelete("delete")]
		[Authorize(Roles = "Enrollment.Delete")]
		[XsdValidation("Schemas/enrollment.xsd")]
		public IActionResult Delete(Enrollment enrollment)
		{
			var result = _enrollmentService.Delete(enrollment);
			return Ok(result);
		}
	}
}
