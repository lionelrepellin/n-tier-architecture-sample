using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Domain
{
    public class Customer
    {
        public int Id { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public ICollection<Address> Addresses { get; set; }

        public Customer()
        {
            Addresses = new HashSet<Address>();
        }
    }
}
