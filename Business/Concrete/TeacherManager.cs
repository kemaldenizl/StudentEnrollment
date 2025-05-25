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
	}
}
