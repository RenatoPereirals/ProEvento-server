using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{
  public readonly DataContext  _context;

  public EventoController(DataContext context)
  {
    _context = context;
  }

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
      return _context.Eventos;
    }

     [HttpGet(("{id}"))]
    public Evento GetById(int id)
    {
      return _context.Eventos.FirstOrDefault(evento => evento.Id == id) ?? new Evento();
    }

    [HttpPost]
    public string Post()
    {
      return "Exemplo de post";
    }

    [HttpPut("{id}")]
    public string Put(int id)
    {
      return $"Exemplo de put com id = {id}";
    }

    [HttpDelete("{id}")]
    public string Delete(int id)
    {
      return $"Exemplo de delete com id = {id}";
    }
}
