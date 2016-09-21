using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Business.Configurations;
using TestProject.Business.Services.Data;
using TestProject.DAL.Repositories;
using TestProject.DAL.Repositories.Criterias;
using TestProject.DAL.Uow;
using TestProject.Domain;

namespace TestProject.Business.Services.Impl
{
    public class CustomerAndAddressService : ICustomerAndAddressService
    {
        private ICustomerRepository _customerRepository;
        private IUnitOfWork _unitOfWork;
        private IDataConverter _dataConverter;

        public CustomerAndAddressService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork, IDataConverter dataConverter)
        {
            _customerRepository = customerRepository;
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

        public void Add(CustomerData customerdata)
        {
            var customer = _dataConverter.Convert<CustomerData, Customer>(customerdata);
            _unitOfWork.Add(customer);
            _unitOfWork.SaveChanges();
        }
    }
}
