namespace CalculoFrete.Domain.Services
{
    public interface IProdutoService
    {
        Task<Produto?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Produto>> ObterTodosAsync();
    }
}
