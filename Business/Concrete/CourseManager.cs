using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;

namespace Business.Concrete
{
	public class CourseManager : ICourseService
	{
		public ICourseDal _courseDal;

		public CourseManager(ICourseDal courseDal)
		{
			_courseDal = courseDal;
		}
	}
}
