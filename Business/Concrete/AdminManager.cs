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
	public class AdminManager : IAdminService
	{
		private IAdminDal _adminDal;

		public AdminManager(IAdminDal adminDal)
		{
			_adminDal = adminDal;
		}
		public List<OperationClaim> GetClaims(Admin admin)
		{
			return _adminDal.GetClaims(admin);
		}

		public void Add(Admin admin)
		{
			throw new NotImplementedException();
		}

		public Admin GetByMail(string email)
		{
			throw new NotImplementedException();
		}
	}
}
