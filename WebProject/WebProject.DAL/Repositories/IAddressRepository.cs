using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Domain;

namespace WebProject.DAL.Repositories
{
    public interface IAddressRepository
    {
        IEnumerable<Address> FindAddressesByCity(string city);
    }
}
