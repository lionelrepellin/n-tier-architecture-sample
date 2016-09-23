using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.DAL;
using WebProject.DAL.Repositories.Criterias;
using WebProject.DAL.Repositories.Impl;
using WebProject.Domain;

namespace WebProject.Tests.Repositories
{

    [TestFixture]
    public class CustomerRepositoryTest : BaseRepositoryTest
    {
        private CustomerRepository _customerRepository;

        [SetUp]
        public void BeforeEach()
        {
            _customerRepository = new CustomerRepository(MainContext);
        }

        [Test]
        public void FindAll_ItReturnsAllCustomers()
        {
            var customers = _customerRepository.FindAll();
            
            Assert.That(customers, Is.Not.Null.And.All.InstanceOf<Customer>());
        }

        [Test]
        public void FindById_GivenAnId_ItReturnsTheSpecifiedUser()
        {
            const int customerId = 1;
            var customer = _customerRepository.FindById(customerId);

            Assert.That(customer.Id, Is.EqualTo(customerId));
        }

        [Test]
        public void FindByCriteria_GivenCriteria_ItReturnsTheRightCustomer()
        {
            // arrange
            MainContext.Customers.Add(new Customer
            {
                Firstname = "Lionel",
                Lastname = "Repellin",                
            });

            MainContext.SaveChanges();

            var criteria = new CustomerCriteria
            {
                Firstname = "Lionel",
                Lastname = "Repellin"
            };

            // act
            var customers = _customerRepository.FindByCriteria(criteria);
            var customer = customers.First();
                  
            // assert      
            Assert.That(customer, Has.Property("Firstname").EqualTo(criteria.Firstname));
            Assert.That(customer, Has.Property("Lastname").EqualTo(criteria.Lastname));
        }
    }
}
