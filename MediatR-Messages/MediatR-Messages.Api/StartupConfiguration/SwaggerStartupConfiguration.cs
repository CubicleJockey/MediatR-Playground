using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;

namespace MediatRMessages.Api.StartupConfiguration
{
    /// <summary>
    /// Configures Swagger
    /// </summary>
    public static class SwaggerStartupConfiguration
    {
        /// <summary>
        /// Create Services Configurations.
        /// </summary>
        /// <param name="services">Services Collection</param>
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "MediatR Example",
                        Version = "v1",
                        Description = "Trying out the MediatR library to simplify Request and Response logic.",
                        TermsOfService = "WTFPL",
                        Contact = new Contact
                        {
                            Email = "davis.andre@gmail.com",
                            Name = "André Davis",
                            Url = "https://github.com/CubicleJockey/MediatR-Playground"
                        }
                    }
                );

                var xmlDocFile = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, @"MediatR-Messages.Api.xml");
                options.IncludeXmlComments(xmlDocFile);
                options.DescribeAllEnumsAsStrings();
            });
        }

        /// <summary>
        /// Configure Applications
        /// </summary>
        /// <param name="app"></param>
        public static void ConfigureApplication(IApplicationBuilder app)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint
            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs");
            });
        }
    }
}
