using Microsoft.Extensions.DependencyInjection;

namespace DummyProject.Web
{
    public static class WebConfiguration
    {
        public static IServiceCollection AddWeb(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddControllers();
            return serviceCollection;
        }
    }
}
