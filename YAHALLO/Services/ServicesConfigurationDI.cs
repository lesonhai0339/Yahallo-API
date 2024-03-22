using YAHALLO.Application.Common.Interfaces;

namespace YAHALLO.Services
{
    public static class ServicesConfigurationDI
    {
        public static IServiceCollection ConfigurationServiceDJ(this IServiceCollection services, IConfiguration configuration)
        {




            services.AddTransient<ICurrentContextService, CurrentContextService>();
            return services;
        }
    }
}
