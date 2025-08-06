using Microsoft.AspNetCore.Mvc;

namespace ModuloApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    [HttpGet("ObterDataHoraAtual")]
    public IActionResult ObterDataHoraAtual()
    {
        var obj = new
        {
            Data = DateTime.Now.ToLongDateString(),
            Hora = DateTime.Now.ToLongTimeString(),
        };
        return Ok(obj);
    }

    [HttpGet("Apresentar/{nome}")]
    public IActionResult Aoresentar(string nome)
    {
        var mensagem = $"Olá {nome}, seja bem vindo!";
        return Ok(new { mensagem });
    }
}
