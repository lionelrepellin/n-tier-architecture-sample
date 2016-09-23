using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.DAL.Repositories.Criterias;
using WebProject.Domain;

namespace WebProject.DAL.Repositories.Impl
{
    public class CustomerRepository : ICustomerRepository
    {
        private MainContext _mainContext;

        public CustomerRepository(MainContext mainContext)
        {
            _mainContext = mainContext;
        }

        public IEnumerable<Customer> FindAll()
        {
            return _mainContext.Customers
                            .Include(c => c.Addresses)
                            .ToList();
        }

        public Customer FindById(int id)
        {
            return _mainContext.Customers
                            .Single(c => c.Id == id);
        }

        public IEnumerable<Customer> FindByCriteria(CustomerCriteria criteria)
        {
            return _mainContext.Customers
                            .Where(c => c.Firstname == criteria.Firstname && c.Lastname == criteria.Lastname)
                            .ToList();
        }
    }
}
