using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
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

		public List<Enrollment> GetAll()
		{
			var result = _enrollmentDal.GetAll();

			return result;
		}
		public List<Enrollment> GetEnrollmentsByStudent(int studentId)
		{
			var result = _enrollmentDal.GetAll(e => e.StudentId == studentId);

			return result;
		}
		public List<Enrollment> GetEnrollmentsByCourse(int courseId)
		{
			var result = _enrollmentDal.GetAll(e => e.CourseId == courseId);

			return result;
		}

		public Enrollment GetById(int id)
		{
			var result = _enrollmentDal.Get(e => e.Id == id);

			return result;
		}

		public void Add(Enrollment enrollment)
		{
			_enrollmentDal.Add(enrollment);
		}

		public void Update(Enrollment enrollment)
		{
			_enrollmentDal.Update(enrollment);
		}

		public void Delete(Enrollment enrollment)
		{
			_enrollmentDal.Delete(enrollment);
		}
	}
}
