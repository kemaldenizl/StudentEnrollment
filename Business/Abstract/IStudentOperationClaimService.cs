using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IStudentOperationClaimService
	{
		List<StudentOperationClaim> GetAll();
		public List<StudentOperationClaim> GetAllByStudent(int studentId);
		public List<StudentOperationClaim> GetAllByOperationClaim(int operationClaimId);
		StudentOperationClaim GetById(int id);
		StudentOperationClaim Add(StudentOperationClaim studentOperationClaim);
		StudentOperationClaim Update(StudentOperationClaim studentOperationClaim);
		StudentOperationClaim Delete(StudentOperationClaim studentOperationClaim);
		List<StudentOperationClaim> AddDefaultStudentOperationClaims(int id);
		List<StudentOperationClaim> DeleteAllByStudent(int id);
	}
}
