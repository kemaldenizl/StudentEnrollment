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
	public class AdminOperationClaimManager : IAdminOperationClaimService
	{
		public IAdminOperationClaimDal _adminOperationClaimDal;
		public IAdminService _adminService;
		public AdminOperationClaimManager(IAdminOperationClaimDal adminOperationClaimDal, IAdminService adminService)
		{
			_adminOperationClaimDal = adminOperationClaimDal;
			_adminService = adminService;
		}
		public List<AdminOperationClaim> GetAll()
		{
			var result = _adminOperationClaimDal.GetAll();
			return result;
		}
		public List<AdminOperationClaim> GetAllByAdmin(int adminId)
		{
			var result = _adminOperationClaimDal.GetAll(a => a.AdminId == adminId);
			return result;
		}
		public List<AdminOperationClaim> GetAllByOperationClaim(int operationClaimId)
		{
			var result = _adminOperationClaimDal.GetAll(a => a.OperationClaimId == operationClaimId);
			return result;
		}
		public AdminOperationClaim GetById(int id)
		{
			var result = _adminOperationClaimDal.Get(a => a.Id == id);
			return result;
		}
		public AdminOperationClaim Add(AdminOperationClaim adminOperationClaim)
		{
			var result = _adminOperationClaimDal.Add(adminOperationClaim);
			return result;
		}
		public AdminOperationClaim Update(AdminOperationClaim adminOperationClaim)
		{
			var result = _adminOperationClaimDal.Update(adminOperationClaim);
			return result;
		}
		public AdminOperationClaim Delete(AdminOperationClaim adminOperationClaim)
		{
			var result = _adminOperationClaimDal.Delete(adminOperationClaim);
			return result;
		}

		public List<AdminOperationClaim> AddDefaultAdminOperationClaims(int id)
		{
			var admin = _adminService.Get(id);
			List<AdminOperationClaim> results = new List<AdminOperationClaim>();
			for (int i = 10; i <= 66; i++)
			{
				var result = Add(new AdminOperationClaim { AdminId = admin.Id, OperationClaimId = i });
				results.Add(result);
			}

			return results;
		}

		public List<AdminOperationClaim> DeleteAllByAdmin(int id)
		{
			var claims = GetAllByAdmin(id);
			foreach (var claim in claims)
			{
				var result = Delete(claim);
			}

			return claims;
		}
	}
}
