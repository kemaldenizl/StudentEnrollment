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
		void Add(OperationClaim operationClaim);
		void Update(OperationClaim operationClaim);
		void Delete(OperationClaim operationClaim);
	}
}
