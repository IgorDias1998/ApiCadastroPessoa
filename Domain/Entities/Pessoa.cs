using System.Runtime.ConstrainedExecution;
using ApiCadastroPessoa.Domain.Exceptions;
using ApiCadastroPessoa.Domain.ValueObjects;

namespace ApiCadastroPessoa.Domain.Entities
{
    public class Pessoa
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public DateTime DataNascimento { get; private set; }
        public string Telefone { get; private set; } = string.Empty;

        public Endereco Endereco { get; private set; } = null!;

        protected Pessoa() { }

        public Pessoa(
            string nome,
            string email,
            DateTime dataNascimento,
            string telefone,
            Endereco endereco)
        {
            Validar(nome, email, dataNascimento, telefone);

            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Endereco = endereco;
        }

        public void AtualizarDados(
            string nome,
            string email,
            string telefone,
            Endereco endereco)
        {
            Validar(nome, email, DataNascimento, telefone);

            Nome = nome;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
        }

        private void Validar(string nome, string email, DateTime dataNascimento, string telefone)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new DomainExceptions("Nome é obrigatório.");

            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@") || !email.Contains("."))
                throw new DomainExceptions("Email inválido.");

            if (string.IsNullOrWhiteSpace(telefone))
                throw new DomainExceptions("Telefone é obrigatório.");
        }
    }
}
