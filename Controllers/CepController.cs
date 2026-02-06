using Api_LojaTricotllure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api_LojaTricotllure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CepController : ControllerBase
{
    private readonly HttpClient _httpClient;
    
    public CepController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    [HttpGet("ConsultarCEP")]
    [AllowAnonymous]
    public async Task<IActionResult> ConsultarCep([FromQuery] string cep)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<object>(
                $"https://viacep.com.br/ws/{cep}/json/"
            );

            return Ok(response);
        }
        catch (Exception ex)
        {
            return NotFound("Erro ao buscar CEP");
        }
    }
}