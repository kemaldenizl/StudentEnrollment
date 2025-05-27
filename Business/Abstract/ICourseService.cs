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
		public List<Course> GetAllByTeacher(int teacherId);
		Course GetById(int id);
		Course Add(Course course);
		Course Update(Course course);
		Course Delete(Course course);
	}
}
