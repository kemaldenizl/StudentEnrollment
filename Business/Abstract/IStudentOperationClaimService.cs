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
		void Add(StudentOperationClaim studentOperationClaim);
		void Update(StudentOperationClaim studentOperationClaim);
		void Delete(StudentOperationClaim studentOperationClaim);
	}
}
