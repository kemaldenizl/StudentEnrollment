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
		public StudentOperationClaimManager(IStudentOperationClaimDal studentOperationClaimDal)
		{
			_studentOperationClaimDal = studentOperationClaimDal;
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
		public void Add(StudentOperationClaim studentOperationClaim)
		{
			_studentOperationClaimDal.Add(studentOperationClaim);
		}
		public void Update(StudentOperationClaim studentOperationClaim)
		{
			_studentOperationClaimDal.Update(studentOperationClaim);
		}
		public void Delete(StudentOperationClaim studentOperationClaim)
		{
			_studentOperationClaimDal.Delete(studentOperationClaim);
		}
	}
}
