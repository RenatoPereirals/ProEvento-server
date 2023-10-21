using Microsoft.AspNetCore.Mvc;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{

    public EventoController(ILogger<EventoController> logger)
    {

    }

    [HttpGet()]
    public string Get()
    {
      return "Exemplo de get";
    }

    [HttpPost()]
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
