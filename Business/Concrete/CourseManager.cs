using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
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
			throw new NotImplementedException();
		}

		public IDataResult<Course> GetById(int id)
		{
			throw new NotImplementedException();
		}

		public IResult Add(Course course)
		{
			throw new NotImplementedException();
		}

		public IResult Update(Course course)
		{
			throw new NotImplementedException();
		}

		public IResult Delete(Course course)
		{
			throw new NotImplementedException();
		}
	}
}
