using CalculoFrete.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace CalculoFrete.Api.Models
{
    public record CalcularFretePedidoVm
    {
        [Required(ErrorMessage = "A lista não pode ser nula")]
        [MinLength(1, ErrorMessage = "É necessário adicionar pelo menos 1 item ao pedido")]
        public IEnumerable<AdicionarPedidoItemPedidoVm>? Itens { get; set; }

        [Required(ErrorMessage = "O ClienteId é obrigatório.")]
        public Guid ClienteId { get; set; }

        [Required(ErrorMessage = "O CepDestino é obrigatório.")]
        public Cep CepDestino { get; set; }
    }

}
