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
		public AdminOperationClaimManager(IAdminOperationClaimDal adminOperationClaimDal)
		{
			_adminOperationClaimDal = adminOperationClaimDal;
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
		public void Add(AdminOperationClaim adminOperationClaim)
		{
			_adminOperationClaimDal.Add(adminOperationClaim);
		}
		public void Update(AdminOperationClaim adminOperationClaim)
		{
			_adminOperationClaimDal.Update(adminOperationClaim);
		}
		public void Delete(AdminOperationClaim adminOperationClaim)
		{
			_adminOperationClaimDal.Delete(adminOperationClaim);
		}
	}
}
