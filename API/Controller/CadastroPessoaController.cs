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
            return Created("", new ApiResponseDto
            {
                Sucesso = true,
                Mensagem = "Cadastro realizado com sucesso."
            });
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var pessoas = await _cadastroPessoaService.ObterTodasPessoasAsync();
            return Ok(pessoas);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var pessoa = await _cadastroPessoaService.ObterPessoaPorIdAsync(id);
            return Ok(pessoa);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] PessoaUpdateDto dto)
        {
            await _cadastroPessoaService.AtualizarAsync(id, dto);
            return Ok(new ApiResponseDto
            {
                Sucesso = true,
                Mensagem = "Cadastro atualizado com sucesso."
            });
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _cadastroPessoaService.RemoverAsync(id);
            return Ok(new ApiResponseDto
            {
                Sucesso = true,
                Mensagem = "Cadastro removido com sucesso."
            });
        }
    }
}
