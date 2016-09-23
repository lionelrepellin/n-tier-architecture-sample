using System.Collections.Generic;
using WebProject.Business.Services.Data;

namespace WebProject.Business.Services
{
    public interface ICustomerAndAddressService
    {
        IEnumerable<CustomerData> FindAll();
        CustomerData FindById(int id);
        IEnumerable<CustomerData> FindByFirstnameAndLastname(string firstname, string lastname);
        void Add(CustomerData customerdata);
    }
}