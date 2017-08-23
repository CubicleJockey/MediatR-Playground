using MediatR;
using MediatRMessages.RequestHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace MediatRMessages.Api.StartupConfiguration
{
    /// <summary>
    /// Setup the middleware for MediatR
    /// </summary>
    public static class MediatRStartupConfiguration
    {
        /// <summary>
        /// Create the configurations for MediatR
        /// </summary>
        /// <param name="services">Service Collections</param>
        public static void Create(IServiceCollection services)
        {
            services.AddMediatR(typeof(AdditionHandlerAsync));
        }
    }
}
