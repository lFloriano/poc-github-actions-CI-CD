using CalculoFrete.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace CalculoFrete.Api.Models
{
    public record AdicionarPedidoFreteVm
    {
        [Required(ErrorMessage = "Modalidade do frete é obrigatória")]
        public ModalidadeFrete ModalidadeFrete { get; set; }
        
        public DateOnly? DataAgendamento { get; set; }
    }

}
