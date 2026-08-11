using CalculoFrete.Core.Data;
using CalculoFrete.Domain;
using CalculoFrete.Domain.Services;

namespace CalculoFrete.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //data
            services.AddSingleton<IRepository<Pedido>, InMemoryRepository<Pedido>>();
            services.AddSingleton<IRepository<Produto>, InMemoryRepository<Produto>>();

            //services
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IFreteService, FreteService>();
        }
    }
}
