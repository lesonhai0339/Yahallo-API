﻿
using Microsoft.AspNetCore.Diagnostics;
using System.Diagnostics;

namespace YAHALLO.Configuration
{
    public static class ProblemDetailsConfiguration
    {
        public static IServiceCollection ConfigureProblemDetails(this IServiceCollection services)
        {
            services.AddProblemDetails(conf => conf.CustomizeProblemDetails = context =>
            {

                if (context.ProblemDetails.Status != 500) { return; }
                context.ProblemDetails.Title = "Internal Server Error";
                context.ProblemDetails.Extensions.TryAdd("traceId", Activity.Current?.Id ?? context.HttpContext.TraceIdentifier);

                var env = context.HttpContext.RequestServices.GetService<IWebHostEnvironment>()!;
                if (!env.IsDevelopment()) { return; }

                var exceptionFeature = context.HttpContext.Features.Get<IExceptionHandlerFeature>();
                if (exceptionFeature is null) { return; }
                context.ProblemDetails.Detail = exceptionFeature.Error.ToString();
            });
            return services;
        }
    }
}
