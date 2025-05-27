using Business.Abstract;
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
			return BadRequest(result);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var result = _enrollmentService.GetById(id);
			if (result != null)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("add")]
		public IActionResult Add(Enrollment enrollment)
		{
			_enrollmentService.Add(enrollment);
			return Ok("Ok.");
		}

		[HttpPut("update")]
		public IActionResult Update(Enrollment enrollment)
		{
			_enrollmentService.Update(enrollment);
			return Ok("Ok.");
		}

		[HttpDelete("delete")]
		public IActionResult Delete(Enrollment enrollment)
		{
			_enrollmentService.Delete(enrollment);
			return Ok("Ok.");
		}
	}
}
