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
	public class EfTeacherDal : EfEntityRepositoryBase<Teacher, StudentEnrollmentContext>, ITeacherDal
	{
		public List<OperationClaim> GetClaims(Teacher teacher)
		{
			using (var context = new StudentEnrollmentContext())
			{
				var result = from operationClaim in context.OperationClaims
					join TeacherOperationClaim in context.TeacherOperationClaims
						on operationClaim.Id equals TeacherOperationClaim.OperationClaimId
					where TeacherOperationClaim.TeacherId == teacher.Id
					select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };

				return result.ToList();
			}
		}
	}
}
