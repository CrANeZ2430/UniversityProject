using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace University.Application;


public static class ApplicationRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}
