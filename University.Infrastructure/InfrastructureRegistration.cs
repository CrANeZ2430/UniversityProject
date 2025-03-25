using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using University.Core.Common;
using University.Core.Domain.Departments.Common;
using University.Core.Domain.Faculties.Common;
using University.Infrastructure.Core.Common;
using University.Infrastructure.Core.Domain.Departments.Common;
using University.Infrastructure.Core.Domain.Faculties.Common;
using University.Infrastructure.Middleware;

namespace University.Infrastructure;

public static class InfrastructureRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IFacultiesRepository, FacultiesRepository>();
        services.AddScoped<IDepartmentsRepository, DepartmentsRepository>();

        services.AddSingleton<IExceptionToResponseMapper, ExceptionToResponseMapper>();
        services.AddTransient<ExceptionHandlerMiddleware>();
    }
}
