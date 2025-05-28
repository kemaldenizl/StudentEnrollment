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
	[Produces("application/xml")]
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
			return NotFound(new ErrorResponse(Messages.DataNotFound));
		}

		[HttpGet("getAllByAdmin/{adminId}")]
		public IActionResult GetAllByAdmin(int adminId)
		{
			var result = _adminOperationClaimService.GetAllByAdmin(adminId);
			if (result != null)
			{
				return Ok(result);
			}
			return NotFound(new ErrorResponse(Messages.DataNotFound));
		}

		[HttpGet("getAllByOperationClaim/{operationClaimId}")]
		public IActionResult GetAllByOperationClaim(int operationClaimId)
		{
			var result = _adminOperationClaimService.GetAllByOperationClaim(operationClaimId);
			if (result != null)
			{
				return Ok(result);
			}
			return NotFound(new ErrorResponse(Messages.DataNotFound));
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var result = _adminOperationClaimService.GetById(id);
			if (result != null)
			{
				return Ok(result);
			}
			return NotFound(new ErrorResponse(Messages.DataNotFound));
		}

		[HttpPost("add")]
		public IActionResult Add(AdminOperationClaim adminOperationClaim)
		{
			var result = _adminOperationClaimService.Add(adminOperationClaim);
			return Ok(result);
		}

		[HttpPut("update")]
		public IActionResult Update(AdminOperationClaim adminOperationClaim)
		{
			var result = _adminOperationClaimService.Update(adminOperationClaim);
			return Ok(result);
		}

		[HttpDelete("delete")]
		public IActionResult Delete(AdminOperationClaim adminOperationClaim)
		{
			var result = _adminOperationClaimService.Delete(adminOperationClaim);
			return Ok(result);
		}
	}
}
