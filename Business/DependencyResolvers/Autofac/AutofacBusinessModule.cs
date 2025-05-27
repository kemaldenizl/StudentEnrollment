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

			builder.RegisterType<JwtHelper<Teacher, OperationClaim>>().As<ITokenHelper<Teacher, OperationClaim>>();
			builder.RegisterType<EfTeacherDal>().As<ITeacherDal>();
			builder.RegisterType<TeacherManager>().As<ITeacherService>();
			builder.RegisterType<TeacherAuthManager>().As<ITeacherAuthService>();

			builder.RegisterType<JwtHelper<Admin, OperationClaim>>().As<ITokenHelper<Admin, OperationClaim>>();
			builder.RegisterType<EfAdminDal>().As<IAdminDal>();
			builder.RegisterType<AdminManager>().As<IAdminService>();
			builder.RegisterType<AdminAuthManager>().As<IAdminAuthService>();

			builder.RegisterType<EfCourseDal>().As<ICourseDal>();
			builder.RegisterType<CourseManager>().As<ICourseService>();
			builder.RegisterType<EfEnrollmentDal>().As<IEnrollmentDal>();
			builder.RegisterType<EnrollmentManager>().As<IEnrollmentService>();
		}
	}
}
