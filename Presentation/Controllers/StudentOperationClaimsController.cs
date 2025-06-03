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
	public class StudentOperationClaimsController : ControllerBase
	{
		public IStudentOperationClaimService _studentOperationClaimService;
		public StudentOperationClaimsController(IStudentOperationClaimService studentOperationClaimService)
		{
			_studentOperationClaimService = studentOperationClaimService;
		}

		[HttpGet()]
		[Authorize(Roles = "StudentOperationClaim.GetAll")]
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
		[Authorize(Roles = "StudentOperationClaim.GetAllByStudent")]
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
		[Authorize(Roles = "StudentOperationClaim.GetAllByOperationClaim")]
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
		[Authorize(Roles = "StudentOperationClaim.GetById")]
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
		[Authorize(Roles = "StudentOperationClaim.Add")]
		public IActionResult Add(StudentOperationClaim studentOperationClaim)
		{
			var result = _studentOperationClaimService.Add(studentOperationClaim);
			return Ok(result);
		}
		[HttpPut("update")]
		[Authorize(Roles = "StudentOperationClaim.Update")]
		public IActionResult Update(StudentOperationClaim studentOperationClaim)
		{
			var result = _studentOperationClaimService.Update(studentOperationClaim);
			return Ok(result);
		}

		[HttpDelete("delete")]
		[Authorize(Roles = "StudentOperationClaim.Delete")]
		public IActionResult Delete(StudentOperationClaim studentOperationClaim)
		{
			var result = _studentOperationClaimService.Delete(studentOperationClaim);
			return Ok(result);
		}
		[HttpPost("addDefaultStudentOperationClaims/{id}")]
		[Authorize(Roles = "StudentOperationClaim.AddDefault")]
		public IActionResult AddDefaultStudentOperationClaims(int id)
		{
			var result = _studentOperationClaimService.AddDefaultStudentOperationClaims(id);
			if (result.Count > 0)
			{
				return Ok(result);
			}
			return BadRequest(new ErrorResponse(Messages.DataNotFound));
		}
		[HttpDelete("deleteAllByStudent/{id}")]
		[Authorize(Roles = "StudentOperationClaim.DeleteAllByStudent")]
		public IActionResult DeleteAllByStudent(int id)
		{
			var result = _studentOperationClaimService.DeleteAllByStudent(id);
			if (result != null)
			{
				return Ok(result);
			}

			return BadRequest(new ErrorResponse(Messages.DataNotFound));
		}
	}
}
