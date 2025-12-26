using ApiCadastroPessoa.Domain.Entities;
using ApiCadastroPessoa.Domain.Interfaces;
using ApiCadastroPessoa.Infrastructure.Data;

namespace ApiCadastroPessoa.Infrastructure.Repositories
{
    public class CadastroPessoaRepository : ICadastroPessoaRepository
    {
        private readonly AppDbContext _context;

        public CadastroPessoaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarPessoaAsync(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();
        }
    }
}
