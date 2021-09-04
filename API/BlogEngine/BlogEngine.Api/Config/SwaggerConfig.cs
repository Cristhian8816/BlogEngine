// Copyright (c) SoftwareOne. All Rights Reserved.

namespace BlogEngine.Api.Config
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.Swagger;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    /// <summary>
    /// Here goes the swagger configuration
    /// </summary>
    public static class SwaggerConfig
    {
        /// <summary>
        /// Adds the registration.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>IServiceCollection.</returns>
        /// <remarks>Elkin Vasquez Isenia</remarks>
        public static IServiceCollection AddRegistrationSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc($"v{Assembly.GetExecutingAssembly().GetName().Version}",
                    new OpenApiInfo
                    {
                        Title = "BlogEngine",
                        Version = $"v{Assembly.GetExecutingAssembly().GetName().Version}",
                        Description = ".NET Framework CORE 5.0",
                        Contact = new OpenApiContact
                        {
                            Name = "SoftwareOne",
                            Email = ""
                        }
                    });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJ.eyJzdWIIyfQ.SfadQssw5c\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            services.AddMvcCore().AddApiExplorer();
            return services;
        }

        /// <summary>
        /// Adds the registration.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <returns>IApplicationBuilder.</returns>
        /// <remarks>Elkin Vasquez Isenia</remarks>
        public static IApplicationBuilder AddRegistration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/v{Assembly.GetExecutingAssembly().GetName().Version}/swagger.json", $"BlogEngine (v{Assembly.GetExecutingAssembly().GetName().Version})");
                c.RoutePrefix = string.Empty;
            });
            return app;
        }
    }
}
