using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Business.Abstract;
using Business.Abstract.AuthServices;
using Business.Concrete;
using Business.Concrete.AuthManagers;
using Core.Utilities.Security.TokenCreators.JwtCreator;
using Core.Utilities.Security.TokenCreators;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.DependencyResolvers.Autofac
{
	public class AutofacBusinessModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<JwtHelper<Student, OperationClaim>>().As<ITokenHelper<Student, OperationClaim>>();
			builder.RegisterType<EfStudentDal>().As<IStudentDal>();
			builder.RegisterType<StudentManager>().As<IStudentService>();
			builder.RegisterType<StudentAuthManager>().As<IStudentAuthService>();
		}
	}
}
