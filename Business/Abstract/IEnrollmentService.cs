using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IEnrollmentService
	{
		List<Enrollment> GetAll();
		public List<Enrollment> GetAllByStudent(int studentId);
		public List<Enrollment> GetAllByCourse(int courseId);
		Enrollment GetById(int id);
		void Add(Enrollment enrollment);
		void Update(Enrollment enrollment);
		void Delete(Enrollment enrollment);
	}
}
