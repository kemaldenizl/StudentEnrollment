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

		public void Add(OperationClaim operationClaim)
		{
			_operationClaimDal.Add(operationClaim);
		}

		public void Update(OperationClaim operationClaim)
		{
			_operationClaimDal.Update(operationClaim);
		}

		public void Delete(OperationClaim operationClaim)
		{
			_operationClaimDal.Delete(operationClaim);
		}
	}
}
