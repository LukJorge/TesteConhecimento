using Microsoft.Extensions.DependencyInjection;
using TesteFCamara.Data;
using TesteFCamara.Data.Interfaces;
using TesteFCamara.Repositories;
using TesteFCamara.Repositories.Interfaces;
using TesteFCamara.Services;
using TesteFCamara.Services.Interfaces;

namespace TesteFCamara.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection ConfigureDependencies(this IServiceCollection services)
        {
            services.AddScoped<IConnectionFactory, ConnectionFactory>();

            services.AddTransient<IControleDeVeiculosServices, ControleDeVeiculosServices>();
            services.AddTransient<IEstabelecimentoServices, EstabelecimentoServices>();
            services.AddTransient<IVeiculoServices, VeiculoServices>();

            services.AddTransient<IControleDeVeiculosRepository, ControleDeVeiculosRepository>();
            services.AddTransient<IEstabelecimentoRepository, EstabelecimentoRepository>();
            services.AddTransient<IVeiculoRepository, VeiculoRepository>();

            return services;
        }
    }
}