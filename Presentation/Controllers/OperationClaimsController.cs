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
			return NotFound(new ErrorResponse(Messages.DataNotFound));
		}

		[HttpGet("{id}")]
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
		public IActionResult Add(OperationClaim operationClaim)
		{
			var result = _operationClaimService.Add(operationClaim);
			return Ok(result);
		}

		[HttpPut("update")]
		public IActionResult Update(OperationClaim operationClaim)
		{
			var result = _operationClaimService.Update(operationClaim);
			return Ok(result);
		}

		[HttpDelete("delete")]
		public IActionResult Delete(OperationClaim operationClaim)
		{
			var result = _operationClaimService.Delete(operationClaim);
			return Ok(result);
		}
	}
}
