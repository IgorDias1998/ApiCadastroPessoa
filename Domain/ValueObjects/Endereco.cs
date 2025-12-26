using ApiCadastroPessoa.Domain.Exceptions;

namespace ApiCadastroPessoa.Domain.ValueObjects
{
    public class Endereco
    {
        public string Cep { get; }
        public string Logradouro { get; }
        public string Bairro { get; }
        public string Cidade { get; }
        public string Estado { get; }
        public string Numero { get; }
        public string? Complemento { get; }

        protected Endereco() { }

        public Endereco(
            string cep,
            string logradouro,
            string bairro,
            string cidade,
            string estado,
            string numero,
            string? complemento)
        {
            Validar(cep, logradouro, cidade, estado, numero);

            Cep = LimparCep(cep);
            Logradouro = logradouro;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado.ToUpper();
            Numero = numero;
            Complemento = complemento;
        }

        private void Validar(string cep, string logradouro, string cidade, string estado, string numero)
        {
            if (string.IsNullOrWhiteSpace(cep))
                throw new DomainExceptions("CEP é obrigatório.");

            if (LimparCep(cep).Length != 8)
                throw new DomainExceptions("CEP inválido.");

            if (string.IsNullOrWhiteSpace(logradouro))
                throw new DomainExceptions("Logradouro é obrigatório.");

            if (string.IsNullOrWhiteSpace(cidade))
                throw new DomainExceptions("Cidade é obrigatória.");

            if (string.IsNullOrWhiteSpace(estado))
                throw new DomainExceptions("Estado inválido.");

            if (string.IsNullOrWhiteSpace(numero))
                throw new DomainExceptions("Número é obrigatório.");
        }

        private string LimparCep(string cep)
            => cep.Replace("-", "").Trim();
    }
}
