using AutoMapper;
using CalculoFrete.Api.Models;
using CalculoFrete.Domain;
using CalculoFrete.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CalculoFrete.Api.Controllers
{
    [ApiController]
    [Route("api/pedidos")]
    public class PedidoController : ControllerBase
    {
        readonly IPedidoService _pedidoService;
        readonly IMapper _mapper;

        public PedidoController(IPedidoService pedidoService, IMapper mapper)
        {
            _pedidoService = pedidoService;
            _mapper = mapper;
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ConsultarPedidoVm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Obtém pedido por id")]
        public async Task<IActionResult> ObterPorId([FromRoute] Guid id)
        {
            var pedido = await _pedidoService.ObterCompletoPorIdAsync(id);

            if (pedido == null)
                return NotFound();

            return Ok(_mapper.Map<ConsultarPedidoVm>(pedido));
        }

        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<ConsultarPedidoVm>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [SwaggerOperation(Summary = "Obtém todos os pedidos cadastrados")]
        public async Task<IActionResult> ObterTodos()
        {
            var pedidos = await _pedidoService.ObterTodosAsync();

            if (pedidos == null || !pedidos.Any())
                return NoContent();

            return Ok(_mapper.Map<IEnumerable<ConsultarPedidoVm>>(pedidos));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerOperation(Summary = "Realiza um novo pedido", Description = "Permite a realização de um novo pedido com um ou mais produtos")]
        public async Task<IActionResult> Adicionar([FromBody] AdicionarPedidoVm model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pedido = new Pedido(model.ClienteId, DateTime.Now, model.CepDestino);
            var itensPedido = model.Itens.Select(item => new ItemPedido(pedido.Id, item.ProdutoId, item.FreteSelecionado.ModalidadeFrete, item.FreteSelecionado.DataAgendamento));
            pedido.AtualizarItens(itensPedido);
            pedido = await _pedidoService.Adicionar(pedido);
            return CreatedAtAction(nameof(ObterPorId), new { id = pedido.Id }, _mapper.Map<ConsultarPedidoVm>(pedido));
        }

        [HttpPatch("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerOperation(Summary = "Atualiza um pedido", Description = "Permite a atualização do CEP de entrega do pedido")]
        public async Task<IActionResult> Atualizar([FromRoute] Guid id, [FromBody] AtualizarPedidoVm model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.Id)
            {
                return BadRequest("O id da url não corresponde ao id no payload");
            }

            var pedido = await _pedidoService.Atualizar(model.Id, model.NovoCep);
            return Ok(_mapper.Map<ConsultarPedidoVm>(pedido));
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Exclui um pedido")]
        public async Task<IActionResult> Remover([FromRoute] Guid id)
        {
            var pedido = await _pedidoService.ObterPorIdAsync(id);

            if (pedido == null)
                return NotFound();

            await _pedidoService.Remover(id);
            return NoContent();
        }

        [HttpPost("calcular-frete")]
        [ProducesResponseType(typeof(CalcularFreteResumo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerOperation(Summary = "Calculo de Frete", Description = "Permite calcular o frete para um pedido ainda não finalizado")]
        public async Task<IActionResult> CalcularFrete([FromBody] CalcularFretePedidoVm model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(model);
            }

            var pedido = new Pedido(model.ClienteId, DateTime.Now, model.CepDestino);
            var itensPedido = model.Itens.Select(item => new ItemPedido(pedido.Id, item.ProdutoId, item.FreteSelecionado.ModalidadeFrete, item.FreteSelecionado.DataAgendamento));
            pedido.AtualizarItens(itensPedido);
            var freteDeCadaItem = await _pedidoService.CalcularFreteDoPedido(pedido);

            var resumo = new CalcularFreteResumo()
            {
                ValorTotal = freteDeCadaItem.Sum(x => x?.Frete?.Valor),
                CepDestino = model?.CepDestino?.Numero,
                Itens = _mapper.Map<IEnumerable<CalcularFreteItemPedidoResumidoVm>>(freteDeCadaItem)
            };

            return Ok(resumo);
        }
    }
}
