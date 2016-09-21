using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.DAL.Configurations;
using TestProject.DAL.Seed;
using TestProject.Domain;

namespace TestProject.DAL
{
    public class Context : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }

        static Context()
        {
            Database.SetInitializer<Context>(new ContextInitializer());
        }


        public Context()
         : base("MyDatabaseConnection")
        {
            Configuration.LazyLoadingEnabled = false;

#if DEBUG
            Database.Log = (log) => System.Diagnostics.Debug.WriteLine(log);
#endif
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var config = modelBuilder.Configurations;
            config.Add(new CustomerConfiguration());
            config.Add(new AddressConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
