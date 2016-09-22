using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProject.Business.Configurations.Impl;
using TestProject.Business.Services;
using TestProject.Business.Services.Impl;

namespace TestProject.Controllers
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

            //var context = new ErgoleContext();
            //var unitOfWork = new UnitOfWork(context);
            //var customerRepository = new CustomerRepository(context);
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
