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
	public class EnrollmentManager : IEnrollmentService
	{
		public IEnrollmentDal _enrollmentDal;

		public EnrollmentManager(IEnrollmentDal enrollmentDal)
		{
			_enrollmentDal = enrollmentDal;
		}

		public IDataResult<List<Enrollment>> GetAll()
		{
			var result = _enrollmentDal.GetAll();

			if (result == null)
			{
				return new ErrorDataResult<List<Enrollment>>(Messages.ErrorGetData);
			}

			return new SuccessDataResult<List<Enrollment>>(result, Messages.SuccessGetData);
		}

		public IDataResult<Enrollment> GetById(int id)
		{
			var result = _enrollmentDal.Get(e => e.Id == id);

			if (result == null)
			{
				return new ErrorDataResult<Enrollment>(Messages.ErrorGetData);
			}

			return new SuccessDataResult<Enrollment>(result, Messages.SuccessGetData);
		}

		public IResult Add(Enrollment enrollment)
		{
			_enrollmentDal.Add(enrollment);
			return new SuccessResult(Messages.SuccessAddData);
		}

		public IResult Update(Enrollment enrollment)
		{
			_enrollmentDal.Update(enrollment);
			return new SuccessResult(Messages.SuccessUpdateData);
		}

		public IResult Delete(Enrollment enrollment)
		{
			_enrollmentDal.Delete(enrollment);
			return new SuccessResult(Messages.SuccessDeleteData);
		}
	}
}
