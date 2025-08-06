using Microsoft.AspNetCore.Mvc;
using ModuloApi.Context;
using ModuloApi.Entities;

namespace ModuloApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ContatoController : ControllerBase
{
    private readonly AgendaContext _context;    
    public ContatoController(AgendaContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult Criar(Contato contato)
    { 
        _context.Contatos.Add(contato);
        _context.SaveChanges();
        return Ok(contato);
    }

    [HttpGet("{id}")]
    public IActionResult ObterPorId(int id)
    {
        var contato = _context.Contatos.Find(id);
        if (contato == null)
        {
            return NotFound();
        }
        return Ok(contato);
    }

    [HttpPut("{id}")]
    public IActionResult Atualizar(int id, Contato contato)
    {
        if (id != contato.Id)
        {
            return BadRequest("ID do contato não corresponde.");
        }
        var existingContato = _context.Contatos.Find(id);
        if (existingContato == null)
        {
            return NotFound();
        }
        existingContato.Nome = contato.Nome;
        existingContato.Telefone = contato.Telefone;
        existingContato.Ativo = contato.Ativo;

        _context.Contatos.Update(existingContato);
        _context.SaveChanges();

        return Ok(existingContato);
    }
}
