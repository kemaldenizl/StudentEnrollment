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
	public class TeacherOperationClaimManager : ITeacherOperationClaimService
	{
		public ITeacherOperationClaimDal _teacherOperationClaimDal;
		public TeacherOperationClaimManager(ITeacherOperationClaimDal teacherOperationClaimDal)
		{
			_teacherOperationClaimDal = teacherOperationClaimDal;
		}
		public List<TeacherOperationClaim> GetAll()
		{
			var result = _teacherOperationClaimDal.GetAll();
			return result;
		}
		public List<TeacherOperationClaim> GetAllByTeacher(int teacherId)
		{
			var result = _teacherOperationClaimDal.GetAll(t => t.TeacherId == teacherId);
			return result;
		}
		public List<TeacherOperationClaim> GetAllByOperationClaim(int operationClaimId)
		{
			var result = _teacherOperationClaimDal.GetAll(t => t.OperationClaimId == operationClaimId);
			return result;
		}
		public TeacherOperationClaim GetById(int id)
		{
			var result = _teacherOperationClaimDal.Get(t => t.Id == id);
			return result;
		}
		public TeacherOperationClaim Add(TeacherOperationClaim teacherOperationClaim)
		{
			var result = _teacherOperationClaimDal.Add(teacherOperationClaim);
			return result;
		}
		public TeacherOperationClaim Update(TeacherOperationClaim teacherOperationClaim)
		{
			var result = _teacherOperationClaimDal.Update(teacherOperationClaim);
			return result;
		}
		public TeacherOperationClaim Delete(TeacherOperationClaim teacherOperationClaim)
		{
			var result = _teacherOperationClaimDal.Delete(teacherOperationClaim);
			return result;
		}
	}
}
