using ApiCadastroPessoa.Domain.Entities;
using ApiCadastroPessoa.Domain.Interfaces;
using ApiCadastroPessoa.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Pessoa?> ObterPessoaPorIdAsync(Guid id)
        {
            return await _context.Pessoas
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<List<Pessoa>> ObterTodasPessoasAsync()
        {
            return await _context.Pessoas
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
