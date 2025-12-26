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

        public async Task<PessoaResponseDto> ObterPessoaPorIdAsync(Guid id)
        {
            var pessoa = await _repository.ObterPessoaPorIdAsync(id);

            if (pessoa == null)
                throw new Exception("Pessoa não encontrada");

            return MapearParaResponse(pessoa);
        }

        public async Task<List<PessoaResponseDto>> ObterTodasPessoasAsync()
        {
            var pessoas = await _repository.ObterTodasPessoasAsync();
            return pessoas.Select(MapearParaResponse).ToList();
        }

        private PessoaResponseDto MapearParaResponse(Pessoa pessoa)
        {
            return new PessoaResponseDto
            {
                Id = pessoa.Id,
                Nome = pessoa.Nome,
                Email = pessoa.Email,
                Telefone = pessoa.Telefone,
                DataNascimento = pessoa.DataNascimento,
                Endereco = new EnderecoResponseDto
                {
                    Cep = pessoa.Endereco.Cep,
                    Logradouro = pessoa.Endereco.Logradouro,
                    Bairro = pessoa.Endereco.Bairro,
                    Cidade = pessoa.Endereco.Cidade,
                    Estado = pessoa.Endereco.Estado,
                    Numero = pessoa.Endereco.Numero,
                    Complemento = pessoa.Endereco.Complemento
                }
            };
        }
    }
}
