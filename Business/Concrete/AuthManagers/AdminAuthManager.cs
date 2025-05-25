using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Abstract.AuthServices;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete.DataResultTypes;
using Core.Utilities.Results.Concrete.ResultTypes;
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
		public IDataResult<AccessToken> CreateAccessToken(Admin admin)
		{
			var claims = _adminService.GetClaims(admin);
			var accessToken = _tokenHelper.CreateToken(admin, claims);

			return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
		}
		public IDataResult<Admin> Login(AdminLoginDto adminLoginDto)
		{
			var adminToCheck = _adminService.GetByMail(adminLoginDto.Email);

			if (adminToCheck == null)
			{
				return new ErrorDataResult<Admin>(Messages.UserNotFound);
			}

			if (!HashingHelper.VerifyPasswordHash(adminLoginDto.Password, adminToCheck.PasswordHash, adminToCheck.PasswordSalt))
			{
				return new ErrorDataResult<Admin>(Messages.PasswordError);
			}

			return new SuccessDataResult<Admin>(adminToCheck, Messages.SuccessfulLogin);
		}
		public IDataResult<Admin> Register(AdminRegisterDto adminRegisterDto)
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
			return new SuccessDataResult<Admin>(admin, Messages.UserRegistered);
		}
		public IResult UserExists(string email)
		{
			if (_adminService.GetByMail(email) != null)
			{
				return new ErrorResult(Messages.UserAlreadyExists);
			}
			return new SuccessResult();
		}
	}
}
