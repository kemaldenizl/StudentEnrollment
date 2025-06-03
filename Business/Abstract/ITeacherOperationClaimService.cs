using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface ITeacherOperationClaimService
	{
		List<TeacherOperationClaim> GetAll();
		public List<TeacherOperationClaim> GetAllByTeacher(int teacherId);
		public List<TeacherOperationClaim> GetAllByOperationClaim(int operationClaimId);
		TeacherOperationClaim GetById(int id);
		TeacherOperationClaim Add(TeacherOperationClaim teacherOperationClaim);
		TeacherOperationClaim Update(TeacherOperationClaim teacherOperationClaim);
		TeacherOperationClaim Delete(TeacherOperationClaim teacherOperationClaim);
		List<TeacherOperationClaim> AddDefaultTeacherOperationClaims(int id);
		List<TeacherOperationClaim> DeleteAllByTeacher(int id);
	}
}
