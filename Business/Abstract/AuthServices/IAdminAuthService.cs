using Core.Utilities.Security.TokenEntities;
using Entities.Concrete;
using Entities.Dtos.LoginDtos;
using Entities.Dtos.RegisterDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.AuthServices
{
	public interface IAdminAuthService
	{
		Admin Register(AdminRegisterDto adminRegisterDto);
		Admin Login(AdminLoginDto adminLoginDto);
		bool UserExists(string email);
		AccessToken CreateAccessToken(Admin admin);
	}
}