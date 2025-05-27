using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete.DataResultTypes;
using Core.Utilities.Results.Concrete.ResultTypes;
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

		public IDataResult<List<OperationClaim>> GetAll()
		{
			var result = _operationClaimDal.GetAll();

			if (result == null)
			{
				return new ErrorDataResult<List<OperationClaim>>(Messages.ErrorGetData);
			}

			return new SuccessDataResult<List<OperationClaim>>(result, Messages.SuccessGetData);
		}

		public IDataResult<OperationClaim> GetById(int id)
		{
			var result = _operationClaimDal.Get(o => o.Id == id);

			if (result == null)
			{
				return new ErrorDataResult<OperationClaim>(Messages.ErrorGetData);
			}

			return new SuccessDataResult<OperationClaim>(result, Messages.SuccessGetData);
		}

		public IResult Add(OperationClaim operationClaim)
		{
			_operationClaimDal.Add(operationClaim);
			return new SuccessResult(Messages.SuccessAddData);
		}

		public IResult Update(OperationClaim operationClaim)
		{
			_operationClaimDal.Update(operationClaim);
			return new SuccessResult(Messages.SuccessUpdateData);
		}

		public IResult Delete(OperationClaim operationClaim)
		{
			_operationClaimDal.Delete(operationClaim);
			return new SuccessResult(Messages.SuccessDeleteData);
		}
	}
}
