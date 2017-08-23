using System.IO;
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
        /// Create the Configurations.
        /// </summary>
        /// <param name="services">Services Collection</param>
        public static void Create(IServiceCollection services)
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
    }
}
