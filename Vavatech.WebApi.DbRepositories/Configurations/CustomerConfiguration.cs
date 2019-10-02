using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.WebApi.Models;

namespace Vavatech.WebApi.DbRepositories.Configurations
{
    class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            Property(p => p.FirstName)
              .HasMaxLength(50);

            Property(p => p.SecondName)
              .HasMaxLength(50);

            Property(p => p.LastName)
              .IsRequired()
              .HasMaxLength(50);
        }
    }
}
