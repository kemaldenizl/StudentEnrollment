using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
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
			_adminDal.Add(admin);
		}

		public Admin GetByMail(string email)
		{
			return _adminDal.Get(a => a.Email == email);
		}

		public List<Admin> GetAll()
		{
			var result = _adminDal.GetAll();
			foreach (var admin in result)
			{
				admin.PasswordHash = null;
				admin.PasswordSalt = null;
			}
			return result;
		}

		public Admin Get(int id)
		{
			var result = _adminDal.Get(a => a.Id == id);
			result.PasswordHash = null;
			result.PasswordSalt = null;
			return result;
		}

		public void Delete(Admin admin)
		{
			_adminDal.Delete(admin);
		}
	}
}
