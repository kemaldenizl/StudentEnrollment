using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentOperationClaimsController : ControllerBase
	{
		public IStudentOperationClaimService _studentOperationClaimService;
		public StudentOperationClaimsController(IStudentOperationClaimService studentOperationClaimService)
		{
			_studentOperationClaimService = studentOperationClaimService;
		}

		[HttpGet()]
		public IActionResult GetAll()
		{
			var result = _studentOperationClaimService.GetAll();
			if (result != null)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpGet("getAllByStudent/{studentId}")]
		public IActionResult GetAllByStudent(int studentId)
		{
			var result = _studentOperationClaimService.GetAllByStudent(studentId);
			if (result != null)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpGet("getAllByOperationClaim/{operationClaimId}")]
		public IActionResult GetAllByOperationClaim(int operationClaimId)
		{
			var result = _studentOperationClaimService.GetAllByOperationClaim(operationClaimId);
			if (result != null)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var result = _studentOperationClaimService.GetById(id);
			if (result != null)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpPost("add")]
		public IActionResult Add(StudentOperationClaim studentOperationClaim)
		{
			_studentOperationClaimService.Add(studentOperationClaim);
			return Ok("Ok.");
		}
		[HttpPut("update")]
		public IActionResult Update(StudentOperationClaim studentOperationClaim)
		{
			_studentOperationClaimService.Update(studentOperationClaim);
			return Ok("Ok.");
		}

		[HttpDelete("delete")]
		public IActionResult Delete(StudentOperationClaim studentOperationClaim)
		{
			_studentOperationClaimService.Delete(studentOperationClaim);
			return Ok("Ok.");
		}
	}
}
