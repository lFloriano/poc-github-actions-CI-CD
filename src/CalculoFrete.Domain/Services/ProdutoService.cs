using CalculoFrete.Core.Data;

namespace CalculoFrete.Domain.Services
{
    public class ProdutoService : IProdutoService
    {
        readonly IRepository<Produto> _produtoRepository;

        public ProdutoService(IRepository<Produto> produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Produto?> ObterPorIdAsync(Guid id)
        {
            return await _produtoRepository.ObterPorIdAsync(id);
        }

        public async Task<IEnumerable<Produto>> ObterTodosAsync()
        {
            return await _produtoRepository.ObterTodosAsync();
        }
    }
}
