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
	public class StudentOperationClaimManager : IStudentOperationClaimService
	{
		public IStudentOperationClaimDal _studentOperationClaimDal;
		public IStudentService _studentService;
		public StudentOperationClaimManager(IStudentOperationClaimDal studentOperationClaimDal, IStudentService studentService)
		{
			_studentOperationClaimDal = studentOperationClaimDal;
			_studentService = studentService;
		}

		public List<StudentOperationClaim> GetAll()
		{
			var result = _studentOperationClaimDal.GetAll();
			return result;
		}
		public List<StudentOperationClaim> GetAllByStudent(int studentId)
		{
			var result = _studentOperationClaimDal.GetAll(s => s.StudentId == studentId);
			return result;
		}
		public List<StudentOperationClaim> GetAllByOperationClaim(int operationClaimId)
		{
			var result = _studentOperationClaimDal.GetAll(s => s.OperationClaimId == operationClaimId);
			return result;
		}
		public StudentOperationClaim GetById(int id)
		{
			var result = _studentOperationClaimDal.Get(s => s.Id == id);
			return result;
		}
		public StudentOperationClaim Add(StudentOperationClaim studentOperationClaim)
		{
			var result = _studentOperationClaimDal.Add(studentOperationClaim);
			return result;
		}
		public StudentOperationClaim Update(StudentOperationClaim studentOperationClaim)
		{
			var result = _studentOperationClaimDal.Update(studentOperationClaim);
			return result;
		}
		public StudentOperationClaim Delete(StudentOperationClaim studentOperationClaim)
		{
			var result = _studentOperationClaimDal.Delete(studentOperationClaim);
			return result;
		}

		public List<StudentOperationClaim> AddDefaultStudentOperationClaims(int id)
		{
			var student = _studentService.Get(id);
			List<StudentOperationClaim> results = new List<StudentOperationClaim>();
			for (int i = 37; i <= 53; i= i + 8)
			{
				var result = Add(new StudentOperationClaim { StudentId = student.Id, OperationClaimId = i });
				results.Add(result);
			}

			return results;
		}
		public List<StudentOperationClaim> DeleteAllByStudent(int id)
		{
			var claims = GetAllByStudent(id);
			foreach (var claim in claims)
			{
				var result = Delete(claim);
			}

			return claims;
		}
	}
}
