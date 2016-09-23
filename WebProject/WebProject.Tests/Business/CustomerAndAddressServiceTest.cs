using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Business.Configurations;
using WebProject.Business.Configurations.Impl;
using WebProject.Business.Services.Data;
using WebProject.Business.Services.Impl;
using WebProject.DAL.Repositories;
using WebProject.DAL.Repositories.Criterias;
using WebProject.DAL.Uow;
using WebProject.Domain;

namespace WebProject.Tests.Business
{
    [TestFixture]
    public class CustomerAndAddressServiceTest
    {
        private IEnumerable<Customer> _customersResult;
        private IEnumerable<Address> _addressesResult;
        private DataConverter _dataConverter;
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private Mock<ICustomerRepository> _customerRepositoryMock;
        private Mock<IAddressRepository> _addressRepositoryMock;
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

            _addressesResult = new List<Address>
            {
                new Address
                {
                    Street = "rue sans issue",
                    City = "PANAM",
                    Country = "France",
                    ZipCode = "75000"
                },
                new Address
                {
                    Street = "voie du sens interdit",
                    City = "Panam",
                    Country = "France",
                    ZipCode = "92000"
                }
            };

            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _addressRepositoryMock = new Mock<IAddressRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _dataConverter = new DataConverter();

            _customerAndAddressService = new CustomerAndAddressService(_customerRepositoryMock.Object, _addressRepositoryMock.Object, _unitOfWorkMock.Object, _dataConverter);
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

        [Test]
        public void SetNewAddressToCustomer_GivenACustomerIdAndACity_ItReturnsACustomerWithACorrespondingAddress()
        {
            const int customerId = 1;
            const string city = "paNam";

            _customerRepositoryMock
                .Setup(m => m.FindById(customerId))
                .Returns(_customersResult.Single(c => c.Id == customerId));

            _addressRepositoryMock
                .Setup(m => m.FindAddressesByCity(city))
                .Returns(_addressesResult);

            var customerData = _customerAndAddressService.SetNewAddressToCustomer(customerId, city);

            _customerRepositoryMock.VerifyAll();
            _addressRepositoryMock.VerifyAll();
            
            Assert.IsTrue(customerData.Addresses.Single().City.ToLower() == city.ToLower());
        }
    }
}
