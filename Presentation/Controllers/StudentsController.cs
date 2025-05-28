using Business.Abstract;
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
	public class StudentsController : ControllerBase
	{
		public IStudentService _studentService;
		public StudentsController(IStudentService studentService)
		{
			_studentService = studentService;
		}
		[HttpGet()]
		[Authorize(Roles = "Student.GetAll")]
		public IActionResult GetAll()
		{
			var result = _studentService.GetAll();
			if (result != null)
			{
				return Ok(result);
			}
			return NotFound(new ErrorResponse(Messages.DataNotFound));
		}
		[HttpGet("{id}")]
		[Authorize(Roles = "Student.GetById")]
		public IActionResult GetById(int id)
		{
			var result = _studentService.Get(id);
			if (result != null)
			{
				return Ok(result);
			}
			return NotFound(new ErrorResponse(Messages.DataNotFound));
		}
		[HttpDelete("{id}")]
		[Authorize(Roles = "Student.Delete")]
		public IActionResult Delete(int id)
		{
			var result = _studentService.Delete(id);
			return Ok(result);
		}
	}
}
