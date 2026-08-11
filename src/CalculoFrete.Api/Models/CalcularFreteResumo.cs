namespace CalculoFrete.Api.Models
{
    public record CalcularFreteResumo
    {
        public decimal? ValorTotal { get; set; }
        public string? CepDestino { get; set; }
        public IEnumerable<CalcularFreteItemPedidoResumidoVm>? Itens { get; set; }
    }
}
