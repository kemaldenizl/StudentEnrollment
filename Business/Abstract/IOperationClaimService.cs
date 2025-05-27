using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IOperationClaimService
	{
		List<OperationClaim> GetAll();
		OperationClaim GetById(int id);
		OperationClaim Add(OperationClaim operationClaim);
		OperationClaim Update(OperationClaim operationClaim);
		OperationClaim Delete(OperationClaim operationClaim);
	}
}
