using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Business.Configurations;
using WebProject.Business.Services.Data;
using WebProject.DAL.Repositories;
using WebProject.DAL.Repositories.Criterias;
using WebProject.DAL.Uow;
using WebProject.Domain;

namespace WebProject.Business.Services.Impl
{
    public class CustomerAndAddressService : ICustomerAndAddressService
    {
        private IAddressRepository _addressRepository;
        private ICustomerRepository _customerRepository;
        private IUnitOfWork _unitOfWork;
        private IDataConverter _dataConverter;

        public CustomerAndAddressService(ICustomerRepository customerRepository, IAddressRepository addressRepository,  IUnitOfWork unitOfWork, IDataConverter dataConverter)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
            _unitOfWork = unitOfWork;
            _dataConverter = dataConverter;
        }

        public IEnumerable<CustomerData> FindAll()
        {
            var customers = _customerRepository.FindAll();
            return _dataConverter.Convert<IEnumerable<Customer>, IEnumerable<CustomerData>>(customers);            
        }

        public CustomerData FindById(int id)
        {
            var customer = _customerRepository.FindById(id);
            return _dataConverter.Convert<Customer, CustomerData>(customer);
        }

        public IEnumerable<CustomerData> FindByFirstnameAndLastname(string firstname, string lastname)
        {
            var criteria = new CustomerCriteria
            {
                Firstname = firstname,
                Lastname = lastname
            };
            var customers = _customerRepository.FindByCriteria(criteria);
            return _dataConverter.Convert<IEnumerable<Customer>, IEnumerable<CustomerData>>(customers);
        }

        // it is just a bit of business logic code
        // only made to show the usage of two repositories in the same service
        public CustomerData SetNewAddressToCustomer(int customerId, string city)
        {
            var customer = _customerRepository.FindById(customerId);
            var addresses = _addressRepository.FindAddressesByCity(city);
            if (addresses.Any())
            {
                customer.Addresses.Add(addresses.First());
            }
            return _dataConverter.Convert<Customer, CustomerData>(customer); ;
        }

        public void Add(CustomerData customerdata)
        {
            var customer = _dataConverter.Convert<CustomerData, Customer>(customerdata);
            _unitOfWork.Add(customer);
            _unitOfWork.SaveChanges();
        }
    }
}
