using CalculoFrete.Domain.Enums;
using Microsoft.OpenApi;

namespace CalculoFrete.Api.Models
{
    public record ConsultarFreteResumoVm
    {
        public ModalidadeFrete ModalidadeFrete { get; set; }
        public string? DescricaoFrete => ModalidadeFrete.GetDisplayName();
        public decimal Valor { get; set; }
        public string? PrazoEntrega { get; set; }
    }
}
