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
			return NotFound(new ErrorResponse(Messages.DataNotFound));
		}
		[HttpGet("getAllByStudent/{studentId}")]
		public IActionResult GetAllByStudent(int studentId)
		{
			var result = _studentOperationClaimService.GetAllByStudent(studentId);
			if (result != null)
			{
				return Ok(result);
			}
			return NotFound(new ErrorResponse(Messages.DataNotFound));
		}
		[HttpGet("getAllByOperationClaim/{operationClaimId}")]
		public IActionResult GetAllByOperationClaim(int operationClaimId)
		{
			var result = _studentOperationClaimService.GetAllByOperationClaim(operationClaimId);
			if (result != null)
			{
				return Ok(result);
			}
			return NotFound(new ErrorResponse(Messages.DataNotFound));
		}
		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var result = _studentOperationClaimService.GetById(id);
			if (result != null)
			{
				return Ok(result);
			}
			return NotFound(new ErrorResponse(Messages.DataNotFound));
		}
		[HttpPost("add")]
		public IActionResult Add(StudentOperationClaim studentOperationClaim)
		{
			var result = _studentOperationClaimService.Add(studentOperationClaim);
			return Ok(result);
		}
		[HttpPut("update")]
		public IActionResult Update(StudentOperationClaim studentOperationClaim)
		{
			var result = _studentOperationClaimService.Update(studentOperationClaim);
			return Ok(result);
		}

		[HttpDelete("delete")]
		public IActionResult Delete(StudentOperationClaim studentOperationClaim)
		{
			var result = _studentOperationClaimService.Delete(studentOperationClaim);
			return Ok(result);
		}
	}
}
