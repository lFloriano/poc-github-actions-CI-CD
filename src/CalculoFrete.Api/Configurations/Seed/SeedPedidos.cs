using CalculoFrete.Core.Data;
using CalculoFrete.Domain;
using CalculoFrete.Domain.Enums;
using CalculoFrete.Domain.ValueObjects;

namespace CalculoFrete.Api.Configurations.Seed
{
    public static class SeedPedidos
    {
        public static void CriarPedidos(WebApplication app, IEnumerable<Guid> idsProdutos)
        {
            var repository = ObterRepository(app);

            for (int i = 1; i <= 3; i++)
            {
                var pedido = new Pedido(Guid.NewGuid(), DateTime.Now, new Cep($"00000{i}00"));                
                var itensPedido = CriarItensPedido(pedido.Id, idsProdutos);
                pedido.AtualizarItens(itensPedido);

                repository.Adicionar(pedido).GetAwaiter().GetResult();
            }
        }

        private static IEnumerable<ItemPedido> CriarItensPedido(Guid pedidoId, IEnumerable<Guid> idsProdutos)
        {
            var item1 = new ItemPedido(pedidoId, idsProdutos.FirstOrDefault(), ModalidadeFrete.Normal);
            item1.CalcularFrete(1, 3);

            var item2 = new ItemPedido(pedidoId, idsProdutos.Skip(1).First(), ModalidadeFrete.Expresso);
            item2.CalcularFrete(10, 20);

            var item3 = new ItemPedido(pedidoId, idsProdutos.Skip(2).First(), ModalidadeFrete.Agendado, DateOnly.FromDateTime(DateTime.Now.AddDays(10)));
            item3.CalcularFrete(3, 8, item3.DataAgendamento);

            return new List<ItemPedido>() { item1, item2, item3 };
        }

        private static IRepository<Pedido> ObterRepository(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            return scope.ServiceProvider.GetRequiredService<IRepository<Pedido>>();
        }
    }
}