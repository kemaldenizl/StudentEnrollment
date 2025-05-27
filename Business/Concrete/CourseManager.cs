using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
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

		public List<Course> GetAll()
		{
			var result = _courseDal.GetAll();

			return result;
		}

		public List<Course> GetAllByTeacher(int teacherId)
		{
			var result = _courseDal.GetAll(c => c.TeacherId == teacherId);

			return result;
		}

		public Course GetById(int id)
		{
			var result = _courseDal.Get(c => c.Id == id);

			return result;
		}

		public void Add(Course course)
		{
			_courseDal.Add(course);
		}

		public void Update(Course course)
		{
			_courseDal.Update(course);
		}

		public void Delete(Course course)
		{
			_courseDal.Delete(course);
		}
	}
}
