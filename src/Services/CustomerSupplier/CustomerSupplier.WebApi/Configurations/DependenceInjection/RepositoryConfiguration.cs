using CustomerSupplier.Data.Repository;
using CustomerSupplier.Domain.Repository;

namespace CustomerSupplier.WebApi.Configurations.DependenceInjection
{
    public  static class RepositoryConfiguration
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
        }
    }
}
