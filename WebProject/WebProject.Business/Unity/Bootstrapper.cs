using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Business.Configurations;
using WebProject.Business.Configurations.Impl;
using WebProject.Business.Services;
using WebProject.Business.Services.Impl;
using WebProject.DAL;
using WebProject.DAL.Repositories;
using WebProject.DAL.Repositories.Impl;
using WebProject.DAL.Uow;
using WebProject.DAL.Uow.Imple;

namespace WebProject.Business.Unity
{
    public static class Bootstrapper
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            // context
            container.RegisterType<MainContext>();
            container.RegisterType<DbContext, MainContext>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();

            // services
            container.RegisterType<ICustomerAndAddressService, CustomerAndAddressService>();

            // repositories
            container.RegisterType<ICustomerRepository, CustomerRepository>();
            container.RegisterType<IAddressRepository, AddressRepository>();

            // converter
            AutoMapperConfiguration.Initialize();
            container.RegisterType<IDataConverter, DataConverter>();
        }
    }
}
