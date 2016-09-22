using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Business.Configurations;
using TestProject.Business.Configurations.Impl;
using TestProject.Business.Services;
using TestProject.Business.Services.Impl;
using TestProject.DAL;
using TestProject.DAL.Repositories;
using TestProject.DAL.Repositories.Impl;
using TestProject.DAL.Uow;
using TestProject.DAL.Uow.Imple;

namespace TestProject.Business.Unity
{
    public static class Bootstrapper
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            // context
            container.RegisterType<Context>();
            container.RegisterType<DbContext, Context>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();

            // services
            container.RegisterType<ICustomerAndAddressService, CustomerAndAddressService>();

            // repositories
            container.RegisterType<ICustomerRepository, CustomerRepository>();

            // converter
            AutoMapperConfiguration.Initialize();
            container.RegisterType<IDataConverter, DataConverter>();
        }
    }
}
