using System.ComponentModel.DataAnnotations;

namespace CalculoFrete.Api.Models
{
    public record AdicionarPedidoItemPedidoVm
    {
        [Required(ErrorMessage = "O ClienteId é obrigatório")]
        public Guid ProdutoId { get; set; }

        [Required(ErrorMessage = "Modalidade do frete é obrigatória")]
        public AdicionarPedidoFreteVm? FreteSelecionado { get; set; }

        //Demais propriedades foram omitidas para não adicionar complexidade incompatível com o escopo do desafio
    }
}
