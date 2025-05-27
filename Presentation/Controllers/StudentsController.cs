using Business.Abstract;
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
			return BadRequest(result);
		}
		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var result = _studentService.Get(id);
			if (result != null)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpDelete("delete")]
		public IActionResult Delete(Student student)
		{
			_studentService.Delete(student);
			return Ok("Ok.");
		}
	}
}
