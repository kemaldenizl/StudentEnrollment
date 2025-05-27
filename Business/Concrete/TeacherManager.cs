using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;

namespace Business.Concrete
{
	public class TeacherManager : ITeacherService
	{
		private ITeacherDal _teacherDal;

		public TeacherManager(ITeacherDal teacherDal)
		{
			_teacherDal = teacherDal;
		}
		public List<OperationClaim> GetClaims(Teacher teacher)
		{
			return _teacherDal.GetClaims(teacher);
		}

		public void Add(Teacher teacher)
		{
			_teacherDal.Add(teacher);
		}

		public Teacher GetByMail(string email)
		{
			return _teacherDal.Get(t => t.Email == email);
		}

		public List<Teacher> GetAll()
		{
			var result = _teacherDal.GetAll();
			foreach (var teacher in result)
			{
				teacher.PasswordHash = null;
				teacher.PasswordSalt = null;
			}
			return result;
		}

		public Teacher Get(int id)
		{
			var result = _teacherDal.Get(t => t.Id == id);
			result.PasswordHash = null;
			result.PasswordSalt = null;
			return result;
		}

		public void Delete(Teacher teacher)
		{
			_teacherDal.Delete(teacher);
		}
	}
}
