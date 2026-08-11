using CalculoFrete.Core.Domain;
using CalculoFrete.Domain.ValueObjects;

namespace CalculoFrete.Domain
{
    public class Pedido : Entity
    {
        private List<ItemPedido> _items;

        public Pedido(Guid clienteId, DateTime dataCriacao, Cep cepDestino)
        {
            _items = new List<ItemPedido>();
            ClienteId = clienteId;
            DataCriacao = dataCriacao;
            CepDestino = cepDestino;
        }

        public Pedido(Guid clienteId, IEnumerable<ItemPedido> itens)
        {
            ClienteId = clienteId;
            _items = new List<ItemPedido>();
            _items.AddRange(itens);
        }


        public Guid ClienteId { get; private set; }
        public decimal ValorFrete => Itens.Sum(x => x.Frete.Valor);
        public Cep CepDestino { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public IReadOnlyCollection<ItemPedido> Itens => _items.AsReadOnly();

        public void AtualizarCepDestino(Cep novoCep)
        {
            CepDestino = novoCep ?? throw new ArgumentNullException(nameof(Cep));
        }

        public void AtualizarItens(IEnumerable<ItemPedido> itens)
        {
            if (itens != null)
                _items.AddRange(itens);
        }

    }
}
