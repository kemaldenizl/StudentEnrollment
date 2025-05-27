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
		public void Add(TeacherOperationClaim teacherOperationClaim)
		{
			_teacherOperationClaimDal.Add(teacherOperationClaim);
		}
		public void Update(TeacherOperationClaim teacherOperationClaim)
		{
			_teacherOperationClaimDal.Update(teacherOperationClaim);
		}
		public void Delete(TeacherOperationClaim teacherOperationClaim)
		{
			_teacherOperationClaimDal.Delete(teacherOperationClaim);
		}
	}
}
