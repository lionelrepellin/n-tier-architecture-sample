using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Business.Configurations.Impl;
using WebProject.Business.Services;
using WebProject.Business.Services.Impl;

namespace WebProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerAndAddressService _customerAndAddressService;


        public HomeController(ICustomerAndAddressService customerAndAddressService)
        {
            _customerAndAddressService = customerAndAddressService;
        }


        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            #region No dependency injection method

            //var mainContext = new MainContext();
            //var unitOfWork = new UnitOfWork(mainContext);
            //var customerRepository = new CustomerRepository(mainContext);
            //var dataConverter = new DataConverter();

            //var service = new CustomerAndAddressService(customerRepository, unitOfWork, dataConverter);
            //var customers = service.FindAll();

            #endregion

            var customersData = _customerAndAddressService.FindAll();

            //TODO implement data conversion from CustomerData to CustomerModel

            return View();
        }
    }
}
