using CalculoFrete.Core.Data;
using CalculoFrete.Domain.ValueObjects;

namespace CalculoFrete.Domain.Services
{
    public class PedidoService : IPedidoService
    {
        readonly IRepository<Pedido> _pedidoRepository;
        readonly IProdutoService _produtoService;
        readonly IFreteService _freteService;

        public PedidoService(IRepository<Pedido> pedidoRepository, IFreteService freteService, IProdutoService produtoService)
        {
            _pedidoRepository = pedidoRepository;
            _freteService = freteService;
            _produtoService = produtoService;
        }

        public async Task<Pedido> Adicionar(Pedido pedido)
        {
            if (pedido == null)
                throw new ArgumentNullException(nameof(pedido));

            var pedidoJaExiste = await _pedidoRepository.ObterPorIdAsync(pedido.Id) != null;

            if (pedidoJaExiste)
                throw new InvalidOperationException("O pedido já existe no sistema");

            await CalcularFreteDoPedido(pedido);
            await _pedidoRepository.Adicionar(pedido);
            return pedido;
        }

        public async Task<Pedido> Atualizar(Guid id, Cep novoCep)
        {
            var pedido = await ObterCompletoPorIdAsync(id) ??
                throw new InvalidOperationException("Pedido não encontrado para atualização");

            pedido.AtualizarCepDestino(novoCep);
            await _pedidoRepository.Atualizar(pedido);
            return pedido;
        }

        public async Task<Pedido?> ObterPorIdAsync(Guid id)
        {
            return await _pedidoRepository.ObterPorIdAsync(id);
        }

        public async Task<Pedido?> ObterCompletoPorIdAsync(Guid id)
        {
            var pedido = await _pedidoRepository.ObterPorIdAsync(id);

            if (pedido == null)
                return null;

            foreach (var item in pedido.Itens)
            {
                var produto = await _produtoService.ObterPorIdAsync(item.ProdutoId);
                item.AtualizarProduto(produto);
            }

            return pedido;
        }

        public async Task<IEnumerable<Pedido>> ObterTodosAsync()
        {
            return await _pedidoRepository.ObterTodosAsync();
        }

        public async Task Remover(Guid id)
        {
            var pedido = await _pedidoRepository.ObterPorIdAsync(id) ??
                throw new InvalidOperationException("Pedido não encontrado para exclusão");

            await _pedidoRepository.Remover(pedido);
        }

        public async Task<IEnumerable<ItemPedido>> CalcularFreteDoPedido(Pedido pedido)
        {
            await ValidarItensDoPedido(pedido?.Itens);

            foreach (var item in pedido.Itens)
            {
                var produto = await _produtoService.ObterPorIdAsync(item.ProdutoId);
                var distanciaEmKm = await _freteService.CalcularDistanciaEmKm(pedido.CepDestino, produto.CepCentroDistribuicao);
                item.CalcularFrete(distanciaEmKm, produto.PesoEmKg, item.DataAgendamento);
            }

            return pedido.Itens;
        }

        private async Task ValidarItensDoPedido(IEnumerable<ItemPedido>? itens)
        {
            if (itens == null || !itens.Any())
                throw new InvalidOperationException("O pedido não possui nenhum produto");

            foreach (var item in itens)
            {
                var produto = await _produtoService.ObterPorIdAsync(item.ProdutoId);

                if (produto == null)
                    throw new InvalidOperationException("O pedido possui produto(s) inexistente(s)");
            }
        }
    }
}
