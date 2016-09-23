using System;
using NUnit.Framework;
using WebProject.DAL.Repositories.Impl;
using WebProject.Domain;
using WebProject.DAL;
using System.Collections.Generic;
using System.Linq;

namespace WebProject.Tests.Repositories
{
    [TestFixture]
    public class AddressRepositoryTest : BaseRepositoryTest
    {
        private AddressRepository _addressRepository;

        [SetUp]
        public void BeforeEach()
        {
            _addressRepository = new AddressRepository(MainContext);
        }

        [Test]
        public void FindCitiesByName_ItReturnsAddresseWithSameCity()
        {
            // arrange
            var customer = new Customer
            {
                Firstname = "test",
                Lastname = "test test",
                Addresses = new List<Address>
                {
                    new Address { Street = "rue de l'impasse", ZipCode = "75000", City = "Zanzibar", Country = "France", IsDefault = false },
                    new Address { Street = "chemin du rond point", ZipCode = "92000", City = "ZaNzIbAr", Country = "France", IsDefault = true },
                    new Address { Street = "route du demi-tour", ZipCode = "93000", City = "ZAnZIbAR", Country = "France", IsDefault = false }
                }
            };

            MainContext.Customers.Add(customer);
            MainContext.SaveChanges();

            // act
            var city = "zanzibar";
            var addresses = _addressRepository.FindAddressesByCity(city);

            // assert
            Assert.That(addresses, Is.Not.Null.And.All.InstanceOf<Address>());
            Assert.IsTrue(addresses.Count() == customer.Addresses.Count());
        }
    }
}
