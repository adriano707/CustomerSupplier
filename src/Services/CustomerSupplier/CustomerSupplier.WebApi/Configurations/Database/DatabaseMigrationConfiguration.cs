using CustomerSupplier.CrossCutting.Identity.Data;
using CustomerSupplier.Data;
using CustomerSupplier.Domain.Sesrvices;
using Microsoft.EntityFrameworkCore;

namespace CustomerSupplier.WebApi.Configurations
{
    public static class DatabaseMigrationConfiguration
    {
        public static void ApplayDatabaseMigrations(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();

            var dbContext = serviceProvider.GetService<CustomerSupplierDbContext>();
            var dbContextIdentity = serviceProvider.GetService<ApplicationDbContext>();

            if (dbContext is not null)
                dbContext.Database.Migrate();

            if (dbContextIdentity is not null)
                dbContextIdentity.Database.Migrate();
        }
    }
}
