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
		public ITeacherService _teacherService;
		public TeacherOperationClaimManager(ITeacherOperationClaimDal teacherOperationClaimDal, ITeacherService teacherService)
		{
			_teacherOperationClaimDal = teacherOperationClaimDal;
			_teacherService = teacherService;
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
		public List<TeacherOperationClaim> AddDefaultTeacherOperationClaims(int id)
		{
			var teacher = _teacherService.Get(id);
			List<TeacherOperationClaim> results = new List<TeacherOperationClaim>();
			for (int i = 40; i <= 46; i++)
			{
				var result = Add(new TeacherOperationClaim { TeacherId = teacher.Id, OperationClaimId = i });
				results.Add(result);
			}
			var teacherOperationClaim1 = Add(new TeacherOperationClaim { TeacherId = teacher.Id, OperationClaimId = 36 });
			results.Add(teacherOperationClaim1);
			var teacherOperationClaim2 = Add(new TeacherOperationClaim { TeacherId = teacher.Id, OperationClaimId = 38 });
			results.Add(teacherOperationClaim2);
			var teacherOperationClaim3 = Add(new TeacherOperationClaim { TeacherId = teacher.Id, OperationClaimId = 51 });
			results.Add(teacherOperationClaim3);
			var teacherOperationClaim4 = Add(new TeacherOperationClaim { TeacherId = teacher.Id, OperationClaimId = 53 });
			results.Add(teacherOperationClaim4);
			var teacherOperationClaim5 = Add(new TeacherOperationClaim { TeacherId = teacher.Id, OperationClaimId = 54 });
			results.Add(teacherOperationClaim5);
			return results;
		}
	}
}
