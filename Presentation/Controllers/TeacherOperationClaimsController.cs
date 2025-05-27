using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TeacherOperationClaimsController : ControllerBase
	{
		public ITeacherOperationClaimService _teacherOperationClaimService;
		public TeacherOperationClaimsController(ITeacherOperationClaimService teacherOperationClaimService)
		{
			_teacherOperationClaimService = teacherOperationClaimService;
		}

		[HttpGet()]
		public IActionResult GetAll()
		{
			var result = _teacherOperationClaimService.GetAll();
			if (result != null)
			{
				return Ok(result);
			}
			return NotFound(result);
		}

		[HttpGet("getAllByTeacher/{teacherId}")]
		public IActionResult GetAllByTeacher(int teacherId)
		{
			var result = _teacherOperationClaimService.GetAllByTeacher(teacherId);
			if (result != null)
			{
				return Ok(result);
			}
			return NotFound(result);
		}

		[HttpGet("getAllByOperationClaim/{operationClaimId}")]
		public IActionResult GetAllByOperationClaim(int operationClaimId)
		{
			var result = _teacherOperationClaimService.GetAllByOperationClaim(operationClaimId);
			if (result != null)
			{
				return Ok(result);
			}
			return NotFound(result);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var result = _teacherOperationClaimService.GetById(id);
			if (result != null)
			{
				return Ok(result);
			}
			return NotFound(result);
		}

		[HttpPost("add")]
		public IActionResult Add(TeacherOperationClaim teacherOperationClaim)
		{
			var result = _teacherOperationClaimService.Add(teacherOperationClaim);
			return Ok(result);
		}
		[HttpPut("update")]
		public IActionResult Update(TeacherOperationClaim teacherOperationClaim)
		{
			var result = _teacherOperationClaimService.Update(teacherOperationClaim);
			return Ok(result);
		}
		[HttpDelete("delete")]
		public IActionResult Delete(TeacherOperationClaim teacherOperationClaim)
		{
			var result = _teacherOperationClaimService.Delete(teacherOperationClaim);
			return Ok(result);
		}
	}
}
