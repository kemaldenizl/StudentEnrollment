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
using Core.Utilities.Security.TokenCreators;
using Core.Utilities.Security.TokenEntities;
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

		public IDataResult<AccessToken> CreateAccessToken(Teacher teacher)
		{
			var claims = _teacherService.GetClaims(teacher);
			var accessToken = _tokenHelper.CreateToken(teacher, claims);

			return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
		}
	}
}
