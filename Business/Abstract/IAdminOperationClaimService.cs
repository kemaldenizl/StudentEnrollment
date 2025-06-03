using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IAdminOperationClaimService
	{
		List<AdminOperationClaim> GetAll();
		public List<AdminOperationClaim> GetAllByAdmin(int adminId);
		public List<AdminOperationClaim> GetAllByOperationClaim(int operationClaimId);
		AdminOperationClaim GetById(int id);
		AdminOperationClaim Add(AdminOperationClaim adminOperationClaim);
		AdminOperationClaim Update(AdminOperationClaim adminOperationClaim);
		AdminOperationClaim Delete(AdminOperationClaim adminOperationClaim);
		List<AdminOperationClaim> AddDefaultAdminOperationClaims(int id);
		List<AdminOperationClaim> DeleteAllByAdmin(int id);
	}
}
