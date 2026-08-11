namespace CalculoFrete.Api.Models
{
    public record ConsultarFreteVm
    {
        public decimal Valor { get; set; }
        public ConsultarPrazoEntregaVm PrazoEntrega { get; set; }
    }

}
