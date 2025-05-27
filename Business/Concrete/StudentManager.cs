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
	public class StudentManager : IStudentService
	{
		private IStudentDal _studentDal;

		public StudentManager(IStudentDal studentDal)
		{
			_studentDal = studentDal;
		}

		public List<OperationClaim> GetClaims(Student student)
		{
			return _studentDal.GetClaims(student);
		}

		public void Add(Student student)
		{
			_studentDal.Add(student);
		}

		public Student GetByMail(string email)
		{
			return _studentDal.Get(s => s.Email == email);
		}
		public List<Student> GetAll()
		{
			var result = _studentDal.GetAll();
			return result;
		}

		public Student Get(int id)
		{
			var result = _studentDal.Get(s => s.Id == id);
			return result;
		}

		public void Delete(Student student)
		{
			_studentDal.Delete(student);
		}
	}
}