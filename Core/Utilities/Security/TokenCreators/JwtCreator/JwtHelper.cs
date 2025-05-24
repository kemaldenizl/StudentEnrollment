using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.TokenCreators.JwtCreator
{
	public class JwtHelper<TUser, TOperationClaim> : ITokenHelper<TUser, TOperationClaim>
		where TUser : class, IEntity, new()
		where TOperationClaim : class, IEntity, new()
	{
	}
}
