﻿using Asp.Versioning.ApiExplorer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;
using YAHALLO.Application;
using YAHALLO.Filters;

namespace YAHALLO.Configuration
{
    public static class SwashbuckleConfiguration
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ApiVersionSwaggerGenOptions>();
            services.AddSwaggerGen(
                options =>
                {
                    options.SchemaFilter<RequireNonNullablePropertiesSchemaFilter>();
                    options.SupportNonNullableReferenceTypes();
                    options.CustomSchemaIds(x => x.FullName);

                    var apiXmlFile = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
                    if (File.Exists(apiXmlFile))
                    {
                        options.IncludeXmlComments(apiXmlFile);
                    }

                    var applicationXmlFile = Path.Combine(AppContext.BaseDirectory, $"{typeof(DependencyInjection).Assembly.GetName().Name}.xml");
                    if (File.Exists(applicationXmlFile))
                    {
                        options.IncludeXmlComments(applicationXmlFile);
                    }
                    options.OperationFilter<AuthorizeCheckOperationFilter>();

                    var securityScheme = new OpenApiSecurityScheme()
                    {
                        Name = "Authorization",
                        Description = "Enter a Bearer Token into the `Value` field to have it automatically prefixed with `Bearer ` and used as an `Authorization` header value for requests.",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer",
                        BearerFormat = "JWT",
                        Reference = new OpenApiReference
                        {
                            Id = JwtBearerDefaults.AuthenticationScheme,
                            Type = ReferenceType.SecurityScheme
                        }
                    };

                    options.AddSecurityDefinition("Bearer", securityScheme);
                    options.AddSecurityRequirement(
                        new OpenApiSecurityRequirement
                        {
                            { securityScheme, Array.Empty<string>() }
                        });
                });
            return services;
        }

        public static void UseSwashbuckle(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    options.RoutePrefix = "swagger";
                    options.OAuthAppName("Yahallo API");
                    options.EnableDeepLinking();
                    options.DisplayOperationId();
                    options.DefaultModelsExpandDepth(-1);
                    //options.DefaultModelRendering(ModelRendering.Model);
                    //options.DocExpansion(DocExpansion.List);
                    //  options.ShowExtensions();
                    options.EnableFilter(string.Empty);
                    AddSwaggerEndpoints(app, options);
                    options.OAuthScopeSeparator(" ");
                });
        }

        private static void AddSwaggerEndpoints(IApplicationBuilder app, SwaggerUIOptions options)
        {
            var provider = app.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>();

            foreach (var description in provider.ApiVersionDescriptions.OrderByDescending(o => o.ApiVersion))
            {
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", $"{options.OAuthConfigObject.AppName} {description.GroupName}");
            }
        }
    }

    internal class RequireNonNullablePropertiesSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            var additionalRequiredProps = schema.Properties
                .Where(x => !x.Value.Nullable && !schema.Required.Contains(x.Key))
                .Select(x => x.Key);

            foreach (var propKey in additionalRequiredProps)
            {
                schema.Required.Add(propKey);
            }
        }
    }
}
