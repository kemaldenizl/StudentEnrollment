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
	public class TeacherAuthManager : ITeacherAuthService
	{
		private ITeacherService _teacherService;
		private ITokenHelper<Teacher, OperationClaim> _tokenHelper;

		public TeacherAuthManager(ITeacherService teacherService, ITokenHelper<Teacher, OperationClaim> tokenHelper)
		{
			_teacherService = teacherService;
			_tokenHelper = tokenHelper;
		}

		public AccessToken CreateAccessToken(Teacher teacher)
		{
			var claims = _teacherService.GetClaims(teacher);
			var accessToken = _tokenHelper.CreateToken(teacher, claims);

			return accessToken;
		}

		public Teacher Login(TeacherLoginDto teacherLoginDto)
		{
			var teacherToCheck = _teacherService.GetByMail(teacherLoginDto.Email); //first check if the teacher exists

			if (teacherToCheck == null) //if teacher not found return error
			{
				throw new NotFoundException(Messages.UserNotFound);
			}

			if (!HashingHelper.VerifyPasswordHash(teacherLoginDto.Password, teacherToCheck.PasswordHash,teacherToCheck.PasswordSalt)) //check if the password is false return error
			{
				throw new UnauthorizedException(Messages.PasswordError);
			}

			return teacherToCheck; //return teacher entity.
		}

		public Teacher Register(TeacherRegisterDto teacherRegisterDto)
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

			return teacher; //return teacher entity
		}

		public bool UserExists(string email)
		{
			if (_teacherService.GetByMail(email) != null)
			{
				return true; //if user exists return false
			}

			return false; //if user not exists return true
		}
	}
}
