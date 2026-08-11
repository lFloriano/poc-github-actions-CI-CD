using CalculoFrete.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace CalculoFrete.Api.Models
{
    public record AtualizarPedidoVm
    {
        [Required(ErrorMessage = "Id do pedido é obrigatório")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O novo CEP é obrigatório")]
        public Cep NovoCep { get; set; }  //apenas o cep de entrega pode ser alterado
    }
}
