using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfStudentDal : EfEntityRepositoryBase<Student, StudentEnrollmentContext>, IStudentDal
	{
		public List<OperationClaim> GetClaims(Student student)
		{
			using (var context = new StudentEnrollmentContext())
			{
				var result = from operationClaim in context.OperationClaims
					join StudentOperationClaim in context.StudentOperationClaims
						on operationClaim.Id equals StudentOperationClaim.OperationClaimId
					where StudentOperationClaim.StudentId == student.Id
					select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name, Description = operationClaim.Description };

				return result.ToList();
			}
		}

		public bool IsEmailExists(string email)
		{
			using (var context = new StudentEnrollmentContext())
			{
				var result = context.Admins.Select(a => a.Email)
					.Union(context.Teachers.Select(t => t.Email));

				return result.Any(e => e == email);
			}
		}
	}
}
