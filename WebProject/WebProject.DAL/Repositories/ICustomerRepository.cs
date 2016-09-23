using System.Collections.Generic;
using WebProject.DAL.Repositories.Criterias;
using WebProject.Domain;

namespace WebProject.DAL.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> FindAll();
        IEnumerable<Customer> FindByCriteria(CustomerCriteria criteria);
        Customer FindById(int id);
    }
}