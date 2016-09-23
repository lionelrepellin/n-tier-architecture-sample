using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.DAL;
using WebProject.Domain;

namespace WebProject.DAL.Repositories.Impl
{
    public class AddressRepository : IAddressRepository
    {
        private MainContext _mainContext;

        public AddressRepository(MainContext mainContext)
        {
            _mainContext = mainContext;
        }

        public IEnumerable<Address> FindAddressesByCity(string city)
        {
            return _mainContext.Addresses
                            .Where(a => a.City.ToLower() == city.ToLower())
                            .ToList();
        }
    }
}
