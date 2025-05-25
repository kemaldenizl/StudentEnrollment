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
	public class TeacherAuthManager : ITeacherAuthService
	{
		private ITeacherService _teacherService;
		private ITokenHelper<Teacher, OperationClaim> _tokenHelper;

		public TeacherAuthManager(ITeacherService teacherService, ITokenHelper<Teacher, OperationClaim> tokenHelper)
		{
			_teacherService = teacherService;
			_tokenHelper = tokenHelper;
		}
	}
}
