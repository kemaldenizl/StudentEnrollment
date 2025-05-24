using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Abstract
{
	public interface IAdminDal : IEntityRepository<Admin>
	{
		List<OperationClaim> GetClaims(Admin admin);
	}
}
