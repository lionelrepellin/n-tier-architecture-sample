using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.DAL.Repositories.Criterias;
using TestProject.Domain;

namespace TestProject.DAL.Repositories.Impl
{
    public class CustomerRepository : ICustomerRepository
    {
        private Context _context;

        public CustomerRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<Customer> FindAll()
        {
            return _context.Customers
                            .Include(c => c.Addresses)
                            .ToList();
        }

        public Customer FindById(int id)
        {
            return _context.Customers
                            .Include(c => c.Addresses)
                            .Single(c => c.Id == id);
        }

        public IEnumerable<Customer> FindByCriteria(CustomerCriteria criteria)
        {
            return _context.Customers
                            .Where(c => c.Firstname == criteria.Firstname && c.Lastname == criteria.Lastname)
                            .ToList();
        }
    }
}
