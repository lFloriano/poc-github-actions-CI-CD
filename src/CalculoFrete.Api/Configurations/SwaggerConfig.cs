using Microsoft.OpenApi;

namespace CalculoFrete.Api.Configurations
{
    public static class SwaggerConfig
    {
        public static void AddSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Desafio Técnico - API de Pedidos",
                    Version = "v1",
                    Description = "Esta API Permite o CRUD de Pedidos e Cálculo de Frete"
                });

                options.EnableAnnotations();
            });
        }

        public static void UsarSwagger(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Calculo de Frete API v1");
            });
        }
    }
}
