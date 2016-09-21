using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Business.Configurations;
using TestProject.Business.Configurations.Impl;
using TestProject.Business.Services.Data;
using TestProject.Business.Services.Impl;
using TestProject.DAL.Repositories;
using TestProject.DAL.Repositories.Criterias;
using TestProject.DAL.Uow;
using TestProject.Domain;

namespace TestProject.Tests.Business
{
    [TestFixture]
    public class CustomerAndAddressServiceTest
    {
        private IEnumerable<Customer> _customersResult;        
        private DataConverter _dataConverter;
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private Mock<ICustomerRepository> _customerRepositoryMock;
        private CustomerAndAddressService _customerAndAddressService;
        

        [OneTimeSetUp]
        public void InitializeMapper()
        {
            AutoMapperConfiguration.Initialize();
        }


        [SetUp]
        public void BeforeEach()
        {
            _customersResult = new List<Customer>
            {
                new Customer { Id = 1, Firstname = "Riri", Lastname ="Duck" },
                new Customer { Id = 2, Firstname = "Fifi", Lastname = "Duck" },
                new Customer { Id = 3, Firstname = "Loulou", Lastname = "Duck" }
            };

            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _dataConverter = new DataConverter();

            _customerAndAddressService = new CustomerAndAddressService(_customerRepositoryMock.Object, _unitOfWorkMock.Object, _dataConverter);
        }

        [Test]
        public void FindAll_ReturnsAllCustomers()
        {
            _customerRepositoryMock
                   .Setup(m => m.FindAll())
                   .Returns(_customersResult);

            var customersData = _customerAndAddressService.FindAll();

            Assert.That(customersData, Is.Not.Null.And.All.InstanceOf<CustomerData>());
            _customerRepositoryMock.Verify(m => m.FindAll(), Times.Once);
        }

        [Test]
        public void FindById_GivenAnId_ItReturnsACustomerData()
        {
            const int customerId = 12;

            _customerRepositoryMock
                .Setup(m => m.FindById(It.IsAny<int>()))
                .Returns(_customersResult.First());

            var customerData = _customerAndAddressService.FindById(customerId);

            Assert.That(customerData, Is.Not.Null);
            _customerRepositoryMock.VerifyAll();
        }

        [Test]
        public void FindByCriteria_GivenACriteria_ItReturnsACustomerData()
        {
            _customerRepositoryMock
                .Setup(m => m.FindByCriteria(It.Is<CustomerCriteria>(c => c.Firstname == "Fifi" && c.Lastname == "Duck")))
                .Returns(new List<Customer> { _customersResult.ElementAt(1) });

            const string firstname = "Fifi";
            const string lastname = "Duck";
            
            var customersData = _customerAndAddressService.FindByFirstnameAndLastname(firstname, lastname);

            Assert.That(customersData, Is.Not.Null);
            _customerRepositoryMock.VerifyAll();
        }

        [Test]
        public void Add_GivenACustomerData_ItAddsToTheDatabase()
        {
            _unitOfWorkMock
                .Setup(m => m.Add<Customer>(It.IsAny<Customer>()));

            _unitOfWorkMock
                .Setup(m => m.SaveChanges());

            _customerAndAddressService.Add(new CustomerData
            {
                Firstname = "toto",
                Lastname = "pouet pouet"
            });

            _unitOfWorkMock.VerifyAll();
        }
    }
}
