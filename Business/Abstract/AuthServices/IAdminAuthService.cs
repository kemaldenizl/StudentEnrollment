using Core.Utilities.Results.Abstract;
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
		IDataResult<Admin> Register(AdminRegisterDto adminRegisterDto);
		IDataResult<Admin> Login(AdminLoginDto adminLoginDto);
		IResult UserExists(string email);
		IDataResult<AccessToken> CreateAccessToken(Admin admin);
	}
}