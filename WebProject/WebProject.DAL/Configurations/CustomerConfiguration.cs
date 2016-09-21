using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Domain;

namespace TestProject.DAL.Configurations
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            ToTable("client");

            HasKey(c => c.Id);

            Property(c => c.Id)
                .HasColumnName("code_client");

            Property(c => c.Firstname)
                .HasColumnName("prenom")
                .HasMaxLength(50);

            Property(c => c.Lastname)
                .HasColumnName("nom")
                .HasMaxLength(50);

            HasMany(c => c.Addresses)
                .WithRequired(a => a.Customer);
        }
    }
}
