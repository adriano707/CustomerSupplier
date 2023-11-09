using CustomerSupplier.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CustomerSupplier.Data
{
    public class CustomerSupplierDbContext : DbContext
    {
        public DbSet<Domain.Entities.CustomerSupplier> CustomerSuppliers { get; set; }
        public DbSet<CustomerSupplierAddress> CustomerSuppliersAddress { get; set; }
        public DbSet<CustomerSupplierContact> CustomerSuppliersContact { get; set; }

        public CustomerSupplierDbContext()
        {
            
        }

        public CustomerSupplierDbContext(DbContextOptions<CustomerSupplierDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
