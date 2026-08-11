namespace CalculoFrete.Api.Models
{
    public record ConsultarPrazoEntregaVm
    {
        public int NumeroMinimoDias { get; set; }
        public int NumeroMaximoDias { get; set; }
    }

}
