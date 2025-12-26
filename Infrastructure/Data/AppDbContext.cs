using ApiCadastroPessoa.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiCadastroPessoa.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Pessoa> Pessoas => Set<Pessoa>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
