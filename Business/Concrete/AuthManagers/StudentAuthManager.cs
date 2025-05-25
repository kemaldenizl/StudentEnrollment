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
	public class StudentAuthManager : IStudentAuthService
	{
		private IStudentService _studentService;
		private ITokenHelper<Student, OperationClaim> _tokenHelper;

		public StudentAuthManager(IStudentService studentService, ITokenHelper<Student, OperationClaim> tokenHelper)
		{
			_studentService = studentService;
			_tokenHelper = tokenHelper;
		}

		public IDataResult<AccessToken> CreateAccessToken(Student student)
		{
			var claims = _studentService.GetClaims(student);
			var accessToken = _tokenHelper.CreateToken(student, claims);

			return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
		}

		public IDataResult<Student> Login(StudentLoginDto studentLoginDto)
		{
			var studentToCheck = _studentService.GetByMail(studentLoginDto.Email);

			if (studentToCheck == null)
			{
				return new ErrorDataResult<Student>(Messages.UserNotFound);
			}

			if (!HashingHelper.VerifyPasswordHash(studentLoginDto.Password, studentToCheck.PasswordHash,
				    studentToCheck.PasswordSalt))
			{
				return new ErrorDataResult<Student>(Messages.PasswordError);
			}

			return new SuccessDataResult<Student>(studentToCheck, Messages.SuccessfulLogin);
		}

		public IDataResult<Student> Register(StudentRegisterDto studentRegisterDto)
		{
			byte[] passwordHash, passwordSalt;
			HashingHelper.CreatePasswordHash(studentRegisterDto.Password, out passwordHash, out passwordSalt);

			var student = new Student
			{
				FirstName = studentRegisterDto.FirstName,
				LastName = studentRegisterDto.LastName,
				Email = studentRegisterDto.Email,
				PasswordHash = passwordHash,
				PasswordSalt = passwordSalt,
				EnrollmentDate = studentRegisterDto.EnrollmentDate,
				Classroom = studentRegisterDto.Classroom,
			};

			_studentService.Add(student);

			return new SuccessDataResult<Student>(student, Messages.UserRegistered);
		}

		public IResult UserExists(string email)
		{
			if (_studentService.GetByMail(email) != null)
			{
				return new ErrorResult(Messages.UserAlreadyExists);
			}

			return new SuccessResult();
		}
	}
}
