using ApiCadastroPessoa.Domain.Exceptions;
using ApiCadastroPessoa.Domain.ValueObjects;
using Xunit;

namespace ApiCadastroPessoa.Tests.Domain
{
    public class EnderecoTests
    {
        [Fact]
        public void Deve_lancar_excecao_quando_cep_for_invalido()
        {
            Assert.Throws<DomainExceptions>(() =>
                new Endereco(
                    "123",
                    "Rua Teste",
                    "Centro",
                    "São Paulo",
                    "São Paulo",
                    "10",
                    null
                )
            );
        }
    }
}

