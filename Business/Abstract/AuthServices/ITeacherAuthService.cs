using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Security.TokenEntities;
using Entities.Concrete;
using Entities.Dtos.LoginDtos;
using Entities.Dtos.RegisterDtos;

namespace Business.Abstract.AuthServices
{
	public interface ITeacherAuthService
	{
		Teacher Register(TeacherRegisterDto teacherRegisterDto);
		Teacher Login(TeacherLoginDto teacherLoginDto);
		bool UserExists(string email);
		AccessToken CreateAccessToken(Teacher teacher);
	}
}