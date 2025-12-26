using ApiCadastroPessoa.Application.DTOs;
using ApiCadastroPessoa.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiCadastroPessoa.API.Controller
{
    [ApiController]
    [Route("api/pessoas")]
    public class CadastroPessoaController :ControllerBase
    {
        private readonly CadastroPessoaService _cadastroPessoaService;

        public CadastroPessoaController(CadastroPessoaService cadastroPessoaService)
        {
            _cadastroPessoaService = cadastroPessoaService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PessoaCreateDto dto)
        {
            await _cadastroPessoaService.CriarAsync(dto);
            return Created(string.Empty, null);
        }

        // GET /api/pessoas
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var pessoas = await _cadastroPessoaService.ObterTodasPessoasAsync();
            return Ok(pessoas);
        }

        // GET /api/pessoas/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var pessoa = await _cadastroPessoaService.ObterPessoaPorIdAsync(id);
            return Ok(pessoa);
        }
    }
}
