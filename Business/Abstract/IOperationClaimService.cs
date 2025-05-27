﻿using Core.Utilities.Results.Abstract;
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
		IDataResult<List<OperationClaim>> GetAll();
		IDataResult<OperationClaim> GetById(int id);
		IResult Add(OperationClaim operationClaim);
		IResult Update(OperationClaim operationClaim);
		IResult Delete(OperationClaim operationClaim);
	}
}
