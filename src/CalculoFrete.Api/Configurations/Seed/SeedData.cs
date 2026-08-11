namespace CalculoFrete.Api.Configurations.Seed
{
    public static class SeedData
    {
        public static void Seed(this WebApplication app)
        {
            var idsProdutos = SeedProdutos.CriarProdutos(app);
            SeedPedidos.CriarPedidos(app, idsProdutos);
        }
    }
}