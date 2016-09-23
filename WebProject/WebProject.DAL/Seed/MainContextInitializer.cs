using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Domain;

namespace WebProject.DAL.Seed
{
    public class MainContextInitializer : CreateDatabaseIfNotExists<MainContext>
    //public class ContextInitializer : DropCreateDatabaseAlways<ErgoleContext>
    {
        protected override void Seed(MainContext mainContext)
        {
            mainContext.Customers.Add(new Customer
            {
                Firstname = "Bob",
                Lastname = "L'Eponge",
                Addresses = new List<Address>
                {
                    new Address
                    {
                        Street = "Rue de la république",
                        ZipCode = "38000",
                        City = "Grenoble",
                        Country = "France",
                        IsDefault = true
                    },
                    new Address
                    {
                        Street = "Impasse des violettes",
                        ZipCode = "38400",
                        City = "Saint Martin d'Hères",
                        Country = "France",
                        IsDefault = false
                    }
                }
            });

            mainContext.Customers.Add(new Customer
            {
                Firstname = "Patrick",
                Lastname = "L'Etoile de Mer",
                Addresses = new List<Address>
                {
                    new Address
                    {
                        Street = "Chemin du port",
                        ZipCode = "29100",
                        City = "Quimper",
                        Country = "France",
                        IsDefault = true
                    }
                }
            });

            mainContext.Customers.Add(new Customer
            {
                Firstname = "Carlo",
                Lastname = "Tentacule",
                Addresses = new List<Address>
                {
                    new Address
                    {
                        Street = "Avenue des Champs Elysées",
                        ZipCode = "75000",
                        City = "Paris",
                        Country = "France",
                        IsDefault = true
                    },
                    new Address
                    {
                        Street = "Rue Tolbiac",
                        ZipCode = "75015",
                        City = "Paris",
                        Country = "France",
                        IsDefault = false
                    }
                }
            });
            
            mainContext.SaveChanges();

            base.Seed(mainContext);
        }
    }
}
