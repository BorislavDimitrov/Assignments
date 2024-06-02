using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DummyProject.Application
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplication(
             this IServiceCollection services,
             IConfiguration configuration)
             => services
                 .AddAutoMapper(Assembly.GetExecutingAssembly())
                 .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

    }
}