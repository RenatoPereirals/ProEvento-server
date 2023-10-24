using Microsoft.AspNetCore.Mvc;
using Domain;
using Persistence;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventController : ControllerBase
{
  public readonly ProEventosContext  _context;

  public EventController(ProEventosContext context)
  {
    _context = context;
  }

    [HttpGet]
    public IEnumerable<Event> GetAllEvents()
    {
      return _context.Events;
    }

    [HttpGet("{id}")]
    public Event GetById(int id)
    {
      return _context.Events.FirstOrDefault(e => e.Id == id) ?? new Event();
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