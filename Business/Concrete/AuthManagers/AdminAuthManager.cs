using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Abstract.AuthServices;
using Business.Constants;
using Core.Utilities.Exceptions;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.TokenCreators;
using Core.Utilities.Security.TokenEntities;
using Entities.Concrete;
using Entities.Dtos.LoginDtos;
using Entities.Dtos.RegisterDtos;

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
		public AccessToken CreateAccessToken(Admin admin)
		{
			var claims = _adminService.GetClaims(admin);
			var accessToken = _tokenHelper.CreateToken(admin, claims);

			return accessToken;
		}
		public Admin Login(AdminLoginDto adminLoginDto)
		{
			var adminToCheck = _adminService.GetByMail(adminLoginDto.Email);

			if (adminToCheck == null)
			{
				throw new NotFoundException(Messages.UserNotFound);
			}

			if (!HashingHelper.VerifyPasswordHash(adminLoginDto.Password, adminToCheck.PasswordHash, adminToCheck.PasswordSalt))
			{
				throw new UnauthorizedException(Messages.PasswordError);
			}

			return adminToCheck;
		}
		public Admin Register(AdminRegisterDto adminRegisterDto)
		{
			byte[] passwordHash, passwordSalt;
			HashingHelper.CreatePasswordHash(adminRegisterDto.Password, out passwordHash, out passwordSalt);

			var admin = new Admin
			{
				Email = adminRegisterDto.Email,
				PasswordHash = passwordHash,
				PasswordSalt = passwordSalt,
				FirstName = adminRegisterDto.FirstName,
				LastName = adminRegisterDto.LastName,
				Position = adminRegisterDto.Position,
			};

			_adminService.Add(admin);
			return admin;
		}
		public bool UserExists(string email)
		{
			if (_adminService.GetByMail(email) != null)
			{
				return true;
			}

			return false;
		}
	}
}
