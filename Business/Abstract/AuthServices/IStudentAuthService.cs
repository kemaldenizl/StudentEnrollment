using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.TokenEntities;
using Entities.Concrete;
using Entities.Dtos.LoginDtos;
using Entities.Dtos.RegisterDtos;

namespace Business.Abstract.AuthServices
{
	public interface IStudentAuthService
	{
		IDataResult<Student> Register(StudentRegisterDto studentRegisterDto);
		IDataResult<Student> Login(StudentLoginDto studentLoginDto);
		IResult UserExists(string email);
		IDataResult<AccessToken> CreateAccessToken(Student student);
	}
}