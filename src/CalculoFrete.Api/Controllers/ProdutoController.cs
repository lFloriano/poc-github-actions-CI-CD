using AutoMapper;
using CalculoFrete.Api.Models;
using CalculoFrete.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CalculoFrete.Api.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutoController : ControllerBase
    {
        readonly IProdutoService _produtoService;
        readonly IMapper _mapper;

        public ProdutoController(IProdutoService produtoService, IMapper mapper)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ConsultarProdutoVm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Obtém produto por id")]
        public async Task<IActionResult> ObterPorId([FromRoute] Guid id)
        {
            var produto = await _produtoService.ObterPorIdAsync(id);

            if (produto == null)
                return NotFound();

            return Ok(_mapper.Map<ConsultarProdutoVm>(produto));
        }

        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<ConsultarProdutoVm>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [SwaggerOperation(Summary = "Obtém todos os produtos cadastrados")]
        public async Task<IActionResult> ObterTodos()
        {
            var produtos = await _produtoService.ObterTodosAsync();

            if (produtos == null || !produtos.Any())
                return NoContent();

            return Ok(_mapper.Map<IEnumerable<ConsultarProdutoVm>>(produtos));
        }
    }
}
