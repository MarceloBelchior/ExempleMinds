using Autofac;
using Microsoft.Extensions.Configuration;
using Minds.DataEF.Rerpository;

namespace Minds.DI
{
    public class Integration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var _env = System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var config = new ConfigurationBuilder()
         .SetBasePath(Directory.GetCurrentDirectory())
         .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
         .AddJsonFile(string.Format("appsettings.{0}.json", _env), optional: true);

            var configuration = config?.Build();
            builder.RegisterInstance(configuration);

        

            builder.RegisterType<Minds.Business.EmployeeBS>().As<Minds.Interface.Domain.IEmployeeBS>();
            builder.RegisterType<Minds.Business.DepartamentBS>().As<Minds.Interface.Domain.IDepartamentBS>();

            builder.RegisterType<EmployeeRepository>().As<Minds.Interface.Repository.IEmployeeRepository>();
            builder.RegisterType<DepartamentRepository>().As<Minds.Interface.Repository.IDepartamentRepository>();


        }
    }
}
