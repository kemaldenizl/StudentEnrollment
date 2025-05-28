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
	public class OperationClaimsController : ControllerBase
	{
		private IOperationClaimService _operationClaimService;

		public OperationClaimsController(IOperationClaimService operationClaimService)
		{
			_operationClaimService = operationClaimService;
		}

		[HttpGet()]
		[Authorize(Roles = "OperationClaim.GetAll")]
		public IActionResult GetAll()
		{
			var result = _operationClaimService.GetAll();
			if (result != null)
			{
				return Ok(result);
			}
			return NotFound(new ErrorResponse(Messages.DataNotFound));
		}

		[HttpGet("{id}")]
		[Authorize(Roles = "OperationClaim.GetById")]
		public IActionResult GetById(int id)
		{
			var result = _operationClaimService.GetById(id);
			if (result != null)
			{
				return Ok(result);
			}
			return NotFound(new ErrorResponse(Messages.DataNotFound));
		}

		[HttpPost("add")]
		[Authorize(Roles = "OperationClaim.Add")]
		public IActionResult Add(OperationClaim operationClaim)
		{
			var result = _operationClaimService.Add(operationClaim);
			return Ok(result);
		}

		[HttpPut("update")]
		[Authorize(Roles = "OperationClaim.Update")]
		public IActionResult Update(OperationClaim operationClaim)
		{
			var result = _operationClaimService.Update(operationClaim);
			return Ok(result);
		}

		[HttpDelete("delete")]
		[Authorize(Roles = "OperationClaim.Delete")]
		public IActionResult Delete(OperationClaim operationClaim)
		{
			var result = _operationClaimService.Delete(operationClaim);
			return Ok(result);
		}
	}
}
