using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
	public interface ICourseService
	{
		List<Course> GetAll();
		public List<Course> GetCoursesByTeacher(int teacherId);
		Course GetById(int id);
		void Add(Course course);
		void Update(Course course);
		void Delete(Course course);
	}
}
