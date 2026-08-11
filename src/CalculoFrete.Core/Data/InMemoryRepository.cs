using CalculoFrete.Core.Domain;

namespace CalculoFrete.Core.Data
{
    public class InMemoryRepository<T> : IRepository<T> where T : Entity
    {
        protected readonly Dictionary<Guid, T> _storage = new();

        public Task Adicionar(T entity)
        {
            _storage.Add(entity.Id, entity);
            return Task.FromResult(entity);
        }

        public Task Atualizar(T entity)
        {
            _storage[entity.Id] = entity;
            return Task.FromResult(entity);
        }

        public Task<T?> ObterPorIdAsync(Guid id)
        {
            return Task.FromResult(_storage.TryGetValue(id, out var entity) ? entity : null);
        }

        public Task<IEnumerable<T>> ObterTodosAsync()
        {
            return Task.FromResult(_storage.Select(x => x.Value));
        }

        public Task Remover(T entity)
        {
            _storage.Remove(entity.Id);
            return Task.FromResult(entity);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
