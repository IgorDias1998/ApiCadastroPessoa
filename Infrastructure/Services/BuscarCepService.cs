using System.Text.Json;
using ApiCadastroPessoa.Application.DTOs;
using ApiCadastroPessoa.Application.Interfaces;

namespace ApiCadastroPessoa.Infrastructure.Services
{
    public class BuscarCepService : ICepService
    {
        private readonly HttpClient _httpClient;

        public BuscarCepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CepResultDto> BuscarCepAsync(string cep)
        {

            var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<BuscarCepResponse>(json);

            if (data == null || data.erro)
                throw new Exception("Cep não encontrado.......");

            return new CepResultDto
            {
                Cep = data.cep,
                Logradouro = data.logradouro,
                Bairro = data.bairro,
                Cidade = data.localidade,
                Estado = data.estado
            };
        }

        private class BuscarCepResponse
        {
            public string cep { get; set; } = string.Empty;
            public string logradouro { get; set; } = string.Empty;
            public string bairro { get; set; } = string.Empty;
            public string localidade { get; set; } = string.Empty;
            public string estado { get; set; } = string.Empty;
            public bool erro { get; set; }
        }
    }
}
