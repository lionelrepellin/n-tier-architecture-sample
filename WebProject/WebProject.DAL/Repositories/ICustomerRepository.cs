using System.Collections.Generic;
using TestProject.DAL.Repositories.Criterias;
using TestProject.Domain;

namespace TestProject.DAL.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> FindAll();
        IEnumerable<Customer> FindByCriteria(CustomerCriteria criteria);
        Customer FindById(int id);
    }
}