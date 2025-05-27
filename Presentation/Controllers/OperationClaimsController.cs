using Business.Abstract;
using Entities.Concrete;
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
		public IActionResult GetAll()
		{
			var result = _operationClaimService.GetAll();
			if (result != null)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var result = _operationClaimService.GetById(id);
			if (result != null)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("add")]
		public IActionResult Add(OperationClaim operationClaim)
		{
			_operationClaimService.Add(operationClaim);
			return Ok("Ok.");
		}

		[HttpPut("update")]
		public IActionResult Update(OperationClaim operationClaim)
		{
			_operationClaimService.Update(operationClaim);
			return Ok("Ok.");
		}

		[HttpDelete("delete")]
		public IActionResult Delete(OperationClaim operationClaim)
		{
			_operationClaimService.Delete(operationClaim);
			return Ok("Ok.");
		}
	}
}
