using Domain.Thunders.Interfaces.Services;
using Domain.Thunders.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Thunders
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ITarefaService, TarefaService>();
            


            return services;
        }
    }
}
