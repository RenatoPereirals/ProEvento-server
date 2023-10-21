using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{

  public IEnumerable<Evento> _evento  = new Evento[] {

    new Evento() 
    {
      Id = 1,
      Local = "Recife",
      Date = DateTime.Now.AddDays(2).ToString("dd/MM/aaaa"),
      Theme = ".Net core 7",
      QuantityOfPeople = 250,
      TicketTier = "1º lote",
      ImageUrl = "imagem1.png",
    },
    new Evento()
    {
      Id = 2,
      Local = "Camaragibe",
      Date = DateTime.Now.AddDays(3).ToString("dd/MM/aaaa"),
      Theme = "ASP.Net core e API RESTfull",
      QuantityOfPeople = 350,
      TicketTier = "1º lote",
      ImageUrl = "imagem2.png",
    }
  };

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
      return _evento;
    }

     [HttpGet(("{id}"))]
    public IEnumerable<Evento> GetById(int id)
    {
      return _evento.Where(evento => evento.Id == id);
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
