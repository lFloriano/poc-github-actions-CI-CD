using CalculoFrete.Api.Configurations.AutoMapper;

namespace CalculoFrete.Api.Configurations.AutoMapper
{
    public static class AutomapperConfig
    {
        public static void AddAutoMapper(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(config =>
            {
                config.AddProfile<PedidoMappings>();
            });
        }
    }
}
