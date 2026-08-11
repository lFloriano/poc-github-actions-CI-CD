using CalculoFrete.Domain.ValueObjects;

namespace CalculoFrete.Api.Models
{
    public record ConsultarPedidoVm
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public decimal ValorFrete { get; set; }
        public string CepDestino { get; set; }
        public DateTime DataCriacao { get; set; }
        public IReadOnlyCollection<ConsultarItemPedidoResumidoVm> Itens { get; set; }
    }
}
