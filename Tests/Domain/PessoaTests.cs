using ApiCadastroPessoa.Domain.Entities;
using ApiCadastroPessoa.Domain.Exceptions;
using ApiCadastroPessoa.Domain.ValueObjects;
using Xunit;

namespace ApiCadastroPessoa.Tests.Domain
{
    public class PessoaTests
    {
        [Fact]
        public void Deve_lancar_excecao_quando_nome_for_vazio()
        {
            var endereco = new Endereco(
                "01001000",
                "Rua Teste",
                "Centro",
                "São Paulo",
                "São Paulo",
                "10",
                null
            );

            Assert.Throws<DomainExceptions>(() =>
                new Pessoa(
                    "",
                    "email@email.com",
                    DateTime.Now.AddYears(-20),
                    "11999999999",
                    endereco
                )
            );
        }
    }
}

