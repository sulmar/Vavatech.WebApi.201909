using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.WebApi.DbRepositories.Configurations;
using Vavatech.WebApi.Models;

namespace Vavatech.WebApi.DbRepositories
{

    // Install-Package EntityFramework

    public class MyContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public MyContext()
          : base("MyConnection")
        {
            this.Database.CreateIfNotExists();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new CustomerConfiguration());
        }
    }
}
