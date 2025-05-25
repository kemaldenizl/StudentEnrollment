using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Abstract.AuthServices;
using Core.Utilities.Security.TokenCreators;
using Entities.Concrete;

namespace Business.Concrete.AuthManagers
{
	public class AdminAuthManager : IAdminAuthService
	{
		private IAdminService _adminService;
		private ITokenHelper<Admin, OperationClaim> _tokenHelper;

		public AdminAuthManager(IAdminService adminService, ITokenHelper<Admin, OperationClaim> tokenHelper)
		{
			_adminService = adminService;
			_tokenHelper = tokenHelper;
		}

	}
}
