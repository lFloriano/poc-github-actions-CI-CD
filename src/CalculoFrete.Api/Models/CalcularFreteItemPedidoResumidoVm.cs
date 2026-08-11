namespace CalculoFrete.Api.Models
{
    public record CalcularFreteItemPedidoResumidoVm
    {
        public Guid ProdutoId { get; set; }
        public ConsultarFreteResumoVm Frete { get; set; }
    }
}
