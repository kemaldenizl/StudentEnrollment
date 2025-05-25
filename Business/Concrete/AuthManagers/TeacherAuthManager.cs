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
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.TokenCreators;
using Core.Utilities.Security.TokenEntities;
using Entities.Concrete;
using Entities.Dtos.LoginDtos;
using Entities.Dtos.RegisterDtos;

namespace Business.Concrete.AuthManagers
{
	public class TeacherAuthManager : ITeacherAuthService
	{
		private ITeacherService _teacherService;
		private ITokenHelper<Teacher, OperationClaim> _tokenHelper;

		public TeacherAuthManager(ITeacherService teacherService, ITokenHelper<Teacher, OperationClaim> tokenHelper)
		{
			_teacherService = teacherService;
			_tokenHelper = tokenHelper;
		}

		public IDataResult<AccessToken> CreateAccessToken(Teacher teacher)
		{
			var claims = _teacherService.GetClaims(teacher);
			var accessToken = _tokenHelper.CreateToken(teacher, claims);

			return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
		}

		public IDataResult<Teacher> Login(TeacherLoginDto teacherLoginDto)
		{
			var teacherToCheck = _teacherService.GetByMail(teacherLoginDto.Email); //first check if the teacher exists

			if (teacherToCheck == null) //if teacher not found return error
			{
				return new ErrorDataResult<Teacher>(Messages.UserNotFound);
			}

			if (!HashingHelper.VerifyPasswordHash(teacherLoginDto.Password, teacherToCheck.PasswordHash,teacherToCheck.PasswordSalt)) //check if the password is false
			{
				return new ErrorDataResult<Teacher>(Messages.PasswordError);
			}

			return new SuccessDataResult<Teacher>(teacherToCheck, Messages.SuccessfulLogin); //Success login operation return teacher entity.
		}

		public IDataResult<Teacher> Register(TeacherRegisterDto teacherRegisterDto)
		{
			byte[] passwordHash, passwordSalt;
			HashingHelper.CreatePasswordHash(teacherRegisterDto.Password, out passwordHash, out passwordSalt); //turn password into hash and salt

			var teacher = new Teacher //creating teacher entity from teacherRegisterDto
			{
				FirstName = teacherRegisterDto.FirstName,
				LastName = teacherRegisterDto.LastName,
				Email = teacherRegisterDto.Email,
				PasswordHash = passwordHash,
				PasswordSalt = passwordSalt,
				HireDate = teacherRegisterDto.HireDate,
				Department = teacherRegisterDto.Department
			};

			_teacherService.Add(teacher); //adding teacher to database

			return new SuccessDataResult<Teacher>(teacher, Messages.UserRegistered); //return success result with teacher entity
		}
	}
}
