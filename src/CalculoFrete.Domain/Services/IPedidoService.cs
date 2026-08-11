using CalculoFrete.Domain.ValueObjects;

namespace CalculoFrete.Domain.Services
{
    public interface IPedidoService
    {
        Task<IEnumerable<ItemPedido>> CalcularFreteDoPedido(Pedido pedido);
        Task<Pedido?> ObterPorIdAsync(Guid id);
        Task<Pedido?> ObterCompletoPorIdAsync(Guid id);
        Task<IEnumerable<Pedido>> ObterTodosAsync();
        Task<Pedido> Adicionar(Pedido pedido);
        Task<Pedido> Atualizar(Guid Id, Cep novoCep);
        Task Remover(Guid id);
    }
}
