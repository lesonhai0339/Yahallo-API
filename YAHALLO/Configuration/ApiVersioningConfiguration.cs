using Asp.Versioning;

namespace YAHALLO.Configuration
{
    public static class ApiVersioningConfiguration
    {
        public static IServiceCollection ConfigureApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.DefaultApiVersion = new ApiVersion(111);
                options.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader());
            })
            .AddMvc()
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
            return services;
        }
    }
}
