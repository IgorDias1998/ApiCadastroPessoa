namespace ApiCadastroPessoa.Application.DTOs
{
    public class PessoaResponseDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; } = string.Empty;

        public EnderecoResponseDto Endereco { get; set; } = null!;

    }
}
