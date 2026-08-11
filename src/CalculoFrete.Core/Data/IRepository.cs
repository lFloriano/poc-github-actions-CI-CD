using CalculoFrete.Core.Domain;

namespace CalculoFrete.Core.Data
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        Task<T?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<T>> ObterTodosAsync();
        Task Adicionar(T entity);
        Task Atualizar(T entity);
        Task Remover(T entity);
    }
}
