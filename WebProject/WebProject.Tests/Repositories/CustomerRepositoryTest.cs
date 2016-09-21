using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.DAL;
using TestProject.DAL.Repositories.Criterias;
using TestProject.DAL.Repositories.Impl;
using TestProject.Domain;

namespace TestProject.Tests.Repositories
{

    [TestFixture]
    public class CustomerRepositoryTest
    {
        private CustomerRepository _customerRepository;

        [SetUp]
        public void BeforeEach()
        {
            var context = new Context();
            _customerRepository = new CustomerRepository(context);
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
            var criteria = new CustomerCriteria
            {
                Firstname = "Lionel",
                Lastname = "Repellin"
            };

            var customers = _customerRepository.FindByCriteria(criteria);
            var customer = customers.First();
                        
            Assert.That(customer, Has.Property("Firstname").EqualTo(criteria.Firstname));
            Assert.That(customer, Has.Property("Lastname").EqualTo(criteria.Lastname));
        }
    }
}
