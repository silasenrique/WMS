using Microsoft.Extensions.DependencyInjection;
using WMS.Persistence.Common.UnitOfWork;
using WMS.Persistence.DistributionCenterPersistence;

namespace WMS.Persistence.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceConfiguration(this IServiceCollection service)
    {
        service.AddScoped<ApplicationContext>();

        service.AddScoped<IUnitOfWork, UnitOfWork>();

        service.AddScoped<IDistributionCenterRepository, DistributionCenterRepository>();

        return service;
    }
}