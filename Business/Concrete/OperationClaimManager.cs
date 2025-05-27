using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.Concrete
{
	public class OperationClaimManager : IOperationClaimService
	{
		public IOperationClaimDal _operationClaimDal;

		public OperationClaimManager(IOperationClaimDal operationClaimDal)
		{
			_operationClaimDal = operationClaimDal;
		}

		public List<OperationClaim> GetAll()
		{
			var result = _operationClaimDal.GetAll();

			return result;
		}

		public OperationClaim GetById(int id)
		{
			var result = _operationClaimDal.Get(o => o.Id == id);

			return result;
		}

		public OperationClaim Add(OperationClaim operationClaim)
		{
			var result = _operationClaimDal.Add(operationClaim);
			return result;
		}

		public OperationClaim Update(OperationClaim operationClaim)
		{
			var result = _operationClaimDal.Update(operationClaim);
			return result;
		}

		public OperationClaim Delete(OperationClaim operationClaim)
		{
			var result = _operationClaimDal.Delete(operationClaim);
			return result;
		}
	}
}
