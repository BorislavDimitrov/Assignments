using DummyProject.Application.Contracts;
using DummyProject.Infrastructure.Data;
using DummyProject.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DummyProject.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDatabase(configuration);
            serviceCollection.AddRepository();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            return serviceCollection;
        }

        private static IServiceCollection AddDatabase(
           this IServiceCollection services,
           IConfiguration configuration)
           => services
               .AddDbContext<DummyProjectDbContext>(options => options
                   .UseInMemoryDatabase("TestDb"));

        private static IServiceCollection AddRepository(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            return serviceCollection;
        }

    }
}
