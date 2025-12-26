using ApiCadastroPessoa.Domain.Entities;

namespace ApiCadastroPessoa.Domain.Interfaces
{
    public interface ICadastroPessoaRepository
    {
        Task AdicionarPessoaAsync(Pessoa pessoa);
        //Task<Pessoa?> ObterPessoaPorIdAsync(Guid id);
        //Task<List<Pessoa>> ObterTodasPessoasAsync();
        //Task AtualizarPessoAsync(Pessoa pessoa);
        //Task RemoverPessoaAsync(Pessoa pessoa);
    }
}
