using ApiCadastroPessoa.Application.DTOs;
using ApiCadastroPessoa.Application.Interfaces;
using ApiCadastroPessoa.Domain.Entities;
using ApiCadastroPessoa.Domain.Interfaces;
using ApiCadastroPessoa.Domain.ValueObjects;

namespace ApiCadastroPessoa.Application.Services
{
    public class CadastroPessoaService
    {
        private readonly ICadastroPessoaRepository _repository;
        private readonly ICepService _cepService;

        public CadastroPessoaService(
            ICadastroPessoaRepository repository,
            ICepService cepService)
        {
            _repository = repository;
            _cepService = cepService;
        }

        public async Task CriarAsync(PessoaCreateDto dto)
        {
            var cepResult = await _cepService.BuscarCepAsync(dto.Cep);

            var endereco = new Endereco(
                cepResult.Cep,
                cepResult.Logradouro,
                cepResult.Bairro,
                cepResult.Cidade,
                cepResult.Estado,
                dto.Numero,
                dto.Complemento
            );

            var pessoa = new Pessoa(
                dto.Nome,
                dto.Email,
                dto.DataNascimento,
                dto.Telefone,
                endereco
            );

            await _repository.AdicionarPessoaAsync(pessoa);
        }
    }
}
