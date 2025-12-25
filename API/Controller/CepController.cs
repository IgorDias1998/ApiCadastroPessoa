using ApiCadastroPessoa.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/cep")]
public class CepController : ControllerBase
{
    private readonly ICepService _cepService;

    public CepController(ICepService cepService)
    {
        _cepService = cepService;
    }

    [HttpGet("{cep}")]
    public async Task<IActionResult> Get(string cep)
    {
        var resultado = await _cepService.BuscarCepAsync(cep);
        return Ok(resultado);
    }
}