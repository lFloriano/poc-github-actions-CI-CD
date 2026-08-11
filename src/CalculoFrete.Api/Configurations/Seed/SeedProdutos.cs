using CalculoFrete.Core.Data;
using CalculoFrete.Domain;
using CalculoFrete.Domain.ValueObjects;

namespace CalculoFrete.Api.Configurations.Seed
{
    public static class SeedProdutos
    {
        public static IEnumerable<Guid> CriarProdutos(WebApplication app)
        {
            var repository = ObterRepository(app);
            var idsProdutos = new List<Guid>();

            for (int i = 1; i <= 5; i++)
            {
                var produto = new Produto(
                    $"Produto {i}",
                    i * 4M,
                    new Cep($"0000{i}00")
                );

                idsProdutos.Add(produto.Id);
                repository.Adicionar(produto).GetAwaiter().GetResult();
            }

            return idsProdutos;
        }

        private static IRepository<Produto> ObterRepository(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            return scope.ServiceProvider.GetRequiredService<IRepository<Produto>>();
        }
    }
}