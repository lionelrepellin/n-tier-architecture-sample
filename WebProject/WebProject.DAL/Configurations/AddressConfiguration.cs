using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Domain;

namespace WebProject.DAL.Configurations
{
    public class AddressConfiguration : EntityTypeConfiguration<Address>
    {
        public AddressConfiguration()
        {
            ToTable("adresse");

            HasKey(a => a.Id);

            Property(a => a.Id)
                .HasColumnName("code_adresse");
                        
            Property(a => a.Street)
                .HasColumnName("rue")
                .HasMaxLength(200);

            Property(a => a.ZipCode)
                .HasColumnName("code_postal")
                .HasMaxLength(20);

            Property(a => a.City)
                .HasColumnName("ville")
                .HasMaxLength(50);

            Property(a => a.Country)
                .HasColumnName("pays")
                .HasMaxLength(50);

            Property(a => a.IsDefault)
                .HasColumnName("defaut");
        }
    }
}
