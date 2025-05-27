using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdminOperationClaimsController : ControllerBase
	{
		public IAdminOperationClaimService _adminOperationClaimService;
		public AdminOperationClaimsController(IAdminOperationClaimService adminOperationClaimService)
		{
			_adminOperationClaimService = adminOperationClaimService;
		}

		[HttpGet()]
		public IActionResult GetAll()
		{
			var result = _adminOperationClaimService.GetAll();
			if (result != null)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getAllByAdmin/{adminId}")]
		public IActionResult GetAllByAdmin(int adminId)
		{
			var result = _adminOperationClaimService.GetAllByAdmin(adminId);
			if (result != null)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getAllByOperationClaim/{operationClaimId}")]
		public IActionResult GetAllByOperationClaim(int operationClaimId)
		{
			var result = _adminOperationClaimService.GetAllByOperationClaim(operationClaimId);
			if (result != null)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var result = _adminOperationClaimService.GetById(id);
			if (result != null)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("add")]
		public IActionResult Add(AdminOperationClaim adminOperationClaim)
		{
			_adminOperationClaimService.Add(adminOperationClaim);
			return Ok("Ok.");
		}

		[HttpPut("update")]
		public IActionResult Update(AdminOperationClaim adminOperationClaim)
		{
			_adminOperationClaimService.Update(adminOperationClaim);
			return Ok("Ok.");
		}

		[HttpDelete("delete")]
		public IActionResult Delete(AdminOperationClaim adminOperationClaim)
		{
			_adminOperationClaimService.Delete(adminOperationClaim);
			return Ok("Ok.");
		}
	}
}
