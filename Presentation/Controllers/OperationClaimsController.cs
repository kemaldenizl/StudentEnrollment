using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
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
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var result = _operationClaimService.GetById(id);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("add")]
		public IActionResult Add(OperationClaim operationClaim)
		{
			var result = _operationClaimService.Add(operationClaim);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPut("update")]
		public IActionResult Update(OperationClaim operationClaim)
		{
			var result = _operationClaimService.Update(operationClaim);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpDelete("delete")]
		public IActionResult Delete(OperationClaim operationClaim)
		{
			var result = _operationClaimService.Delete(operationClaim);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
	}
}
