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
using Entities.Concrete;

namespace Business.Concrete
{
	public class CourseManager : ICourseService
	{
		public ICourseDal _courseDal;

		public CourseManager(ICourseDal courseDal)
		{
			_courseDal = courseDal;
		}

		public IDataResult<List<Course>> GetAll()
		{
			var result = _courseDal.GetAll();

			if (result == null)
			{
				return new ErrorDataResult<List<Course>>(Messages.ErrorGetData);
			}

			return new SuccessDataResult<List<Course>>(result, Messages.SuccessGetData);
		}

		public IDataResult<Course> GetById(int id)
		{
			var result = _courseDal.Get(c => c.Id == id);

			if (result == null)
			{
				return new ErrorDataResult<Course>(Messages.ErrorGetData);
			}

			return new SuccessDataResult<Course>(result, Messages.SuccessGetData);
		}

		public IResult Add(Course course)
		{
			_courseDal.Add(course);
			return new SuccessResult(Messages.SuccessAddData);
		}

		public IResult Update(Course course)
		{
			_courseDal.Update(course);
			return new SuccessResult(Messages.SuccessUpdateData);
		}

		public IResult Delete(Course course)
		{
			_courseDal.Delete(course);
			return new SuccessResult(Messages.SuccessDeleteData);
		}
	}
}
