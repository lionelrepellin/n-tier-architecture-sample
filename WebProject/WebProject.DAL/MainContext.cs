using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.DAL.Configurations;
using WebProject.DAL.Seed;
using WebProject.Domain;

namespace WebProject.DAL
{
    public class MainContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }

        static MainContext()
        {
            Database.SetInitializer<MainContext>(new MainContextInitializer());
        }
        
        public MainContext()
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
