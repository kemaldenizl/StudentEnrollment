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
	public class StudentsController : ControllerBase
	{
		public IStudentService _studentService;
		public StudentsController(IStudentService studentService)
		{
			_studentService = studentService;
		}
		[HttpGet()]
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
		public IActionResult Delete(int id)
		{
			var result = _studentService.Delete(id);
			return Ok(result);
		}
	}
}
