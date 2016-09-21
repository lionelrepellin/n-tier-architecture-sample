using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Domain;

namespace TestProject.DAL.Seed
{
    public class ContextInitializer : CreateDatabaseIfNotExists<Context>
    //public class ContextInitializer : DropCreateDatabaseAlways<ErgoleContext>
    {
        protected override void Seed(Context context)
        {
            context.Customers.Add(new Customer
            {
                Firstname = "Lionel",
                Lastname = "Repellin",
                Addresses = new List<Address>
                {
                    new Address { Street = "6 rue du petit jean", City = "Gière", Country = "France", IsDefault = true }
                }
            });

            context.Customers.Add(new Customer
            {
                Firstname = "Patrick",
                Lastname = "Sébastien",
                Addresses = new List<Address>
                {
                    new Address { Street = "Le cabaret", City = "Paris", Country = "France", IsDefault = true }
                }
            });

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
