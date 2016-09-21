using System.Collections.Generic;
using TestProject.Business.Services.Data;

namespace TestProject.Business.Services
{
    public interface ICustomerAndAddressService
    {
        IEnumerable<CustomerData> FindAll();
        CustomerData FindById(int id);
        IEnumerable<CustomerData> FindByFirstnameAndLastname(string firstname, string lastname);
        void Add(CustomerData customerdata);
    }
}