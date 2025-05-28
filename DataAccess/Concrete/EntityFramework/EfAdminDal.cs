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
	public class EfAdminDal : EfEntityRepositoryBase<Admin, StudentEnrollmentContext>, IAdminDal
	{
		public List<OperationClaim> GetClaims(Admin admin)
		{
			using (var context = new StudentEnrollmentContext())
			{
				var result = from operationClaim in context.OperationClaims
					join AdminOperationClaim in context.AdminOperationClaims
						on operationClaim.Id equals AdminOperationClaim.OperationClaimId
					where AdminOperationClaim.AdminId == admin.Id
					select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name, Description = operationClaim.Description };

				return result.ToList();
			}
		}

		public bool IsEmailExists(string email)
		{
			using (var context = new StudentEnrollmentContext())
			{
				var result = context.Students.Select(s => s.Email)
					.Union(context.Teachers.Select(t => t.Email));

				return result.Any(e => e == email);
			}
		}
	}
}
