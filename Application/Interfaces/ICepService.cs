using ApiCadastroPessoa.Application.DTOs;

namespace ApiCadastroPessoa.Application.Interfaces
{
    public interface ICepService
    {
        Task<CepResultDto> BuscarCepAsync(string cep);
        Task BuscarPessoaAsync(string cep);
    }
}
